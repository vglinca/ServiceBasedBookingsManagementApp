import {Component, OnInit} from '@angular/core';
import {MaterialGridHelperComponent} from '../../shared/components/table/material-grid-helper.component';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {AuthService} from '../../services/auth.service';
import {SnackbarNotificationService} from '../../services/snackbar-notification.service';
import {NgOnDestroy} from '../../services/on-destroy.service';
import {PagedRequest} from '../../models/paged-request.model';
import {ClientsService} from '../../services/clients.service';
import {Observable} from 'rxjs';
import {ClientModel} from '../../models';
import {ColumnDef} from '../../models/column-def.model';
import {filter, map, shareReplay, switchMap, takeUntil, tap} from 'rxjs/operators';
import {ClientFormComponent} from './form/client-form.component';
import {HttpErrorResponse} from '@angular/common/http';
import {ConfirmationDialogComponent} from '../../shared/components/confirmation-dialog/confirmation-dialog.component';
import {ConfirmationDialogDataModel} from '../../models/confirmation-dialog-data.model';

@Component({
    selector: 'clients',
    templateUrl: './client-list.component.html',
    styleUrls: ['./client-list.component.scss'],
    providers: [NgOnDestroy]
})
export class ClientListComponent extends MaterialGridHelperComponent implements OnInit {
    isLoading: boolean;
    clients$: Observable<ClientModel[]>;
    dialogRef: MatDialogRef<ConfirmationDialogComponent>;
    constructor(
        private readonly clientsService: ClientsService,
        protected readonly dialog: MatDialog,
        protected readonly authService: AuthService,
        private readonly snackbar: SnackbarNotificationService,
        protected readonly onDestroy$: NgOnDestroy
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
                useInSearch: true,
                columnToMap: 'FirstName'
            },
            <ColumnDef>{
                id: 'lastName',
                name: 'Last Name',
                sortable: true,
                useInSearch: true,
                columnToMap: 'LastName'
            },
            <ColumnDef>{
                id: 'email',
                name: 'Email',
                sortable: true,
                useInSearch: true,
                columnToMap: 'Email'
            },
            <ColumnDef>{
                id: 'phoneNumber',
                name: 'Phone',
                sortable: true,
                useInSearch: true,
                columnToMap: 'PhoneNumber'
            },
            // <ColumnDef>{
            //     id: 'additionalPhoneNumber',
            //     name: 'Second Phone',
            //     sortable: true,
            //     useInSearch: true,
            //     columnToMap: 'AdditionalPhoneNumber'
            // },
            <ColumnDef>{
                id: 'gender',
                name: 'Gender',
                sortable: true,
                useInSearch: false,
                columnToMap: 'Gender'
            },
            <ColumnDef>{
                id: 'clientCategory',
                name: 'Category',
                sortable: true,
                useInSearch: false,
                columnToMap: 'ClientCategory'
            }
        ];
    }

    ngOnInit(): void {
        super.ngOnInit();
    }

    protected fetchData(request: PagedRequest) {
        this.clients$ = this.clientsService.getPaged(this.companyId, request).pipe(
            takeUntil(this.onDestroy$),
            tap((x) => this.totalItems$.next(x.totalCount)),
            map((x) => x.data),
            shareReplay()
        );
    }

    async openAddEditDialog(clientId: number): Promise<void> {
        let model: ClientModel = new ClientModel();
        if(clientId !== 0){
            model = await this.clientsService.getById(clientId).toPromise();
        }

        const dialogRef = this.dialog.open(ClientFormComponent, {
            data: model,
            disableClose: true,
            height: '800px',
            width: '580px'
        });

        dialogRef.afterClosed().pipe(
            takeUntil(this.onDestroy$),
            filter(x => x)
        ).subscribe(() => {
                this.isLoading = true;
                this.fetchData(this.pagedRequest);
            }, (error: HttpErrorResponse) => this.snackbar.openErrorWithResponseMessage('Could not save changes', error),
            () => this.isLoading = false);
    }

    deleteClient(clientId: number): void {
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
                switchMap(() => this.clientsService.delete(clientId))
            ).subscribe(() => {
            this.isLoading = true;
            this.fetchData(this.pagedRequest);
            this.snackbar.openSuccess('Client deleted.');
        }, (error: HttpErrorResponse) => {
            this.snackbar.openErrorWithResponseMessage('Could not delete client.', error);
        }, () => this.isLoading = false);
    }
}
