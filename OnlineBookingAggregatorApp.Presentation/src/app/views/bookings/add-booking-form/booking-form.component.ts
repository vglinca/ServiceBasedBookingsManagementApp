import {AfterViewInit, Component, Inject, OnInit} from '@angular/core';
import {AbstractControl, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {combineLatest, concat, Observable, ReplaySubject} from 'rxjs';
import {Select} from '@ngxs/store';
import {CurrentUserState} from '../../../store/current-user.state';
import {BookingCreateModel, ClientForSelectModel, ColourModel, EmployeeSelectionModel, ServiceForSelectModel} from '../../../models';
import {NgOnDestroy} from '../../../services/on-destroy.service';
import {concatMap, filter, map, switchMap, takeUntil, tap} from 'rxjs/operators';
import {ClientsService} from '../../../services/clients.service';
import {ServicesService} from '../../../services/services.service';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE} from '@angular/material/core';
import {MomentDateAdapter} from '@angular/material-moment-adapter';
import {AllLookupsService} from '../../../services/all-lookups.service';
import {fromPromise} from 'rxjs/internal-compatibility';
import {EmployeesService} from '../../../services/employees.service';
import {TimeUtils} from '../../../utils/time.utils';
import {BookingsService} from '../../../services/bookings.service';
import {SelectionViewModel} from '../../../models/selection-view.model';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {HttpErrorResponse} from '@angular/common/http';
import {MatSelectChange} from '@angular/material/select';
import {Policy} from '../../../enums/policy';
import {AuthService} from '../../../services/auth.service';
import * as signalR from '@aspnet/signalr';
import {environment} from '../../../../environments/environment';
import {NotificationsService} from '../../../services/notifications.service';
import {NotificationCreateModel} from '../../../models/notification/notification-create.model';
import {SignalrHubService} from '../../../services/signalr-hub.service';

export const MY_FORMATS = {
    parse: {
        dateInput: 'LL'
    },
    display: {
        dateInput: 'YYYY/MM/DD',
        monthYearLabel: 'YYYY',
        dateA11yLabel: 'LL',
        monthYearA11yLabel: 'YYYY'
    }
};

