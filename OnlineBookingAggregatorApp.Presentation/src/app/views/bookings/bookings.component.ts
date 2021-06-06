import {Component, OnInit} from '@angular/core';
import {MaterialGridHelperComponent} from '../../shared/components/table/material-grid-helper.component';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {AuthService} from '../../services/auth.service';
import {SnackbarNotificationService} from '../../services/snackbar-notification.service';
import {NgOnDestroy} from '../../services/on-destroy.service';
import {PagedRequest} from '../../models/paged-request.model';
import {ColumnDef} from '../../models/column-def.model';
import {BookingCalendarEventModel, BookingPageModel, BookingStateModel} from '../../models';
import {ConfirmationDialogComponent} from '../../shared/components/confirmation-dialog/confirmation-dialog.component';
import {BookingsService} from '../../services/bookings.service';
import {Observable} from 'rxjs';
import {filter, map, shareReplay, takeUntil, tap} from 'rxjs/operators';
import {TimeUtils} from '../../utils/time.utils';
import {BookingFormComponent} from './add-booking-form/booking-form.component';
import {HttpErrorResponse} from '@angular/common/http';
import {EditBookingFormComponent} from './edit-booking-form/edit-booking-form.component';
import {AllLookupsService} from '../../services/all-lookups.service';
import {UsersService} from '../../services/users.service';

@Component({
    selector: 'bookings',
    templateUrl: './bookings.component.html',
    styleUrls: ['./bookings.component.scss'],
    providers: [NgOnDestroy]
})
export class BookingsComponent extends MaterialGridHelperComponent implements OnInit {

    public bookings$: Observable<BookingPageModel[]>;
    public dialogRef: MatDialogRef<ConfirmationDialogComponent>;
    public bookingStates: BookingStateModel[] = [];

    isLoading: boolean = false;
    constructor(
        protected readonly dialog: MatDialog,
        protected readonly authService: AuthService,
        private readonly bookingService: BookingsService,
        private readonly snackbar: SnackbarNotificationService,
        private readonly lookupService: AllLookupsService,
        private readonly usersService: UsersService,
        protected readonly onDestroy$: NgOnDestroy
    ) {
        super(dialog, onDestroy$, authService);
        this.pagedRequest = <PagedRequest>{
            pageNumber: 1,
            pageSize: this.pageSize,
            orderBy: 'dateFrom',
            ascending: true
        };

        this.columnDefs = [
            <ColumnDef>{
                id: 'email',
                name: 'Client Email',
                sortable: true,
                columnToMap: 'Client.Email',
                useInSearch: true,
                showsStandardText: true,
                useSpecificColumnForSort: true
            },
            <ColumnDef>{
                id: 'firstName',
                name: 'Client First Name',
                sortable: true,
                columnToMap: 'Client.FirstName',
                useInSearch: true,
                useSpecificColumnForSort: true
            },
            <ColumnDef>{
                id: 'lastName',
                name: 'Client Last Name',
                sortable: true,
                columnToMap: 'Client.LastName',
                useInSearch: true,
                useSpecificColumnForSort: true
            },
            <ColumnDef>{
                id: 'phone',
                name: 'Client Phone'
            },
            <ColumnDef>{
                id: 'dateFrom',
                name: 'Date From',
                format: (val: Date) => TimeUtils.toMonthNameAndTime(val),
                sortable: true,
                columnToMap: 'DateFrom'
            },
            <ColumnDef>{
                id: 'dateTo',
                name: 'Date To',
                format: (val: Date) => TimeUtils.toMonthNameAndTime(val),
                sortable: true,
                columnToMap: 'DateFrom'
            },
            <ColumnDef>{
                id: 'service',
                name: 'Service',
                sortable: true,
                columnToMap: 'Service.Name',
                useInSearch: true,
                useSpecificColumnForSort: true
            },
            <ColumnDef>{
                id: 'specialistFirstName',
                name: 'Specialist First Name',
                sortable: true,
                columnToMap: 'Specialist.FirstName',
                useInSearch: true,
                useSpecificColumnForSort: true
            },
            <ColumnDef>{
                id: 'specialistLastName',
                name: 'Specialist Last Name',
                sortable: true,
                columnToMap: 'Specialist.LastName',
                useInSearch: true,
                useSpecificColumnForSort: true
            },
            <ColumnDef>{
                id: 'stateId',
                name: 'Booking Status',
                sortable: true,
                columnToMap: 'State',
                alternativeColumnToDisplay: 'state',
                useSpecificColumnForSort: true
            }
        ]
    }

    ngOnInit(): void {
        super.ngOnInit();
        this.lookupService.getBookingStates().then((states) => this.bookingStates = states);
    }

    protected fetchData(request: PagedRequest) {
        this.bookings$ = this.bookingService.getPaged(this.companyId, this.pagedRequest).pipe(
            takeUntil(this.onDestroy$),
            tap((x) => this.totalItems$.next(x.totalCount)),
            map((x) => x.data),
            shareReplay()
        );
    }

    openDialog(bookingId: number): void {
        if(bookingId === 0){
            this.openAddDialog();
            return;
        }

        this.openEditDialog(bookingId);
    }

    private openAddDialog(): void {
        const dialogRef = this.dialog.open(BookingFormComponent, {
            disableClose: true,
            width: '500px',
            height: '620px'
        });

        dialogRef.afterClosed().pipe(
            takeUntil(this.onDestroy$),
            tap((res) => res ? this.isLoading = true : false),
            filter(res => res)
        ).subscribe(() => {
            this.fetchData(this.pagedRequest);
            this.isLoading = false;
        }, (error: HttpErrorResponse) => {
            this.snackbar.openErrorWithResponseMessage('Error loading data.', error);
            this.isLoading = false;
        });
    }

    private openEditDialog(bookingId: number): void {
        this.bookingService.getBookingById(bookingId).toPromise().then( async (booking) => {
            if(! booking){
                this.snackbar.openError('Could not get the booking');
                return;
            }

            const specialistInfo = await this.usersService.getBriefInfo(booking.specialistId).toPromise();

            if(! specialistInfo) {
                this.snackbar.openError('Could not load data.');
                return;
            }
            const bookingModel: BookingCalendarEventModel = BookingCalendarEventModel.fromBooking(booking);
            bookingModel.state = this.bookingStates.find(x => x.id === booking.state);

            this.dialog.open(EditBookingFormComponent, {
                disableClose: true,
                width: '500px',
                height: '620px',
                data: {
                    positionId: specialistInfo?.positionId,
                    booking: bookingModel,
                    readonly: false
                }
            }).afterClosed().pipe(
                takeUntil(this.onDestroy$),
                tap((res) => res ? this.isLoading = true : false),
                filter(res => res)
            ).subscribe(() => {
                this.fetchData(this.pagedRequest);
                this.isLoading = false;
            }, (error: HttpErrorResponse) => {
                this.snackbar.openErrorWithResponseMessage('Error loading data.', error);
                this.isLoading = false;
            });
        });
    }

    deleteBooking(bookingId: number): void {
        this.confirmDeletion('Are you sure you want to delete this booking?', 'Delete booking event').then((res) => {
            if(res){
                this.bookingService.delete(bookingId).pipe(takeUntil(this.onDestroy$), tap(() => this.isLoading = true))
                    .subscribe(() => {
                        this.fetchData(this.pagedRequest);
                        this.isLoading = false;
                        this.snackbar.openSuccess('Booking event deleted');
                    }, (error: HttpErrorResponse) => {
                        this.snackbar.openErrorWithResponseMessage('Could not delete booking event.', error);
                    });
            }
        })
    }
}
