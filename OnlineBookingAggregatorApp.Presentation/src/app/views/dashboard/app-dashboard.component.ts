import {AfterViewInit, ChangeDetectionStrategy, Component, HostListener, OnInit, ViewEncapsulation} from '@angular/core';
import {combineLatest, forkJoin, Observable, Subject} from 'rxjs';
import {
    CalendarDateFormatter,
    CalendarEvent,
    CalendarEventTimesChangedEvent,
    CalendarView,
    CalendarWeekViewBeforeRenderEvent
} from 'angular-calendar';
import {endOfMonth, endOfWeek, isSameDay, isSameMonth, startOfMonth, startOfWeek,} from 'date-fns';
import {CustomDateFormatterService} from '../../services/custom-date-formatter.service';
import {MatDialog} from '@angular/material/dialog';
import {BookingFormComponent} from '../bookings/add-booking-form/booking-form.component';
import {CurrentUserState} from '../../store/current-user.state';
import {Select, Store} from '@ngxs/store';
import {SetDashboardCalendarView} from '../../store/current-user.actions';
import {NgOnDestroy} from '../../services/on-destroy.service';
import {concatMap, debounceTime, filter, map, switchMap, takeUntil, tap} from 'rxjs/operators';
import {PositionsService} from '../../services/positions.service';
import {
    BookingCalendarEventModel,
    BookingModel,
    BookingStateModel,
    BookingUpdateModel,
    EmployeeSelectionModel,
    GetBookingsForDashboardInputModel,
    PositionModel
} from '../../models';
import {FormControl} from '@angular/forms';
import {EmployeesService} from '../../services/employees.service';
import {MatSelectChange} from '@angular/material/select';
import {BookingsService} from '../../services/bookings.service';
import {HttpErrorResponse} from '@angular/common/http';
import {DashboardCalendarState} from '../../store/dashboard-calendar.state';
import {CalendarActions} from '../../store/dashboard-calendar.actions';
import {SnackbarNotificationService} from '../../services/snackbar-notification.service';
import {TimeUtils} from '../../utils/time.utils';
import {EditBookingFormComponent} from '../bookings/edit-booking-form/edit-booking-form.component';
import {MonthViewDay} from 'calendar-utils';
import {DayBookingsDetailsComponent} from './day-bookings-details/day-bookings-details.component';
import {ConfirmationDialogComponent} from '../../shared/components/confirmation-dialog/confirmation-dialog.component';
import {AllLookupsService} from '../../services/all-lookups.service';
import {WorkSchedulesService} from '../../services/work-schedules.service';
import {WeekDayWorkHoursModel} from '../../models/work-schedule/week-day-work-hours.model';
import {DayViewSchedulerHourColumn} from './day-view-scheduler/day-view-scheduler.component';
import {AuthService} from '../../services/auth.service';
import {Policy} from '../../enums/policy';

@Component({
    selector: 'app-dashboard-component',
    changeDetection: ChangeDetectionStrategy.OnPush,
    encapsulation: ViewEncapsulation.None,
    templateUrl: './app-dashboard.component.html',
    styleUrls: ['./app-dashboard.component.scss'],
    providers: [
        {
            provide: CalendarDateFormatter,
            useClass: CustomDateFormatterService,
        },
        NgOnDestroy
    ]
})
export class AppDashboardComponent implements OnInit, AfterViewInit {

    @Select(CurrentUserState.getCalendarView) calendarView$: Observable<CalendarView>;
    @Select(CurrentUserState.getCompanyId) companyId$: Observable<number>;
    @Select(CurrentUserState.userId) userId$: Observable<number>;
    @Select(CurrentUserState.getBriefInfo) userInfo$: Observable<EmployeeSelectionModel>;
    @Select(DashboardCalendarState.getViewDate) viewDate$: Observable<Date>;
    @Select(DashboardCalendarState.getSelectedPosition) selectedPositionId$: Observable<number>;
    @Select(DashboardCalendarState.getSelectedEmployees) selectedEmployeeIds$: Observable<number[]>;
    @Select(DashboardCalendarState.getPositions) positions$: Observable<PositionModel[]>;

    public refresh$: Subject<void> = new Subject<void>();
    public bookingsEvents$: Subject<CalendarEvent<BookingCalendarEventModel>[]> = new Subject<CalendarEvent<BookingCalendarEventModel>[]>();
    public events$: Observable<CalendarEvent<BookingCalendarEventModel>[]> = this.bookingsEvents$.asObservable();