@Component({
    selector: 'booking-form',
    templateUrl: './booking-form.component.html',
    styleUrls: ['./booking-form.component.scss'],
    providers: [
        { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
        { provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
        NgOnDestroy
    ]
})
export class BookingFormComponent implements OnInit, AfterViewInit {

    public readonly Policy = Policy;
    public editing: boolean = false;
    public companyId: number;
    public userId: number;
    public hubConnection: signalR.HubConnection;

    public clientsSearchControl: FormControl = new FormControl();
    public servicesSearchControl: FormControl = new FormControl();
    public employeesSearchControl: FormControl = new FormControl();

    public bookingForm: FormGroup;
    public clientForm: FormGroup;
    public selectedDate: Date;
    public hourList: SelectionViewModel[] = [];
    public minutesList: SelectionViewModel[] = [];

    private clients: ClientForSelectModel[] = [];
    private services: ServiceForSelectModel[] = [];
    private employees: EmployeeSelectionModel[] = [];
    private filteredEmployees: EmployeeSelectionModel[] = [];
    public colours: ColourModel[] = [];

    public clients$: ReplaySubject<ClientForSelectModel[]> = new ReplaySubject<ClientForSelectModel[]>(1);
    public services$: ReplaySubject<ServiceForSelectModel[]> = new ReplaySubject<ServiceForSelectModel[]>(1);
    public employees$: ReplaySubject<EmployeeSelectionModel[]> = new ReplaySubject<EmployeeSelectionModel[]>(1);

    @Select(CurrentUserState.getCompanyId) companyId$: Observable<number>;
    @Select(CurrentUserState.userId) userId$: Observable<number>;
    @Select(CurrentUserState.getBriefInfo) currentUserInfo$: Observable<EmployeeSelectionModel>;

    public clientPhoneNumber: string;

    public getColour(id: number): ColourModel {
        return this.colours.find(x => x.id === id);
    }

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {selectedDate: Date},
        public dialogRef: MatDialogRef<BookingFormComponent>,
        private readonly authService: AuthService,
        private readonly clientsService: ClientsService,
        private readonly servicesService: ServicesService,
        private readonly lookupService: AllLookupsService,
        private readonly employeeService: EmployeesService,
        private readonly bookingService: BookingsService,
        private readonly notificationService: NotificationsService,
        private readonly hubService: SignalrHubService,
        private readonly onDestroy$: NgOnDestroy,
        private readonly formBuilder: FormBuilder,
        private readonly snackbar: SnackbarNotificationService
    ) {
        this.selectedDate = this.data?.selectedDate;
        for(let i = 0; i < 24; i++){
            this.hourList.push({id: i, name: i.toString().padStart(2, '0')});
        }
        for(let i = 0; i < 60; i +=15){
            this.minutesList.push({id: i, name: i.toString().padStart(2, '0')});
        }

        this.userId$.pipe(takeUntil(this.onDestroy$), filter((x: number) => !isNaN(x)))
            .subscribe(userId => this.userId = userId);
    }

    ngOnInit(): void {
        this.hubConnection = this.hubService.getConnection();
        this.initForms();

        let fetchedData$: Observable<[
            colours: ColourModel[],
            client: ClientForSelectModel[],
            services: ServiceForSelectModel[],
            employees: EmployeeSelectionModel[],
            companyId: number
        ]>;

        if(this.authService.userHasPermission(Policy.CreateUnrelatedBookings)){
            fetchedData$ = combineLatest([
                fromPromise(this.lookupService.getBookingColours()),
                this.companyId$.pipe(takeUntil(this.onDestroy$), filter((x: number) => !isNaN(x)),
                    switchMap((companyId: number) => this.clientsService.getForSelect(companyId))
                ), this.companyId$.pipe(takeUntil(this.onDestroy$), filter((x: number) => !isNaN(x)),
                    switchMap((companyId: number) => this.servicesService.getForSelect(companyId))),
                this.companyId$.pipe(takeUntil(this.onDestroy$), filter((x: number) => !isNaN(x)),
                    switchMap((id) => this.employeeService.getForSelect(id))),
                this.companyId$.pipe(takeUntil(this.onDestroy$))
            ]);
        } else {
            fetchedData$ = combineLatest([
                fromPromise(this.lookupService.getBookingColours()),
                this.companyId$.pipe(takeUntil(this.onDestroy$), filter((x: number) => !isNaN(x)),
                    switchMap((companyId: number) => this.clientsService.getForSelect(companyId))),
                this.userId$.pipe(takeUntil(this.onDestroy$), filter((x: number) => !isNaN(x)),
                    tap((userId: number) => this.bookingForm.get('specialistId').patchValue(userId)),
                    switchMap((userId: number) => this.servicesService.getForSelectBySpecialist(userId))),
                this.currentUserInfo$.pipe(takeUntil(this.onDestroy$), map((data) => [data])),
                this.companyId$.pipe(takeUntil(this.onDestroy$))
            ]);
        }

        fetchedData$.pipe(takeUntil(this.onDestroy$))
            .subscribe(([colours, clients, services,
                            employees, companyId]) => {
                this.services$.next(services);
                this.employees$.next(employees);
                this.clients$.next(clients);
                this.colours = colours;
                this.clients = clients;
                this.services = services;
                this.employees = employees;
                this.filteredEmployees = employees;
                this.companyId = companyId;
        });
    }

    ngAfterViewInit(): void {
        this.clientsSearchControl.valueChanges.pipe(takeUntil(this.onDestroy$)).subscribe(() => this.filterClients());
        this.servicesSearchControl.valueChanges.pipe(takeUntil(this.onDestroy$)).subscribe(() => this.filterServices());
        this.employeesSearchControl.valueChanges.pipe(takeUntil(this.onDestroy$)).subscribe(() => this.filterEmployees());
    }

    private initiateConnection(): void {
        // this.hubConnection = new signalR.HubConnectionBuilder()
        //     .withUrl(`${environment.apiBaseUrl}/notificationsHub`, {
        //         accessTokenFactory: () => this.authService.getAccessToken()
        //     }).build();
        //
        // this.hubConnection.start().then(() => console.log('Hub connection established.')).catch((err) => console.log(err));
    }

    onServiceChange($event: MatSelectChange): void {
        this.filteredEmployees = [];
        this.filteredEmployees = this.employees.filter(x => x.servicesIds.includes($event.value));
        this.employees$.next(this.filteredEmployees);
    }

    private initForms(): void {
        this.bookingForm = this.formBuilder.group({
            serviceId: new FormControl(null, [Validators.required]),
            specialistId: new FormControl(null, [Validators.required]),
            bookingDate: new FormControl(this.selectedDate || null, [Validators.required]),
            hourFrom: new FormControl(this.selectedDate?.getHours() || 0, [Validators.required]),
            minutesFrom: new FormControl(this.selectedDate?.getMinutes() || 0, [Validators.required]),
            hourTo: new FormControl(null, [Validators.required]),
            minutesTo: new FormControl(null, [Validators.required]),
            comments: new FormControl(null),
            colour: new FormControl(null)
        }, {
            validator: this.toDateGreaterThanFromDate
        });
        this.clientForm = this.formBuilder.group({
            clientId: new FormControl(null),
            clientFirstName: new FormControl(null),
            clientLastName: new FormControl(null),
            clientEmail: new FormControl(null),
            // clientPhone: new FormControl(null)
        }, {validator: this.clientIdRequiredWhenClientInfoIsNull});
    }

    private clientIdRequiredWhenClientInfoIsNull(control: AbstractControl) {
        const clientId: number = control.get('clientId').value;
        const fName: string = control.get('clientFirstName').value;
        const lName: string = control.get('clientLastName').value;
        const email: string = control.get('clientEmail').value;
        // const phone: string = control.get('clientPhone').value;

        if(clientId === null && fName === null && lName === null && email === null) {
            control.get('clientId').setErrors({required: true});
            return;
        }
    }

    private toDateGreaterThanFromDate(control: AbstractControl){
        const hourFrom: number = control.get('hourFrom').value;
        const hourTo: number = control.get('hourTo').value;
        const minutesFrom: number = control.get('minutesFrom').value;
        const minutesTo: number = control.get('minutesTo').value;

        if(hourFrom === hourTo && minutesTo <= minutesFrom){
            control.get('minutesTo').setErrors({notGreaterThanMinutesFrom: true});
            return;
        }

        if(hourTo < hourFrom){
            control.get('hourTo').setErrors({notGreaterThanHourFrom: true});
        }
    }

    private filterClients(): void {
        if(!this.clients || this.clients.length === 0){
            return;
        }

        let search: string = this.clientsSearchControl.value;
        if(!search){
            this.clients$.next(this.clients);
            return;
        }

        this.clients$.next(this.clients.filter(x =>
            x.fullName.toLowerCase().indexOf(search.toLowerCase()) > -1 ||
            x.email.toLowerCase().indexOf(search.toLowerCase()) > -1 ||
            x.phone.toLowerCase().indexOf(search.toLowerCase()) > -1)
        );
    }

    private filterServices(): void {
        if(!this.services || this.services.length === 0){
            return;
        }

        let search: string = this.servicesSearchControl.value;
        if(!search){
            this.services$.next(this.services);
            return;
        }

        this.services$.next(this.services.filter(x => x.name.toLowerCase().indexOf(search.toLowerCase()) > -1));
    }

    private filterEmployees(): void {
        if(!this.employees || this.employees.length === 0){
            return;
        }

        let search: string = this.employeesSearchControl.value;
        if(!search){
            this.employees$.next(this.employees);
            return;
        }

        this.employees$.next(this.filteredEmployees.filter(x => x.fullName.toLowerCase().indexOf(search.toLowerCase()) > -1));
    }

    submit(): void {
        if(!this.clientPhoneNumber && !this.clientForm.get('clientEmail').value && !this.clientForm.get('clientId').value){
            return;
        }
        const dateFrom: Date = TimeUtils.normalizeDate(new Date(this.bookingForm.controls['bookingDate'].value));
        const hourFrom: number = this.bookingForm.controls['hourFrom'].value;
        const minutesFrom: number = this.bookingForm.controls['minutesFrom'].value;

        const dateTo: Date = TimeUtils.normalizeDate(new Date(this.bookingForm.controls['bookingDate'].value));
        const hourTo: number = this.bookingForm.controls['hourTo'].value;
        const minutesTo: number = this.bookingForm.controls['minutesTo'].value;

        const model: BookingCreateModel = <BookingCreateModel>{
            ...this.clientForm.getRawValue(),
            ...this.bookingForm.getRawValue(),
            clientPhone: this.clientPhoneNumber,
            hourFrom: hourFrom,
            minutesFrom: minutesFrom,
            hourTo: hourTo,
            minutesTo: minutesTo,
            dateFrom: dateFrom,
            dateTo: dateTo,
            colourId: this.bookingForm.controls['colour'].value
        };

        if(this.userId === model.specialistId){
            this.bookingService.addBooking(this.companyId, model).subscribe((id) => {
                this.dialogRef.close(true);
                this.snackbar.openSuccess(`Booking for ${this.clients.find(x => x.id === model.clientId)?.fullName || model.clientEmail} has been added.`);
            }, (error: HttpErrorResponse) => {
                this.snackbar.openErrorWithResponseMessage('Could not add a booking.', error);
            });

            return;
        }

        const notification = <NotificationCreateModel>{
            receiverId: model.specialistId,
            title: `New booking assigned`,
            message: `Booking is set for ${this.clients.find(x => x.id === model.clientId)?.fullName || model.clientEmail} at time ${model.dateFrom} ${model.hourFrom}:${model.minutesFrom} - ${model.dateTo} ${model.hourTo}:${model.minutesTo}`
        };

        this.bookingService.addBooking(this.companyId, model).pipe(
            concatMap(() => this.notificationService.add(notification))
        ).subscribe(() => {
            this.hubConnection.invoke('Notify', notification.receiverId.toString(), notification.message);
            this.dialogRef.close(true);
            this.snackbar.openSuccess(`Booking for ${this.clients.find(x => x.id === model.clientId)?.fullName || model.clientEmail} has been added.`);
        }, (error: HttpErrorResponse) => {
            this.snackbar.openErrorWithResponseMessage('Could not add a booking.', error);
        });
    }

    cancel(): void {
        this.dialogRef.close(false);
    }
}
