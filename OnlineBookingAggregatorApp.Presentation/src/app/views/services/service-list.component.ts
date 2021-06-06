import {Component, OnInit} from '@angular/core';
import {ServicesService} from '../../services/services.service';
import {MatDialog} from '@angular/material/dialog';
import {AuthService} from '../../services/auth.service';
import {SnackbarNotificationService} from '../../services/snackbar-notification.service';
import {NgOnDestroy} from '../../services/on-destroy.service';
import {MaterialGridHelperComponent} from '../../shared/components/table/material-grid-helper.component';
import {PagedRequest} from '../../models/paged-request.model';
import {Observable} from 'rxjs';
import {ServiceModel} from '../../models';
import {filter, map, shareReplay, takeUntil, tap} from 'rxjs/operators';
import {ServiceFormComponent} from './form/service-form.component';
import {ColumnDef} from '../../models/column-def.model';
import {HttpErrorResponse} from '@angular/common/http';

@Component({
    selector: 'service-list',
    templateUrl: './service-list.component.html',
    styleUrls: ['./service-list.component.scss'],
    providers: [NgOnDestroy]
})
export class ServiceListComponent extends MaterialGridHelperComponent implements OnInit {
    private readonly cantDeleteItemMsg: string = 'You can not delete this service as it contains bookings.';
    private readonly savingFailed: string = 'Could not save changes.';
    private readonly deleteFail: string = 'Could not delete service.';
    private readonly warningMsg: string = 'Are you sure You want to delete this service?';

    model: ServiceModel = new ServiceModel();
    services$: Observable<ServiceModel[]>;
    isLoading: boolean;

    constructor(
        private readonly servicesService: ServicesService,
        protected readonly dialog: MatDialog,
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
                useInSearch: true,
                sortable: true,
                columnToMap: 'Name'
            },
            <ColumnDef>{
                id: 'category',
                name: 'Category',
                useInSearch: true,
                sortable: true,
                columnToMap: 'Category.Name',
                useSpecificColumnForSort: true,
                useAlternativeNameToDisplayForSearch: true
            },
            <ColumnDef>{
                id: 'description',
                name: 'Description',
                useInSearch: true,
                sortable: true,
                columnToMap: 'Description',
                showsLargeText: true
            },
            <ColumnDef>{
                id: 'minPrice',
                name: 'Min Price',
                sortable: true,
                showsNumber: true
            },
            <ColumnDef>{
                id: 'maxPrice',
                name: 'Max Price',
                sortable: true,
                showsNumber: true
            },
            <ColumnDef>{
                id: 'bookingsCount',
                name: 'Number of Bookings',
                showsNumber: true
            }
        ];
    }

    ngOnInit(): void {
        super.ngOnInit();
    }

    protected fetchData(request: PagedRequest) {
        this.services$ = this.servicesService.getPaged(this.companyId, request)
            .pipe(
                takeUntil(this.onDestroy$),
                tap((x) => this.totalItems$.next(x.totalCount)),
                map((x) => x.data),
                shareReplay()
            );
    }

    async openDialog(serviceId: number): Promise<void> {
        this.model = new ServiceModel();
        if(serviceId !== 0){
            this.model = await this.servicesService.getById(serviceId).toPromise();
        }

        const dialogRef = this.dialog.open(ServiceFormComponent,{
            data: {service: this.model},
            disableClose: true,
            height: '600px',
            width: '500px'
        });

        dialogRef.afterClosed().pipe(
            takeUntil(this.onDestroy$),
            filter(x => x)
        ).subscribe(() => {
            this.isLoading = true;
            this.fetchData(this.pagedRequest);
        }, (error: HttpErrorResponse) => this.snackbar.openErrorWithResponseMessage(this.savingFailed, error),
            () => this.isLoading = false);
    }

    deleteService(serviceId: number): void {
        this.servicesService.canDelete(serviceId).subscribe((result) => {
                if(!result){
                    this.canNotDeleteItem(this.cantDeleteItemMsg).then();
                    return;
                }
            this.confirmDeletion(this.warningMsg, 'Delete Service').then(result => {
                if(result){
                    this.servicesService.delete(serviceId).subscribe(() => {
                        this.isLoading = true;
                        this.fetchData(this.pagedRequest);
                        this.snackbar.openSuccess('Service deleted.');
                    }, (error: HttpErrorResponse) => this.snackbar.openErrorWithResponseMessage(this.deleteFail, error),
                        () => this.isLoading = false);
                }
            });
        });
    }
}
