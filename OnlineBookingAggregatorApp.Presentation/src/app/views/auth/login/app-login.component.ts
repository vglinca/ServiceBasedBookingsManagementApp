import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {AuthService} from '../../../services/auth.service';
import {UserLoginModel} from '../../../models';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {switchMap} from 'rxjs/operators';
import jwtDecode from 'jwt-decode';
import {UsersService} from '../../../services/users.service';
import {HttpErrorResponse} from '@angular/common/http';
import {UserClaims} from '../../../constants/app.constants';
import {AppThemeService} from '../../../services/app-theme.service';

@Component({
    selector: 'app-login',
    templateUrl: './app-login.component.html',
    styleUrls: ['./app-login.component.scss']
})
export class AppLoginComponent implements OnInit {
    public loginForm: FormGroup;
    public isLoading: boolean = false;

    constructor(
        private readonly router: Router,
        private readonly authService: AuthService,
        private readonly usersClient: UsersService,
        private readonly notification: SnackbarNotificationService,
        private readonly themeService: AppThemeService
    ) {}

    ngOnInit(): void {
        this.themeService.load();
        const isDark: boolean = this.themeService.currentActive() === 'dark';
        this.themeService.update(isDark ? 'dark' : 'light');
        this.loginForm = new FormGroup({
            email: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', [Validators.required])
        });
    }

    onEnterClick(event: KeyboardEvent): void {
        if(event.keyCode === 13 && this.loginForm.valid){
            this.onSignInClick();
        }
    }

    onSignInClick(): void {
        this.isLoading = true;
        const model: UserLoginModel = {...this.loginForm.value};

        this.authService.authenticate(model)
            .pipe(
                switchMap((result) => {
                    const decoded = jwtDecode(result.body.accessToken);
                    const userId: number = Number.parseInt(decoded[UserClaims.SUB]);
                    return this.usersClient.checkUserHasCreatedCompany(userId);
                })
            ).subscribe(
                (result) => {
                    const returnUrl: string = result ? '/dashboard' : '/company-create';
                    this.router.navigate([returnUrl]);
                    },
            (error: HttpErrorResponse) => {
                this.isLoading = false;
                this.notification.openErrorWithResponseMessage('Could not authenticate user.', error);
            }, () => this.isLoading = false);
    }
}
