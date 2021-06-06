import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {RouterModule} from '@angular/router';
import {AppRoutingModule} from './app-routing.module';
import {API_BASE_URL} from './services/clients';
import {environment} from '../environments/environment';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {AppDefaultModule} from './views/app-default.module';
import {ApplyAccessTokenInterceptor} from './interceptors/apply-access-token.interceptor';
import {RefreshTokenInterceptor} from './interceptors/refresh-token.interceptor';
import {NgxsModule} from '@ngxs/store';
import {states} from './store/states';
import {NgxsStoragePluginModule} from '@ngxs/storage-plugin';
import {NgxsReduxDevtoolsPluginModule} from '@ngxs/devtools-plugin';
import {NgScrollbarModule} from 'ngx-scrollbar';
import {NgOnDestroy} from './services/on-destroy.service';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        RouterModule,
        AppRoutingModule,
        AppDefaultModule,
        HttpClientModule,
        MatSnackBarModule,
        NgScrollbarModule,
        NgxsModule.forRoot(states, {
            developmentMode: !environment.production
        }),
        NgxsStoragePluginModule.forRoot(),
        NgxsReduxDevtoolsPluginModule.forRoot({
            disabled: environment.production
        })
    ],
    providers: [{
        provide: API_BASE_URL,
        useValue: environment.apiBaseUrl
    },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: ApplyAccessTokenInterceptor,
            multi: true
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: RefreshTokenInterceptor,
            multi: true
        },
        { provide: NgOnDestroy}
    ],
    exports: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
