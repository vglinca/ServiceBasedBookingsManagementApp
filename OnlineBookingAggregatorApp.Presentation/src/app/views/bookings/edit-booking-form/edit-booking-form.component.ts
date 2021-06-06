import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from '@angular/material/dialog';
import {ServicesService} from '../../../services/services.service';
import {AllLookupsService} from '../../../services/all-lookups.service';
import {SelectionViewModel} from '../../../models/selection-view.model';
import {combineLatest, forkJoin, Observable} from 'rxjs';
import {
    BookingCalendarEventModel,
    BookingStateModel,
    BookingUpdateModel,
    ClientForSelectModel,
    ColourModel,
    EmployeeSelectionModel,
    PositionModel,
    ServiceForSelectModel
} from '../../../models';
import {Select} from '@ngxs/store';
import {CurrentUserState} from '../../../store/current-user.state';
import {NgOnDestroy} from '../../../services/on-destroy.service';
import {filter, switchMap, takeUntil, tap} from 'rxjs/operators';
import {fromPromise} from 'rxjs/internal-compatibility';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {EmployeesService} from '../../../services/employees.service';
import {PositionsService} from '../../../services/positions.service';
import {MatSelectChange} from '@angular/material/select';
import {ClientsService} from '../../../services/clients.service';
import {BookingState} from '../../../enums/booking-state';
import {BookingsService} from '../../../services/bookings.service';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {HttpErrorResponse} from '@angular/common/http';
import {ConfirmationDialogComponent} from '../../../shared/components/confirmation-dialog/confirmation-dialog.component';
import {ConfirmationDialogDataModel} from '../../../models/confirmation-dialog-data.model';
import {TimeUtils} from '../../../utils/time.utils';
import {AuthService} from '../../../services/auth.service';
import {Policy} from '../../../enums/policy';

@Component({
    selector: 'app-edit-booking-form',
    templateUrl: './edit-booking-form.component.html',
    styleUrls: ['./edit-booking-form.component.scss'],
    providers: [NgOnDestroy]
})
export class EditBookingFormComponent implements OnInit {

    @Select(CurrentUserState.getCompanyId) companyId$: Observable<number>;
    @Select(CurrentUserState.userId) userId$: Observable<number>;
    @Select(CurrentUserState.getBriefInfo) userBriefInfo$: Observable<EmployeeSelectionModel>;

    public readonly Policy = Policy;

    public hourList: SelectionViewModel[] = [];
    public minutesList: SelectionViewModel[] = [];
    public colours: ColourModel[] = [];
    public companyId: number;
    public form: FormGroup;

    public services: ServiceForSelectModel[] = [];
    public filteredServices: ServiceForSelectModel[] = [];
    public employees: EmployeeSelectionModel[] = [];
    public filteredEmployees: EmployeeSelectionModel[] = [];
    public positions: PositionModel[] = [];

    public bookingStates$: Observable<BookingStateModel[]>;
    public clients$: Observable<ClientForSelectModel[]>;
    selectedBookingState: BookingState;

    public getColour(id: number): ColourModel {
        if(!id){
            return null;
        }
        return this.colours.find(x => x.id === id);
    }

    constructor(
        @Inject(MAT_DIALOG_DATA) public data : {positionId: number, booking: BookingCalendarEventModel, readonly: boolean},
        private readonly dialogRef: MatDialogRef<EditBookingFormComponent>,
        private readonly authService: AuthService,
        private readonly bookingService: BookingsService,
        private readonly serviceClient: ServicesService,
        private readonly employeeService: EmployeesService,
        private readonly positionService: PositionsService,
        private readonly lookupService: AllLookupsService,
        private readonly clientService: ClientsService,
        private readonly snackbar: SnackbarNotificationService,
        private readonly onDestroy$: NgOnDestroy,
        private readonly dialog: MatDialog,
        private readonly fb: FormBuilder
    ) {
        this.selectedBookingState = this.data.booking.state.id;
        for(let i = 0; i < 24; i++){
            this.hourList.push({id: i, name: i.toString().padStart(2, '0')});
        }
        for(let i = 0; i < 60; i +=15){
            this.minutesList.push({id: i, name: i.toString().padStart(2, '0')});
        }
    }

