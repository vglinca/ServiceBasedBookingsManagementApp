import {Component, OnInit} from '@angular/core';
import {Observable} from 'rxjs';
import {CategoryModel} from '../../models';
import {MatDialog} from '@angular/material/dialog';
import {CategoriesService} from '../../services/categories.service';
import {AuthService} from '../../services/auth.service';
import {SnackbarNotificationService} from '../../services/snackbar-notification.service';
import {NgOnDestroy} from '../../services/on-destroy.service';
import {MaterialGridHelperComponent} from '../../shared/components/table/material-grid-helper.component';
import {PagedRequest} from '../../models/paged-request.model';
import {ColumnDef} from '../../models/column-def.model';
import {filter, map, shareReplay, takeUntil, tap} from 'rxjs/operators';
import {CategoryFormComponent} from './form/category-form.component';
import {HttpErrorResponse} from '@angular/common/http';

@Component({
    selector: 'categories-list',
    templateUrl: './categories-list.component.html',
    styleUrls: ['./categories-list.component.scss'],
    providers: [NgOnDestroy]
})
export class CategoriesListComponent extends MaterialGridHelperComponent implements OnInit {

    isLoading: boolean = false;
    categories$: Observable<CategoryModel[]>;

    constructor(
        protected readonly dialog: MatDialog,
        private readonly categoryService: CategoriesService,
        protected readonly authService: AuthService,
        private readonly snackbar: SnackbarNotificationService,
        protected readonly onDestroy$: NgOnDestroy
    ) {
        super(dialog, onDestroy$, authService);
        this.pagedRequest = <PagedRequest>{
            pageNumber: 1,
            pageSize: this.pageSize,
            orderBy: 'name',
            ascending: true
        };
        this.columnDefs = [
            <ColumnDef>{
                id: 'name',
                name: 'Name',
                sortable: true,
                columnToMap: 'Name',
                useInSearch: true
            },
            <ColumnDef>{
                id: 'businessArea',
                name: 'Business Area',
                sortable: true
            },
            <ColumnDef>{
                id: 'serviceTargetGroup',
                name: 'Service Target Group',
                sortable: true
            },
            <ColumnDef>{
                id: 'totalServices',
                name: 'Total Services in Category'
            }
        ]
    }

    ngOnInit(): void {
        super.ngOnInit();
    }

    protected fetchData(request: PagedRequest): void {
        this.categories$ = this.categoryService.getPaged(this.companyId, request)
            .pipe(
                takeUntil(this.onDestroy$),
                tap((x) => this.totalItems$.next(x.totalCount)),
                map((x) => x.data),
                shareReplay()
            );
    }

    addEditCategory(categoryId: number): void {
        const dialogRef = this.dialog.open(CategoryFormComponent, {
            data: categoryId,
            disableClose: true,
            height: '450px',
            width: '450px'
        });

        dialogRef.afterClosed().pipe(
            takeUntil(this.onDestroy$),
            filter(res => res)
        ).subscribe(() => {
                this.isLoading = true;
                this.fetchData(this.pagedRequest);
            }, (error: HttpErrorResponse) => this.snackbar.openErrorWithResponseMessage('Could not save changes.', error),
            () => this.isLoading = false);
    }

    deleteCategory(categoryId: number): void {
        this.categoryService.checkCategoryContainsService(categoryId)
            .subscribe((result) => {
                if(!result){
                    this.canNotDeleteItem('You can not delete this category as it contains services.').then();
                    return;
                }
                this.confirmDeletion('Are you sure You want to delete this category?', 'Delete Category').then(result => {
                    if(result){
                        this.categoryService.delete(categoryId).pipe(
                            takeUntil(this.onDestroy$), tap(() => this.isLoading = true)
                        ).subscribe(() => {
                            this.fetchData(this.pagedRequest);
                            this.isLoading =  false;
                            this.snackbar.openSuccess('Category deleted.');
                        }, (error: HttpErrorResponse) => {
                            this.snackbar.openErrorWithResponseMessage('Could not delete category.', error);
                        }, () => this.isLoading = false);
                    }
                });
            });
        // const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
        //     disableClose: true,
        //     data: <ConfirmationDialogDataModel>{
        //         isWarning: true,
        //         title: 'Delete Position',
        //         okButtonText: 'Confirm',
        //         cancelButtonText: 'Cancel',
        //         message: 'Are You sure You want to delete this category?'
        //     }
        // });
        //
        // dialogRef.afterClosed()
        //     .pipe(
        //         takeUntil(this.onDestroy$),
        //         filter(x => x),
        //         switchMap(() => this.categoryService.deleteCategory(categoryId))
        //     ).subscribe(() => {
        //     this.isLoading = true;
        //     this.fetchData(this.pagedRequest);
        //     this.snackbar.openSuccess('Category deleted.');
        // }, (error: HttpErrorResponse) => {
        //     this.snackbar.openErrorWithResponseMessage('Could not delete category.', error);
        // }, () => this.isLoading = false);
    }
}
