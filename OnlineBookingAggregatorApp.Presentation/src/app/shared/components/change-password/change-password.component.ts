import {Component, OnInit} from '@angular/core';
import {AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators} from '@angular/forms';
import {AuthService} from '../../../services/auth.service';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {PasswordChangeModel} from '../../../models/user/password-change.model';
import {MatDialogRef} from '@angular/material/dialog';
import {HttpErrorResponse} from '@angular/common/http';
import {NgOnDestroy} from '../../../services/on-destroy.service';
import {CurrentUserState} from '../../../store/current-user.state';
import {Select} from '@ngxs/store';
import {Observable} from 'rxjs';
import {UserModel} from '../../../models';
import {filter, map, takeUntil} from 'rxjs/operators';

@Component({
    selector: 'change-password',
    templateUrl: './change-password.component.html',
    styleUrls: ['./change-password.component.scss'],
    providers: [NgOnDestroy]
})
export class ChangePasswordComponent implements OnInit {

    @Select(CurrentUserState.getUserInfo) userInfo$: Observable<UserModel>;

    public hideOldPassword: boolean = true;
    public hideNewPassword: boolean = true;
    public hideRepeatNewPassword: boolean = true;
    public userEmail: string;

    public form: FormGroup;
    public isLoading: boolean = false;

    constructor(
        private readonly authService: AuthService,
        private readonly snackbar: SnackbarNotificationService,
        private readonly dialogRef: MatDialogRef<ChangePasswordComponent>,
        private readonly onDestroy$: NgOnDestroy,
        private readonly formBuilder: FormBuilder
    ) {
        this.userInfo$.pipe(
            takeUntil(this.onDestroy$),
            filter(val => val != undefined),
            map(val => val.email)
        ).subscribe((email: string) => this.userEmail = email);
    }

    ngOnInit(): void {
        this.form = this.formBuilder.group({
            oldPassword: new FormControl('', [Validators.required]),
            newPassword: new FormControl('', [Validators.required]),
            repeatNewPassword: new FormControl('', [Validators.required])
        }, {validator: this.passwordsAreEqual});
    }

    passwordsAreEqual = (control: AbstractControl) => {
        const newPassword: string = control.get('newPassword').value;
        const repeatNewPassword: string = control.get('repeatNewPassword').value;

        if(newPassword !== repeatNewPassword){
            control.get('repeatNewPassword').setErrors({ areNotEqual: true });
        }
    }

    save(): void {
        this.isLoading = true;
        const model: PasswordChangeModel = <PasswordChangeModel>{
            ...this.form.getRawValue(),
            email: this.userEmail
        };

        this.authService.changePassword(model).subscribe(() => {
            this.snackbar.openSuccess('Password changed');
            this.isLoading = false;
            this.dialogRef.close(true);
        }, (error: HttpErrorResponse) => {
            this.snackbar.openErrorWithResponseMessage('Failed update password', error);
            this.isLoading = false;
            this.dialogRef.close(false);
        });
    }
}