    public bookingEvents: CalendarEvent<BookingCalendarEventModel>[] = [];
    public employeesWorkHours: WeekDayWorkHoursModel[] = [];
    public employees: EmployeeSelectionModel[] = [];
    public employeesByPosition: EmployeeSelectionModel[] = [];
    public selectedEmployees: EmployeeSelectionModel[] = [];
    public selectedEmployeeIds: number[] = [];
    public positions: PositionModel[] = [];
    public bookings: BookingModel[] = [];
    public bookingStates: BookingStateModel[] = [];
    public companyId: number;
    public userId: number = -1;
    public selectedPositionId: number;
    public isLoading: boolean = true;
    public positionCtrl: FormControl = new FormControl();
    public employeesCtrl: FormControl = new FormControl();
    public locale: string = 'md';
    public view: CalendarView;
    public CalendarView = CalendarView;
    public viewDate: Date = new Date();
    public calendarDate: Date = new Date();
    public activeDayIsOpen: boolean = true;
    public showCalendarActionButtons: boolean = true;
    public query: GetBookingsForDashboardInputModel;
    public currentUserBriefInfo: EmployeeSelectionModel;
    public readonly Policy = Policy;

    public readonly timeSwitchButtonsState: number[] = [0, 1, 0];

    public setTimeSwitchButton(index: number): void {
        const activeIndex = this.timeSwitchButtonsState.indexOf(this.timeSwitchButtonsState.find(x => x === 1));
        this.timeSwitchButtonsState[activeIndex] = 0;
        this.timeSwitchButtonsState[index] = 1;
    }

    public getTimeSwitchButtonState(index: number): number {
        return this.timeSwitchButtonsState[index];
    }

    constructor(
        public dialog: MatDialog,
        private readonly store: Store,
        private readonly onDestroy$: NgOnDestroy,
        private readonly positionsService: PositionsService,
        private readonly employeeService: EmployeesService,
        private readonly bookingService: BookingsService,
        private readonly lookupService: AllLookupsService,
        private readonly workScheduleService: WorkSchedulesService,
        private readonly authService: AuthService,
        private readonly snackbar: SnackbarNotificationService
    ) {}

    public dayIsNotInThePast({date}: {date: Date}): boolean {
        return TimeUtils.normalizeDate(date) >= TimeUtils.normalizeDate(new Date());
    }

    ngOnInit(): void {
        this.lookupService.getBookingStates().then(states => this.bookingStates = states);

        if(this.authService.userHasPermission(Policy.ViewAllBookings)){
            this.fetchDataForAllBookings();
            return;
        }

        this.fetchDataForSingleEmployee();
    }

    ngAfterViewInit(): void {
        this.employeesCtrl.valueChanges.pipe(takeUntil(this.onDestroy$), debounceTime(200)).subscribe((value: number[]) => {
            this.selectedEmployees = this.employeesByPosition.filter(x => value.find(y => y === x.id));
            this.refresh$.next();
        });
    }

    private fetchDataForAllBookings(): void {
        combineLatest([
            this.calendarView$.pipe(takeUntil(this.onDestroy$)),
            this.viewDate$.pipe(takeUntil(this.onDestroy$)),
            this.selectedPositionId$.pipe(takeUntil(this.onDestroy$)),
            this.selectedEmployeeIds$.pipe(takeUntil(this.onDestroy$))
        ]).pipe(takeUntil(this.onDestroy$))
            .subscribe(([view, viewDate, posId, empIds]) => {
                this.calendarDate = TimeUtils.normalizeDate(new Date(viewDate));
                this.viewDate = TimeUtils.normalizeDate(new Date(viewDate));
                this.view = view;
                this.refresh$.next();
                this.selectedPositionId = posId;
                this.positionCtrl.setValue(posId);
                this.selectedEmployeeIds = empIds;
            });

        combineLatest([
            this.positions$.pipe(takeUntil(this.onDestroy$)),
            this.companyId$.pipe(takeUntil(this.onDestroy$), filter(x => x != undefined),
                switchMap((id: number) => this.employeeService.getForSelect(id))
            ), this.companyId$.pipe(takeUntil(this.onDestroy$), filter(x => x != undefined))]
        ).pipe(tap(() => this.isLoading = true), takeUntil(this.onDestroy$),
            concatMap(([positions, employees, companyId]) => {
                this.assignNecessaryValues(positions, employees, companyId);
                const dates = this.getCalendarDateRange();
                this.query = new GetBookingsForDashboardInputModel(this.companyId, this.employeesByPosition.map(x => x.id),
                    dates.dateFrom, dates.dateTo, this.view === CalendarView.Day);
                return forkJoin([
                    this.bookingService.getForDashboard(this.query)
                        .pipe(takeUntil(this.onDestroy$), map((bookings) => this.createCalendarEventsFromBookings(bookings))),
                    this.workScheduleService.getEmployeesWorkHours(employees.map(x => x.id)).pipe(takeUntil(this.onDestroy$))
                ]);
            })).pipe(takeUntil(this.onDestroy$)).subscribe(([bookings, workHours]) => {
                this.employeesWorkHours = workHours;
                this.bookingEvents = bookings;
                this.bookingsEvents$.next(this.bookingEvents);
                this.refresh$.next();
                this.isLoading = false;
        }, (error: HttpErrorResponse) => {
            this.snackbar.openErrorWithResponseMessage('Filed to load bookings.', error);
            this.isLoading = false;
        });
    }