    ngOnInit(): void {
        this.initForm();
        this.lookupService.getBookingColours().then(c => {
            this.colours = c;
        });
        this.bookingStates$ = fromPromise(this.lookupService.getBookingStates());

        if(this.authService.userHasPermission(Policy.EditUnrelatedBookings)){
            this.companyId$.pipe(
                takeUntil(this.onDestroy$),
                tap((compId: number) => this.clients$ = this.clientService.getForSelect(compId)),
                tap((compId: number) => this.companyId = compId),
                switchMap((compId: number) => forkJoin([
                    this.serviceClient.getForSelect(compId),
                    this.employeeService.getForSelect(compId),
                    this.positionService.getPositionsForSelect(compId)
                ])),
            ).pipe(takeUntil(this.onDestroy$))
                .subscribe(([services, employees, positions]) => {
                    this.initArrays(services, employees, positions);
                });

            return;
        }

        combineLatest([
            this.userBriefInfo$.pipe(takeUntil(this.onDestroy$)),
            this.userId$.pipe(
                takeUntil(this.onDestroy$),
                switchMap((userId: number) => this.serviceClient.getForSelectBySpecialist(userId)),
            ),
            this.companyId$.pipe(
                takeUntil(this.onDestroy$),
                tap((compId: number) => this.clients$ = this.clientService.getForSelect(compId))
            )
        ]).pipe(takeUntil(this.onDestroy$)).subscribe(([userInfo, services, companyId]) => {
            this.companyId = companyId;
            this.employees.push(userInfo);
            this.services = services;
            this.filteredServices = services;
            this.form.get('specialistId').patchValue(userInfo.id);
            this.form.get('positionId').patchValue(userInfo.positionId);
        }, () => {}, () => console.log('Complete'));
    }

    private initForm(): void {
        this.form = this.fb.group({
            clientId: new FormControl({value: this.data.booking.clientId, disabled: this.data.readonly}, [Validators.required]),
            serviceId: new FormControl({value: this.data.booking.serviceId, disabled: this.data.readonly}, [Validators.required]),
            positionId: new FormControl({value: this.data.positionId || null, disabled: this.data.readonly}),
            specialistId: new FormControl({value: this.data.booking.specialistId || null, disabled: this.data.readonly}, [Validators.required]),
            colourId: new FormControl({value: this.data.booking.colourId || null, disabled: this.data.readonly}),
            bookingDate: new FormControl({value: this.data.booking.dateFrom, disabled: this.data.readonly}, [Validators.required]),
            hourFrom: new FormControl({value: new Date(this.data.booking.dateFrom).getHours(), disabled: this.data.readonly}, [Validators.required]),
            minutesFrom: new FormControl({value: new Date(this.data.booking.dateFrom).getMinutes(), disabled: this.data.readonly}, [Validators.required]),
            hourTo: new FormControl({value: new Date(this.data.booking.dateTo).getHours(), disabled: this.data.readonly}, [Validators.required]),
            minutesTo: new FormControl({value: new Date(this.data.booking.dateTo).getMinutes(), disabled: this.data.readonly}, [Validators.required]),
            comments: new FormControl({value: this.data.booking.comments || null, disabled: this.data.readonly})
        });
    }

    private initArrays(services: ServiceForSelectModel[], employees: EmployeeSelectionModel[], positions: PositionModel[]): void {
        this.positions = positions;
        this.services = services;
        this.employees = employees;
        this.filteredEmployees = employees.filter(x => x.positionId === this.data.positionId);
        this.filteredServices = services;
    }

    positionChanged($event: MatSelectChange): void {
        this.filteredEmployees = [];
        this.filteredEmployees = this.employees.filter(x => x.positionId === $event.value);
    }

    employeeChanged($event: MatSelectChange): void {
        this.filteredServices = [];
        this.filteredServices = this.services
            .filter(x => this.filteredEmployees
                .find(y => y.id === $event.value)?.servicesIds.includes(x.id));
    }

    submit(): void {
        if(this.data.readonly){
            return;
        }
        const model: BookingUpdateModel = <BookingUpdateModel>{
            ...this.form.getRawValue(),
            dateFrom: TimeUtils.normalizeDate(new Date(this.form.controls['bookingDate'].value)),
            dateTo: TimeUtils.normalizeDate(new Date(this.form.controls['bookingDate'].value)),
            state: this.selectedBookingState,
            colour: this.form.controls['colourId'].value
        };

        this.bookingService.updateBooking(this.data.booking.id, model).pipe(takeUntil(this.onDestroy$))
            .subscribe(() => {
                this.snackbar.openSuccess('Booking updated');
                this.dialogRef.close(true);
            }, (error: HttpErrorResponse) =>
                this.snackbar.openErrorWithResponseMessage('Update failed', error));
    }

    cancel(): void {
        this.dialogRef.close(false);
    }

    stateChange(id: number): void {
        this.selectedBookingState = id;
    }

    onDelete(): void {
        const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
            disableClose: true,
            data: <ConfirmationDialogDataModel>{
                isWarning: true,
                title: 'Delete Booking',
                okButtonText: 'Yes',
                cancelButtonText: 'No',
                message: 'Are you sure you want to delete this booking?'
            }});

        dialogRef.afterClosed().pipe(
            takeUntil(this.onDestroy$),
            filter(x => x),
            switchMap(() => this.bookingService.delete(this.data.booking.id))
        ).subscribe(() => {
            this.snackbar.openSuccess('Booking deleted.');
            this.dialogRef.close(true);
        }, (error: HttpErrorResponse) => {
            this.snackbar.openErrorWithResponseMessage('Delete failed', error);
            this.dialogRef.close(false);
        });
    }
}
