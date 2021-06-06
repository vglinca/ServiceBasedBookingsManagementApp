import {Component, Inject, OnInit, ViewChild} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {ClientModel} from '../../../models';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {ClientsService} from '../../../services/clients.service';
import {AllLookupsService} from '../../../services/all-lookups.service';
import {Observable} from 'rxjs';
import {ClientCategoryModel} from '../../../models';
import {GenderModel} from '../../../models';
import {fromPromise} from 'rxjs/internal-compatibility';
import {EMAIL_PATTERN, UserClaims} from '../../../constants/app.constants';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {ClientCreateUpdateModel} from '../../../models';
import {HttpErrorResponse} from '@angular/common/http';
import {PhoneInputComponent} from '../../../shared/components/phone-input/phone-input.component';

@Component({
    selector: 'client-form',
    templateUrl: './client-form.component.html',
    styleUrls: ['./client-form.component.scss']
})
export class ClientFormComponent implements OnInit {

    public editing: boolean = false;
    public clientForm: FormGroup;
    companyId: number;
    public clientCategories$: Observable<ClientCategoryModel[]>;
    public genders$: Observable<GenderModel[]>;
    phoneNumber: string = null;
    additionalPhoneNumber: string = null;

    @ViewChild('phoneInput', {static: true}) public phoneInput: PhoneInputComponent;
    @ViewChild('additionalPhoneInput', {static: true}) public additionalPhoneInput: PhoneInputComponent;

    get formInvalid(): boolean {
        console.log(this.phoneInput);
        return this.clientForm.invalid || this.phoneInput.invalid || this.additionalPhoneInput.invalid;
    }

    constructor(
        @Inject(MAT_DIALOG_DATA) public client: ClientModel,
        public dialogRef: MatDialogRef<ClientFormComponent>,
        private readonly formBuilder: FormBuilder,
        private readonly clientsService: ClientsService,
        private readonly lookupService: AllLookupsService,
        private readonly snackbar: SnackbarNotificationService
    ) {
        this.editing = this.client.id !== 0;
        this.companyId = Number.parseInt(localStorage.getItem(UserClaims.COMPANY_ID));
        this.phoneNumber = this.client?.phoneNumber;
        this.additionalPhoneNumber = this.client?.additionalPhoneNumber;``
    }

    ngOnInit(): void {
        this.clientCategories$ = fromPromise(this.lookupService.getClientCategories());
        this.genders$ = fromPromise(this.lookupService.getGenders());
        this.initForm();
        if(this.editing){
            this.clientForm.patchValue({...this.client});
            this.clientForm.controls['gender'].setValue(this.client.genderId);
            this.clientForm.controls['clientCategory'].setValue(this.client.clientCategoryId);
        }
    }

    private initForm(): void {
        this.clientForm = this.formBuilder.group({
            firstName: new FormControl(null, [Validators.required, Validators.maxLength(40)]),
            lastName: new FormControl(null, [Validators.required, Validators.maxLength(40)]),
            email: new FormControl(null, [Validators.required,
                Validators.maxLength(100), Validators.pattern(EMAIL_PATTERN)]),
            // phoneNumber: new FormControl(null, [Validators.required, Validators.maxLength(40)]),
            // additionalPhoneNumber: new FormControl(null, [Validators.maxLength(40)]),
            clientCategory: new FormControl(null, [Validators.required]),
            gender: new FormControl(null),
            comments: new FormControl(null, [Validators.maxLength(500)]),
            dateOfBirth: new FormControl(null)
        });
    }

    onSubmit(): void {
        const phone: string = this.phoneNumber.split(' ').join('');
        const additionalPhone: string = this.additionalPhoneNumber?.split(' ').join('');
        const model: ClientCreateUpdateModel = <ClientCreateUpdateModel>{
            ...this.clientForm.value,
            phoneNumber: phone,
            additionalPhoneNumber: additionalPhone
        };
        if(this.editing){
            this.clientsService.update(this.client.id, model).subscribe(() => {
                this.snackbar.openSuccess('Client successfully updated');
                this.dialogRef.close(true);
            }, (error: HttpErrorResponse) => {
                this.snackbar.openErrorWithResponseMessage('Could not save changes.', error);
                this.dialogRef.close(false);
            });

            return;
        }

        this.clientsService.create(this.companyId, model).subscribe((id) => {
            this.snackbar.openSuccess('Client successfully added');
            this.dialogRef.close(true);
        }, (error: HttpErrorResponse) => {
            this.snackbar.openErrorWithResponseMessage('Could not save changes.', error);
            this.dialogRef.close(false);
        });
    }

    onCancelClick(): void {
        this.dialogRef.close(false);
    }
}
