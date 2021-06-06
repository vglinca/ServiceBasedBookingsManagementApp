import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AppDefaultComponent} from './views/app-default.component';
import {AppLoginComponent} from './views/auth/login/app-login.component';
import {AppRegistrationComponent} from './views/auth/register/app-registration.component';
import {AccountComponent} from './views/account/account.component';
import {BookingsComponent} from './views/bookings/bookings.component';
import {ClientListComponent} from './views/clients/client-list.component';
import {AppDashboardComponent} from './views/dashboard/app-dashboard.component';
import {EmployeesListComponent} from './views/employees/employees-list.component';
import {MatBreadcrumbModule} from 'mat-breadcrumb';
import {CompanyCreationComponent} from './views/company-creation/company-creation.component';
import {CompanyCreationLookupModelsResolver} from './resolvers/company-creation-lookup-models.resolver';
import {CompanyInfoComponent} from './views/company-info/company-info.component';
import {AuthGuard} from './guards/auth.guard';
import {EmployeeFormComponent} from './views/employees/form/employee-form.component';
import {PositionsListComponent} from './views/positions/positions-list.component';
import {ServiceListComponent} from './views/services/service-list.component';
import {CategoriesListComponent} from './views/categories/categories-list.component';
import {PermissionsListComponent} from './views/permissions/permissions-list.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
    },
    {
        path: '',
        component: AppDefaultComponent,
        canActivate: [AuthGuard],
        children: [
            {
                path: 'account',
                component: AccountComponent
            },
            {
                path: 'bookings',
                component: BookingsComponent
            },
            {
                path: 'clients',
                component: ClientListComponent
            },
            {
                path: 'company-details',
                component: CompanyInfoComponent
            },
            {
                path: 'dashboard',
                component: AppDashboardComponent
            },
            {
                path: 'employees',
                children: [
                    {
                        path: '',
                        component: EmployeesListComponent
                    },
                    {
                        path: 'new',
                        component: EmployeeFormComponent
                    },
                    {
                        path: 'edit/:id',
                        component: EmployeeFormComponent
                    }
                ]
            },
            {
                path: 'positions',
                component: PositionsListComponent
            },
            {
                path: 'categories',
                component: CategoriesListComponent
            },
            {
                path: 'services',
                component: ServiceListComponent
            },
            {
                path: 'permissions',
                component: PermissionsListComponent
            }
        ]
    },
    {
        path: 'login',
        component: AppLoginComponent
    },
    {
        path: 'register',
        component: AppRegistrationComponent
    },
    {
        path: 'company-create',
        component: CompanyCreationComponent,
        resolve: {
            data: CompanyCreationLookupModelsResolver
        }
    }
];

@NgModule({
    imports: [
        MatBreadcrumbModule,
        RouterModule.forRoot(routes)
    ],
    exports: [],
    declarations: [],
    providers: [],
})
export class AppRoutingModule {
}
