import {Component, OnInit} from '@angular/core';
import {EmailRedirectionModel} from '../../../models/email.redirection.model';
import {UserRegisterModel} from '../../../models';
import {AuthService} from '../../../services/auth.service';
import {throwError} from 'rxjs';
import {catchError, finalize, map} from 'rxjs/operators';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {HttpErrorResponse} from '@angular/common/http';

@Component({
    selector: 'app-registration',
    templateUrl: './app-registration.component.html',
    styleUrls: ['./app-registration.component.scss']
})

export class AppRegistrationComponent implements OnInit {

    accountCreated: boolean = false;
    isSpinnerEnabled: boolean = false;
    emailRedirectionModel: EmailRedirectionModel;

    email: string;
    constructor(
        private readonly authService: AuthService,
        private readonly notification: SnackbarNotificationService
    ) {
    }

    ngOnInit(): void {
    }

    onSignUpClick(model: UserRegisterModel): void {
        this.isSpinnerEnabled = true;
        const email: string = model.email;
        if(email.includes('@gmail')) {
            this.emailRedirectionModel = {
                email: email,
                site: 'Gmail',
                redirectTo: 'https://gmail.com'
            }
        } else if (email.includes('@yahoo')) {
            this.emailRedirectionModel = {
                email: email,
                site: 'Yahoo',
                redirectTo: 'https://yahoo.com'
            }
        } else if(email.includes('@mail')) {
            this.emailRedirectionModel = {
                email: email,
                site: 'MailRu',
                redirectTo: 'https://mail.ru'
            }
        } else if (email.includes('@outlook')) {
            this.emailRedirectionModel = {
                email: email,
                site: 'Outlook',
                redirectTo: 'https://outlook.com'
            }
        }
        this.authService.registerCompanyAdmin(model)
            .pipe(
                map(() => {
                    this.accountCreated = true;
                }),
                catchError((error: HttpErrorResponse) => {
                    this.isSpinnerEnabled = false;
                    this.notification.openErrorWithResponseMessage('Could not finish registration.', error);
                    return throwError(error);
                }),
                finalize(() => {
                    this.isSpinnerEnabled = false;
                }))
            .subscribe(() => {
                this.notification.openSuccess('Registration succeed');
                this.isSpinnerEnabled = false;
            }, (error: HttpErrorResponse) => {
                this.isSpinnerEnabled = false;
                this.notification.openErrorWithResponseMessage('Could not finish registration.', error);
            });
    }
}
