import {Component, OnInit} from '@angular/core';
import {ColumnDef} from '../../models/column-def.model';
import {BehaviorSubject, Observable} from 'rxjs';
import {PagedRequest} from '../../models/paged-request.model';
import {NgOnDestroy} from '../../services/on-destroy.service';
import {AuthService} from '../../services/auth.service';
import {filter, map, shareReplay, switchMap, takeUntil, tap} from 'rxjs/operators';
import {SnackbarNotificationService} from '../../services/snackbar-notification.service';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {ConfirmationDialogComponent} from '../../shared/components/confirmation-dialog/confirmation-dialog.component';
import {ConfirmationDialogDataModel} from '../../models/confirmation-dialog-data.model';
import {EmployeesService} from '../../services/employees.service';
import {EmployeeModel} from '../../models';
import {MaterialGridHelperComponent} from '../../shared/components/table/material-grid-helper.component';
import {HttpErrorResponse} from '@angular/common/http';
import {EmployeeStatusModel} from '../../models';
import {AllLookupsService} from '../../services/all-lookups.service';
import {fromPromise} from 'rxjs/internal-compatibility';
import {EmployeeStatus} from '../../enums/employee-status';

@Component({
    selector: 'employees',
    templateUrl: './employees-list.component.html',
    styleUrls: ['./employees-list.component.scss'],
    providers: [NgOnDestroy]
})
export class EmployeesListComponent extends MaterialGridHelperComponent implements OnInit {
    isLoading: boolean = false;

    employees$: Observable<EmployeeModel[]>;
    employeeStatuses$: Observable<EmployeeStatusModel[]>;
    dialogRef: MatDialogRef<ConfirmationDialogComponent>;

    activeStatus: EmployeeStatus = EmployeeStatus.Active;

    constructor(
        private readonly employeesClient: EmployeesService,
        private readonly lookupService: AllLookupsService,
        protected readonly onDestroy$: NgOnDestroy,
        protected readonly authService: AuthService,
        private readonly notification: SnackbarNotificationService,
        protected readonly dialog: MatDialog
    ) {
        super(dialog, onDestroy$, authService);
        this.pagedRequest = <PagedRequest>{
            pageNumber: 1,
            pageSize: this.pageSize,
            orderBy: 'email',
            ascending: true
        };
        this.columnDefs = [
            <ColumnDef>{
                id: 'firstName',
                name: 'First Name',
                sortable: true,
                columnToMap: 'FirstName',
                useInSearch: true
            },
            <ColumnDef>{
                id: 'lastName',
                name: 'Last Name',
                sortable: true,
                columnToMap: 'LastName',
                useInSearch: true
            },
            <ColumnDef>{
                id: 'email',
                name: 'Email',
                sortable: true,
                columnToMap: 'email',
                useInSearch: true
            },
            <ColumnDef>{
                id: 'phoneNumber',
                name: 'Phone'
            },
            <ColumnDef>{
                id: 'position',
                name: 'Position',
                sortable: true,
                useInSearch: true,
                columnToMap: 'Position.Name',
                useSpecificColumnForSort: true,
                useAlternativeNameToDisplayForSearch: true
            },
            <ColumnDef>{
                id: 'specialization',
                name: 'Specialization',
                sortable: true,
                columnToMap: 'Specialization',
                useInSearch: true
            },
            <ColumnDef>{
                id: 'systemRole',
                name: 'Role',
                sortable: true
            }
        ];
    }

    ngOnInit(): void {
        super.ngOnInit();
        this.employeeStatuses$ = fromPromise(this.lookupService.getEmployeeStatuses());
    }

    fetchData(request: PagedRequest = null): void {
        this.employees$ = this.employeesClient.getPaged(this.companyId, request)
            .pipe(
                takeUntil(this.onDestroy$),
                tap((x) => this.totalItems$.next(x.totalCount)),
                map((x) => x.data),
                shareReplay()
            );
    }

    deleteEmployee(id: number): void {
        this.dialogRef = this.dialog.open(ConfirmationDialogComponent, {
            disableClose: true,
            data: <ConfirmationDialogDataModel>{
                isWarning: true,
                title: 'Remove Employee',
                okButtonText: 'Confirm',
                cancelButtonText: 'Cancel',
                message: 'Delete employee from the system?'
            }
        });

        this.dialogRef.afterClosed()
            .pipe(
                takeUntil(this.onDestroy$),
                filter((res) => res),
                switchMap(() => this.employeesClient.delete(id))
            ).subscribe(() => {
                this.isLoading = true;
                this.fetchData(this.pagedRequest);
                this.notification.openSuccess('Employee deleted.');
                }, (error: HttpErrorResponse) => {
                this.notification.openErrorWithResponseMessage('Could not delete employee.', error);
                }, () => this.isLoading = false);
    }

    stopLoading(): void {
        this.isLoading = false;
    }
}
