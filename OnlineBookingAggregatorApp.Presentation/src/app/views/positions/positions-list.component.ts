import {Component, OnInit} from '@angular/core';
import {Observable} from 'rxjs';
import {ColumnDef} from '../../models/column-def.model';
import {PositionModel} from '../../models';
import {MaterialGridHelperComponent} from '../../shared/components/table/material-grid-helper.component';
import {PagedRequest} from '../../models/paged-request.model';
import {AuthService} from '../../services/auth.service';
import {PositionsService} from '../../services/positions.service';
import {NgOnDestroy} from '../../services/on-destroy.service';
import {filter, map, shareReplay, switchMap, takeUntil, tap} from 'rxjs/operators';
import {SnackbarNotificationService} from '../../services/snackbar-notification.service';
import {MatDialog} from '@angular/material/dialog';
import {ConfirmationDialogComponent} from '../../shared/components/confirmation-dialog/confirmation-dialog.component';
import {ConfirmationDialogDataModel} from '../../models/confirmation-dialog-data.model';
import {PositionFormComponent} from './form/position-form.component';
import {HttpErrorResponse} from '@angular/common/http';

@Component({
    selector: 'positions-list',
    templateUrl: './positions-list.component.html',
    styleUrls: ['./positions-list.component.scss'],
    providers: [NgOnDestroy]
})

export class PositionsListComponent extends MaterialGridHelperComponent implements OnInit {

    isLoading: boolean = false;

    positions$: Observable<PositionModel[]>;

    constructor(
        protected readonly authService: AuthService,
        private readonly positionsService: PositionsService,
        protected readonly onDestroy$: NgOnDestroy,
        private readonly notification: SnackbarNotificationService,
        protected readonly dialog: MatDialog
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
                columnToMap: 'Name',
                sortable: true,
                useInSearch: true,
                showsStandardText: true
            },
            <ColumnDef>{
                id: 'description',
                name: 'Description',
                columnToMap: 'Description',
                sortable: true,
                useInSearch: true
            }
        ];
    }

    ngOnInit(): void {
        super.ngOnInit();
    }

    protected fetchData(request: PagedRequest) {
        this.positions$ = this.positionsService.getCompanyPositionsPaged(this.companyId, request)
            .pipe(
                takeUntil(this.onDestroy$),
                tap((x) => this.totalItems$.next(x.totalCount)),
                map((x) => x.data),
                shareReplay()
            );
    }

    deletePosition(positionId: number): void {
        const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
                disableClose: true,
                data: <ConfirmationDialogDataModel>{
                    isWarning: true,
                    title: 'Delete Position',
                    okButtonText: 'Confirm',
                    cancelButtonText: 'Cancel',
                    message: 'Are You sure You want to delete this position?'
                }
            });
        dialogRef.afterClosed()
            .pipe(
                takeUntil(this.onDestroy$),
                filter(x => x),
                switchMap(() => this.positionsService.deletePosition(positionId))
            ).subscribe(() => {
                this.isLoading = true;
                this.fetchData(this.pagedRequest);
                this.notification.openSuccess('Position deleted.');
        }, (error: HttpErrorResponse) => {
            this.notification.openErrorWithResponseMessage('Could not delete position.', error);
        }, () => this.isLoading = false);
    }

    openEditDialog(positionId: number): void {
        const dialogRef = this.dialog.open(PositionFormComponent, {
            data: positionId,
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
        }, (error: HttpErrorResponse) => this.notification.openError('Could not save changes.'),
            () => this.isLoading = false);
    }
}