    private fetchDataForSingleEmployee(): void {
        this.isLoading = true;
        combineLatest([
            this.calendarView$.pipe(takeUntil(this.onDestroy$)),
            this.viewDate$.pipe(takeUntil(this.onDestroy$)),
            this.userId$.pipe(takeUntil(this.onDestroy$), filter(x => x > 0)),
            this.userInfo$.pipe(takeUntil(this.onDestroy$), filter(x => x != undefined))
        ]).pipe(takeUntil(this.onDestroy$))
            .subscribe(([view, viewDate, userId, userInfo]) => {
                this.calendarDate = TimeUtils.normalizeDate(new Date(viewDate));
                this.viewDate = TimeUtils.normalizeDate(new Date(viewDate));
                this.view = view;
                this.currentUserBriefInfo = userInfo;
                this.refresh$.next();
                this.userId = userId;
            });

        this.selectedEmployees.push(this.currentUserBriefInfo);

        this.companyId$.pipe(
            takeUntil(this.onDestroy$), filter(x => x != undefined),
            switchMap((companyId: number) => {
                this.companyId = companyId;
                const dates = this.getCalendarDateRange();
                this.query = new GetBookingsForDashboardInputModel(this.companyId, [this.userId],
                    dates.dateFrom, dates.dateTo, this.view === CalendarView.Day);
                return forkJoin([
                    this.bookingService.getForDashboard(this.query)
                        .pipe(takeUntil(this.onDestroy$), map((bookings) => this.createCalendarEventsFromBookings(bookings))),
                    this.workScheduleService.getEmployeesWorkHours([this.userId]).pipe(takeUntil(this.onDestroy$))
                ])
            })
        ).subscribe(([bookings, workHours]) => {
            this.employeesWorkHours = workHours;
            this.bookingEvents = bookings;
            this.bookingsEvents$.next(this.bookingEvents);
            this.refresh$.next();
            this.isLoading = false;
        }, (error: HttpErrorResponse) => {
            this.snackbar.openErrorWithResponseMessage('Filed to load bookings.', error);
            this.isLoading = false;
        });
    }

    beforeMonthViewRender({ body }: {body: MonthViewDay[]}): void {
        body.forEach(day => {
            // const dayNumber: number = day.date.getDate();
            // if(dayNumber % 2 === 0){
            //     day.cssClass = 'even-day';
            // }

            if(this.dayIsNotInThePast(day)){
                day.cssClass += ' day-of-month';
            }

            if(day.badgeTotal > 0){
                day.cssClass += ' day-of-month-no-hover-pointer';
            }
        });
    }

    beforeDayViewRender($event: CalendarWeekViewBeforeRenderEvent) {
        $event.hourColumns.forEach((hourColumn: DayViewSchedulerHourColumn) => {
            const schedule = this.employeesWorkHours.find(x => x.employeeId === hourColumn.employeeId);
            hourColumn.hours.forEach(hour => {
                hour.segments.forEach(segment => {
                    const weekDay = segment.date.getDay();
                    const index: number = segment.date.getHours() * 4 + segment.date.getMinutes() / 15;
                    if(schedule.workHoursMatrix[index][weekDay]){
                        segment.cssClass = 'work-hour-segment';
                    }
                });
            });
        });
    }

