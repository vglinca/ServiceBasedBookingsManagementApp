import {Component, OnInit, ViewChild} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {Select} from '@ngxs/store';
import {CurrentUserState} from '../../store/current-user.state';
import {Observable} from 'rxjs';
import {UserModel, UserUpdateModel} from '../../models';
import {NgOnDestroy} from '../../services/on-destroy.service';
import {filter, switchMap, takeUntil} from 'rxjs/operators';
import {AuthService} from '../../services/auth.service';
import {SnackbarNotificationService} from '../../services/snackbar-notification.service';
import {HttpErrorResponse} from '@angular/common/http';
import {PhoneInputComponent} from '../../shared/components/phone-input/phone-input.component';
import {TimeUtils} from '../../utils/time.utils';

@Component({
    selector: 'account',
    templateUrl: './account.component.html',
    styleUrls: ['./account.component.scss'],
    providers: [NgOnDestroy]
})
export class AccountComponent implements OnInit {

    @Select(CurrentUserState.getUserInfo) userInfo$: Observable<UserModel>;
    @ViewChild(PhoneInputComponent, {static: false}) public phoneInput: PhoneInputComponent;

    public isLoading: boolean;
    public userForm: FormGroup;
    public userEditMode: boolean = false;
    public phoneNumber: string = null;
    public userInfo: UserModel;

    constructor(
        private readonly onDestroy$: NgOnDestroy,
        private readonly formBuilder: FormBuilder,
        private readonly authService: AuthService,
        private readonly snackbar: SnackbarNotificationService
    ) {
        this.userInfo$.pipe(filter(x => x != undefined), takeUntil(this.onDestroy$))
            .subscribe((info) => this.userInfo = info);
    }

    ngOnInit(): void {
        this.userForm = this.formBuilder.group({
            email: new FormControl({value: this.userInfo?.email || null, disabled: !this.userEditMode}, [Validators.email]),
            firstName: new FormControl({value: this.userInfo?.firstName || null, disabled: !this.userEditMode}),
            lastName: new FormControl({value: this.userInfo?.lastName || null, disabled: !this.userEditMode}),
            birthDate: new FormControl({value: this.userInfo?.dateOfBirth || null, disabled: !this.userEditMode})
        });
    }

    onEditUserInfoClick(): void {
        this.userEditMode = true;
        this.enableUSerForm();
    }

    toggleUserEditMode() {
        this.userEditMode = false;
        this.disableUserForm();
    }

    private enableUSerForm(): void {
        this.userForm.enable();
    }

    private disableUserForm(): void {
        this.userForm.disable();
    }

    submit(): void {
        if(this.userForm.invalid || this.phoneInput.invalid){
            return;
        }

        this.isLoading = true;
        const dob: Date = TimeUtils.normalizeDate(new Date(this.userForm.get('birthDate').value)) ?? null;
        const model: UserUpdateModel = <UserUpdateModel>{
            ...this.userForm.getRawValue(),
            birthDate: dob,
            phone: this.phoneNumber
        };

        this.authService.editProfile(model).pipe(
            switchMap(() => this.authService.refreshToken(true))
        ).subscribe(() => {
            this.snackbar.openSuccess('Profile has been successfully updated');
            this.toggleUserEditMode();
            this.isLoading = false;
        }, (error: HttpErrorResponse) => {
            this.snackbar.openErrorWithResponseMessage('Failed updating user profile', error);
            this.isLoading = false;
        });
    }
}
