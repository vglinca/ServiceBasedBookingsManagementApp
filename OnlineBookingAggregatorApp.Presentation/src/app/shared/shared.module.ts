import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MaterialModule} from '../material.module';
import {AppFooterComponent} from './components/footer/app-footer.component';
import {AppHeaderComponent} from './components/header/app-header.component';
import {AppSidenavListComponent} from './components/sidenav-list/app-sidenav-list.component';
import {AppSidebarComponent} from './components/sidebar/app-sidebar.component';
import {RouterModule} from '@angular/router';
import {AppSearchButtonComponent} from './components/app-search-button/app-search-button.component';
import {AppTableComponent} from './components/table/app-table.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BrowserModule} from '@angular/platform-browser';
import {AppMultipleSelectComponent} from './components/multiple-select/app-multiple-select.component';
import {ConfirmationDialogComponent} from './components/confirmation-dialog/confirmation-dialog.component';
import {WarningDialogComponent} from './components/warning-dialog/warning-dialog.component';
import {PipesModule} from '../pipes/pipes.module';
import {MatLoadingComponent} from './components/mat-loading/mat-loading.component';
import {NgScrollbarModule} from 'ngx-scrollbar';
import {DirectivesModule} from '../directives/directives.module';
import {PhoneInputComponent} from './components/phone-input/phone-input.component';
import {ChangePasswordComponent} from './components/change-password/change-password.component';

@NgModule({
    imports: [
        BrowserModule,
        CommonModule,
        MaterialModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        PipesModule,
        NgScrollbarModule,
        DirectivesModule
    ],
    exports: [
        AppFooterComponent,
        AppHeaderComponent,
        AppSidenavListComponent,
        AppSidebarComponent,
        AppSearchButtonComponent,
        AppMultipleSelectComponent,
        AppTableComponent,
        ConfirmationDialogComponent,
        WarningDialogComponent,
        MatLoadingComponent,
        PhoneInputComponent,
        ChangePasswordComponent
    ],
    declarations: [
        AppFooterComponent,
        AppHeaderComponent,
        AppSidenavListComponent,
        AppSidebarComponent,
        AppSearchButtonComponent,
        AppMultipleSelectComponent,
        AppTableComponent,
        ConfirmationDialogComponent,
        WarningDialogComponent,
        MatLoadingComponent,
        PhoneInputComponent,
        ChangePasswordComponent
    ],
    entryComponents: [
        ConfirmationDialogComponent,
        WarningDialogComponent
    ],
})
export class SharedModule {
}
