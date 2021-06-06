import {Directive, OnInit} from '@angular/core';
import {PagedRequest} from '../../../models/paged-request.model';
import {ColumnDef} from '../../../models/column-def.model';
import {MatDialog} from '@angular/material/dialog';
import {ConfirmationDialogComponent} from '../confirmation-dialog/confirmation-dialog.component';
import {ConfirmationDialogDataModel} from '../../../models/confirmation-dialog-data.model';
import {NgOnDestroy} from '../../../services/on-destroy.service';
import {filter, takeUntil} from 'rxjs/operators';
import {WarningDialogComponent} from '../warning-dialog/warning-dialog.component';
import {AuthService} from '../../../services/auth.service';
import {BehaviorSubject, combineLatest, Observable} from 'rxjs';
import {Select} from '@ngxs/store';
import {CurrentUserState} from '../../../store/current-user.state';
import {Policy} from '../../../enums/policy';
import {EmployeeSelectionModel} from '../../../models';

@Directive()
export abstract class MaterialGridHelperComponent implements OnInit{

    protected abstract fetchData(request: PagedRequest);

    pageSize: number = 10;
    protected pagedRequest: PagedRequest;
    columnDefs: ColumnDef[];
    protected companyId: number;
    readonly Policy = Policy;

    totalItems$: BehaviorSubject<number> = new BehaviorSubject<number>(10);
    @Select(CurrentUserState.getCompanyId) companyId$: Observable<number>;

    protected constructor(
        protected readonly dialog: MatDialog,
        protected readonly onDestroy$: NgOnDestroy,
        protected readonly authService: AuthService
    ) {}

    ngOnInit(): void {
        this.companyId$.pipe(takeUntil(this.onDestroy$))
            .subscribe((id) => {
                this.companyId = id;
                this.fetchData(this.pagedRequest);
            });
    }

    onChange(pagedRequest: PagedRequest): void {
        this.pagedRequest = pagedRequest;
        this.fetchData(pagedRequest);
    }

    protected confirmDeletion(message: string = 'Would you like to delete this item?', title: string = 'Confirmation', isWarning: boolean = false): Promise<any> {
        return new Promise<any>((resolve) => {
            const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
                disableClose: true,
                data: <ConfirmationDialogDataModel>{
                    isWarning: isWarning,
                    title: title,
                    okButtonText: 'Confirm',
                    cancelButtonText: 'Cancel',
                    message: message
                }
            });

            dialogRef.afterClosed().pipe(takeUntil(this.onDestroy$)).subscribe(resolve);
        });
    }

    protected canNotDeleteItem(message: string = 'This item can not be deleted.'): Promise<any> {
        return new Promise<any>((resolve) => {
            const dialogRef=  this.dialog.open(WarningDialogComponent, {
                disableClose: true,
                data: {
                    message: message
                }
            });

            dialogRef.afterClosed().pipe(takeUntil(this.onDestroy$)).subscribe(resolve);
        });
    }
}