    private createCalendarEventsFromBookings(bookings: BookingModel[]): CalendarEvent<BookingCalendarEventModel>[]{
        return bookings.map(b => {
            const specialist = this.employees.find(x => x.id === b.specialistId);
            const be = BookingCalendarEventModel.fromBooking(b, specialist);
            be.state = this.bookingStates.find(x => x.id === b.state);
            return {
                title: `${(be.email ? be.email : `${be.firstName} ${be.lastName}`)}<br>${be.phone}${this.view === CalendarView.Day ? '' : `<br>Specialist: ${be.specialist}`}`,
                start: new Date(be.dateFrom),
                end: new Date(be.dateTo),
                color: be.colour,
                cssClass: 'booking-event',
                resizable: {
                    beforeStart: true,
                    afterEnd: true
                },
                meta: be
            } as CalendarEvent<BookingCalendarEventModel>
        });
    }

    private assignNecessaryValues(positions: PositionModel[] = [], employees: EmployeeSelectionModel[] = [], companyId: number = null): void {
        this.positions = positions;
        this.employeesByPosition = employees.filter(x => x.positionId === this.selectedPositionId);
        this.selectedEmployees = employees.filter(x => x.positionId === this.selectedPositionId);
        this.employees = employees;
        this.companyId = companyId;
        this.positionCtrl.patchValue(this.selectedPositionId);
        this.employeesCtrl.patchValue([...this.employeesByPosition.map(x => x.id)]);
    }

    private prepareFetchBookings(employeeIds: number[] = undefined): void {
        this.isLoading = true;
        const dates = this.getCalendarDateRange();
        const ids: number[] = employeeIds ? employeeIds : this.userId === -1 ? this.employeesByPosition.map(x => x.id) : [this.userId];
        this.query = new GetBookingsForDashboardInputModel(this.companyId, ids,
            dates.dateFrom, dates.dateTo, this.view === CalendarView.Day);
        this.fetchBookings();
    }

    private fetchBookings(): void {
        this.bookingService.getForDashboard(this.query).pipe(
            map((bookings) => this.createCalendarEventsFromBookings(bookings)),
            takeUntil(this.onDestroy$)
        ).subscribe((bookings) => {
                this.bookingEvents = bookings;
                this.bookingsEvents$.next(this.bookingEvents);
                this.refresh$.next();
                this.isLoading = false;
            }, (error: HttpErrorResponse) => {
            this.snackbar.openErrorWithResponseMessage('Filed to load bookings.', error);
                this.isLoading = false;
            });
    }

    private getCalendarDateRange(): {dateFrom: Date, dateTo: Date}{
        let dateFrom: Date;
        let dateTo: Date;
        switch (this.view) {
            case CalendarView.Day:
                dateFrom = this.calendarDate;
                dateTo = this.calendarDate;
                break;
            case CalendarView.Week:
                dateFrom = startOfWeek(this.calendarDate);
                dateTo = endOfWeek(this.calendarDate);
                break;
            case CalendarView.Month:
                dateFrom = startOfMonth(this.calendarDate);
                dateTo = endOfMonth(this.calendarDate);
                break;
        }

        return {dateFrom: dateFrom, dateTo: dateTo};
    }

    dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
        if (isSameMonth(date, this.viewDate)) {
            this.activeDayIsOpen = !((isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) || events.length === 0);
            this.viewDate = date;
        }

        const dialogRef = this.dialog.open(BookingFormComponent, {
            disableClose: true,
            width: '500px',
            height: '750px',
            data: { selectedDate: date }
        });

