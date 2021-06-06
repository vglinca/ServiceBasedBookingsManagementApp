import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MaterialModule} from '../material.module';
import {RouterModule} from '@angular/router';
import {AppDefaultComponent} from './app-default.component';
import {SharedModule} from '../shared/shared.module';
import {AccountComponent} from './account/account.component';
import {AppLoginComponent} from './auth/login/app-login.component';
import {CompleteRegistrationComponent} from './auth/register/complete-registration/complete-registration.component';
import {AppRegistrationFormComponent} from './auth/register/form/app-registration-form.component';
import {AppRegistrationComponent} from './auth/register/app-registration.component';
import {BookingsComponent} from './bookings/bookings.component';
import {ClientListComponent} from './clients/client-list.component';
import {AppDashboardComponent} from './dashboard/app-dashboard.component';
import {EmployeesListComponent} from './employees/employees-list.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {CalendarModule, DateAdapter} from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import {MatBreadcrumbModule} from 'mat-breadcrumb';
import {CompanyCreationComponent} from './company-creation/company-creation.component';
import {CompanyInfoComponent} from './company-info/company-info.component';
import {EmployeeFormComponent} from './employees/form/employee-form.component';
import {EmployeeScheduleComponent} from './employees/form/employee-schedule/employee-schedule.component';
import {EmployeeInformationComponent} from './employees/form/employee-information/employee-information.component';
import {PositionsListComponent} from './positions/positions-list.component';
import {PositionFormComponent} from './positions/form/position-form.component';
import {CategoryFormComponent} from './categories/form/category-form.component';
import {ServiceListComponent} from './services/service-list.component';
import {DayViewSchedulerComponent} from './dashboard/day-view-scheduler/day-view-scheduler.component';
import {CategoriesListComponent} from './categories/categories-list.component';
import {PermissionsListComponent} from './permissions/permissions-list.component';
import {RolePoliciesComponent} from './permissions/role-policies/role-policies.component';
import {ServiceFormComponent} from './services/form/service-form.component';
import {NgxMatSelectSearchModule} from 'ngx-mat-select-search';
import {ClientFormComponent} from './clients/form/client-form.component';
import {BookingFormComponent} from './bookings/add-booking-form/booking-form.component';
import {MatSelectInfiniteScrollModule} from 'ng-mat-select-infinite-scroll';
import {NgxMaterialTimepickerModule} from 'ngx-material-timepicker';
import {EditBookingFormComponent} from './bookings/edit-booking-form/edit-booking-form.component';
import {NgScrollbarModule} from 'ngx-scrollbar';
import {DayBookingsDetailsComponent} from './dashboard/day-bookings-details/day-bookings-details.component';
import {DirectivesModule} from '../directives/directives.module';

@NgModule({
    imports: [
        CommonModule,
        MaterialModule,
        SharedModule,
        ReactiveFormsModule,
        FormsModule,
        RouterModule,
        MatBreadcrumbModule,
        DirectivesModule,
        NgxMatSelectSearchModule,
        MatSelectInfiniteScrollModule,
        NgxMaterialTimepickerModule,
        NgScrollbarModule,
        CalendarModule.forRoot({
            provide: DateAdapter,
            useFactory: adapterFactory
        })
    ],
    exports: [],
    declarations: [
        AppDefaultComponent,
        AccountComponent,
        AppLoginComponent,
        CompleteRegistrationComponent,
        AppRegistrationFormComponent,
        AppRegistrationComponent,
        BookingsComponent,
        BookingFormComponent,
        EditBookingFormComponent,
        ClientListComponent,
        ClientFormComponent,
        AppDashboardComponent,
        CompanyCreationComponent,
        CompanyInfoComponent,
        EmployeesListComponent,
        EmployeeFormComponent,
        EmployeeScheduleComponent,
        EmployeeInformationComponent,
        PositionsListComponent,
        PositionFormComponent,
        CategoryFormComponent,
        CategoriesListComponent,
        ServiceListComponent,
        ServiceFormComponent,
        DayViewSchedulerComponent,
        PermissionsListComponent,
        RolePoliciesComponent,
        DayBookingsDetailsComponent
    ],
    entryComponents: [
        PositionFormComponent,
        ServiceFormComponent,
        ClientFormComponent,
        BookingFormComponent,
        DayBookingsDetailsComponent
    ]
})
export class AppDefaultModule {
}
