import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {AbstractControl, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {AllLookupsService} from '../../../../services/all-lookups.service';
import {EMAIL_PATTERN} from '../../../../constants/app.constants';
import {UserRegisterModel} from '../../../../models';
import {uniqueEmailValidator} from '../../../../validators/unique-email.validator';
import {GenderModel} from '../../../../models';
import {UsersService} from '../../../../services/users.service';
import {PhoneInputComponent} from '../../../../shared/components/phone-input/phone-input.component';

@Component({
    selector: 'app-registration-form',
    templateUrl: './app-registration-form-component.html',
    styleUrls: ['./app-registration-form-component.scss']
})

export class AppRegistrationFormComponent implements OnInit {
    @Input() isSpinnerEnabled: boolean = false;
    @Input() isAccountCreated: boolean = false;
    @Output() signUpClicked: EventEmitter<UserRegisterModel> = new EventEmitter<UserRegisterModel>();

    @ViewChild('phoneInput', {static: false}) public phoneInput: PhoneInputComponent;

    registerFrom: FormGroup;
    genders: GenderModel[] = [];

    phoneNumber: string = null;

    get formInvalid(): boolean {
        return this.registerFrom.invalid || this.phoneInput.invalid;
    }

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly lookupService: AllLookupsService,
        private readonly usersClient: UsersService
    ) {
        this.lookupService.getGenders().then(genders => {
            this.genders = genders;
            this.genders.unshift(<GenderModel>{id: null, name: ''});
        });
    }

    ngOnInit(): void {
        this.registerFrom = this.formBuilder.group({
            firstName: new FormControl('', Validators.required),
            lastName: new FormControl('', Validators.required),
            email: new FormControl('', [Validators.required, Validators.pattern(EMAIL_PATTERN)],
                uniqueEmailValidator(this.usersClient)),
            gender: new FormControl(''),
            //phone: new FormControl('', [Validators.required])
        });
    }

    onRegisterClick(): void {
        const model: UserRegisterModel = {...this.registerFrom.value, phone: this.phoneNumber};
        this.signUpClicked.emit(model);
    }

    isFormControlValid = (control: AbstractControl): boolean => control.untouched || control.valid;

    onEnterClick($event: KeyboardEvent) {
        if($event.keyCode === 13 && this.registerFrom.valid){
            this.onRegisterClick();
        }
    }
}