        dialogRef.afterClosed().pipe(
            takeUntil(this.onDestroy$),
            filter(x => x)
        ).subscribe(() => this.prepareFetchBookings());
    }

    eventTimesChanged({event, newStart, newEnd}: CalendarEventTimesChangedEvent<BookingCalendarEventModel>): void {
        event.start = newStart;
        event.end = newEnd;
        this.bookingEvents = [...this.bookingEvents];
        this.bookingsEvents$.next(this.bookingEvents);

        const model: BookingUpdateModel = <BookingUpdateModel>{
            clientId: event.meta.clientId,
            serviceId: event.meta.serviceId,
            specialistId: event.meta.specialistId,
            colour: event.meta.colourId,
            state: event.meta.state.id,
            dateFrom: TimeUtils.normalizeDate(new Date(event.meta.dateFrom)),
            hourFrom: newStart.getHours(),
            minutesFrom: newStart.getMinutes(),
            dateTo: TimeUtils.normalizeDate(new Date(event.meta.dateTo)),
            hourTo: newEnd.getHours(),
            minutesTo: newEnd.getMinutes(),
            isFromResize: true
        };

        this.bookingService.updateBooking(event.meta.id, model).pipe(takeUntil(this.onDestroy$))
            .subscribe(() => {
                this.snackbar.openSuccess('Event updated successfully.');
                this.prepareFetchBookings();
            }, (error: HttpErrorResponse) => this.snackbar.openErrorWithResponseMessage('Update failed.', error))
    }

    setView(view: CalendarView) {
        this.store.dispatch(new SetDashboardCalendarView(view));
        this.view = view;
        this.prepareFetchBookings();
    }

    changeReflectingDate(date: Date, index: number) {
        this.store.dispatch(new CalendarActions.SetCalendarViewDate(date));
        this.calendarDate = date;
        this.prepareFetchBookings();
        this.activeDayIsOpen = false;
    }

    @HostListener('window:resize', ['$event'])
    onWindowResize(event): void {
        this.showCalendarActionButtons = window.innerWidth >= 1000;
    }

    onHourSegmentClick($event: { date: Date; sourceEvent: MouseEvent }) {
        this.openAddDialog($event.date);
    }

    onDayViewHourSegmentClick($event: { date: Date; sourceEvent: any }): void {
        const className: string = $event.sourceEvent?.toElement ? $event.sourceEvent?.toElement?.className :
            $event.sourceEvent?.srcElement?.className;
        if(className.indexOf('work-hour-segment') !== -1){
            this.openAddDialog($event.date);
        }
    }

    positionChanged($event: MatSelectChange): void {
        this.store.dispatch(new CalendarActions.SetSelectedPosition($event.value));
        this.employeesByPosition = [];
        this.employeesByPosition = this.employees.filter(x => x.positionId === $event.value);
        this.selectedEmployees = this.employeesByPosition;
        this.employeesCtrl.patchValue([...this.employeesByPosition.map(x => x.id)]);
        this.prepareFetchBookings();
    }

    employeesSelectionChange($event: MatSelectChange): void {
        this.store.dispatch(new CalendarActions.SetSelectedEmployees($event.value));
        const employeeIds: number[] = $event.value;
        this.prepareFetchBookings(employeeIds);
    }

    calDayBadgeClick({ date, events }: { date: Date; events: CalendarEvent<BookingCalendarEventModel>[] }): void {
        const bookings: BookingCalendarEventModel[] = events.map(x => x.meta);
        const dialogRef = this.dialog.open(DayBookingsDetailsComponent, {
            disableClose: true,
            width: '500px',
            height: bookings.length < 2 ? '280px' : '380px',
            maxHeight: '640px',
            data: {
                day: TimeUtils.getShortDate(date),
                bookings: bookings
            }
        });
    }

    eventClicked($event: { event: CalendarEvent<BookingCalendarEventModel>; sourceEvent: any }): void {
        this.openEditDialog($event.event);
    }

    eventBadgeClick({date}: {date: Date}, event: CalendarEvent<BookingCalendarEventModel>): void {
        this.openEditDialog(event, date < new Date())
    }

    private openAddDialog(date: Date): void {
        const dialogRef = this.dialog.open(BookingFormComponent, {
            disableClose: true,
            width: '500px',
            height: '620px',
            data: { selectedDate: date }
        });

        dialogRef.afterClosed().pipe(
            takeUntil(this.onDestroy$),
            filter(x => x)
        ).subscribe(() => this.prepareFetchBookings());
    }

    private openEditDialog(event: CalendarEvent<BookingCalendarEventModel>, readonly: boolean = false): void {
        this.dialog.open(EditBookingFormComponent, {
            disableClose: true,
            width: '500px',
            height: '620px',
            data: {
                positionId: this.selectedPositionId,
                booking: event.meta,
                readonly: readonly
            }
        }).afterClosed().pipe(
            takeUntil(this.onDestroy$),
            filter(res => res)
        ).subscribe(() => this.prepareFetchBookings());
    }

    onChipRemove(event: CalendarEvent<BookingCalendarEventModel>): void {
        const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
            disableClose: true,
            data: {
                message: 'Are you sure you want to delete this event?'
            }
        });

        dialogRef.afterClosed().pipe(
            takeUntil(this.onDestroy$),
            filter(ans => ans),
            tap(() => this.isLoading = true),
            switchMap(() => this.bookingService.delete(event.meta.id))
        ).subscribe(() => {
            this.snackbar.openSuccess('Booking successfully deleted');
            this.prepareFetchBookings();
        }, (error: HttpErrorResponse) => this.snackbar.openErrorWithResponseMessage('Could not delete this booking', error));
    }
}
