import {Component, forwardRef, Injector, Input, OnInit, ViewChild} from '@angular/core';
import {ErrorStateMatcher} from '@angular/material/core';
import {
    AbstractControl,
    ControlValueAccessor, FormControl,
    NG_VALIDATORS,
    NG_VALUE_ACCESSOR, NgControl,
    NgModel,
    ValidationErrors,
    Validator
} from '@angular/forms';
import {NgOnDestroy} from '../../../services/on-destroy.service';
import {takeUntil} from 'rxjs/operators';
import parsePhoneNumberFromString from 'libphonenumber-js';
import {TouchedErrorStateMatcher} from '../../error-state-matchers';
import {MatFormFieldAppearance} from '@angular/material/form-field';

@Component({
    selector: 'app-phone-input',
    templateUrl: './phone-input.component.html',
    styleUrls: ['./phone-input.component.scss'],
    providers: [
        NgOnDestroy,
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => PhoneInputComponent),
            multi: true
        },
        {
            provide: NG_VALIDATORS,
            useExisting: forwardRef(() => PhoneInputComponent),
            multi: true
        }
    ]
})
export class PhoneInputComponent implements ControlValueAccessor, OnInit, Validator {

    @Input() placeholderText: string;
    @Input() requiredText: string;
    @Input() errorText: string;
    @Input() disabled: boolean = false;
    @Input() required: boolean = false;
    @Input() formFieldAppearance: MatFormFieldAppearance;

    @ViewChild('phoneNumberInput', {static: true}) public phoneNumberInput: NgModel;

    public errorStateMatcher: ErrorStateMatcher;
    public rawValue: string = null;

    private _value: string = null;
    private _control: NgControl;

    get invalid(): boolean {
        return this._control ? this._control.invalid : false;
    }

    get value(): string {
        return this._value;
    }

    set value(value: string) {
        this._value = value;
        this.onChange(value);
    }

    private onChange: (_: any) => void = () => {};
    private onTouched: () => void = () => {};

    constructor(
        private readonly injector: Injector,
        private readonly onDestroy$: NgOnDestroy)
    {}

    ngOnInit(): void {
        this._control = this.injector.get(NgControl);
        this._control.valueAccessor = this;

        if (this.errorText == null) {
            this.errorText = this.placeholderText ? `Invalid ${this.placeholderText}!` : `Invalid phone number!`;
        }
        if (this.requiredText == null) {
            this.requiredText = this.placeholderText ? `${this.placeholderText} is required!` : `Phone number is required!`;
        }

        const control: FormControl = this.phoneNumberInput.control;

        control.valueChanges.pipe(takeUntil(this.onDestroy$))
            .subscribe((val: string) => {
                if (val == null) {
                    this.value = null;
                    return;
                }
                const phoneNumber = parsePhoneNumberFromString(val, 'MD');
                if (phoneNumber == null) {
                    this.value = null;
                    return;
                }

                this.value = phoneNumber.formatInternational();
            });

        if(this.disabled){
            control.disable();
        }

        control.setValidators([
            control => {
                if (control.value == null || control.value.trim().length === 0) {
                    return null;
                }

                const phoneNumber = parsePhoneNumberFromString(control.value, 'MD');
                if (phoneNumber != null && phoneNumber.isValid()) {
                    return null;
                }

                return { pattern: { valid: false } };
            }
        ]);

        this.errorStateMatcher = new TouchedErrorStateMatcher();
    }

    onPhoneNumberInputBlur(event: FocusEvent): void {
        this.formatRawValue();
    }

    registerOnChange(fn: (_: any) => void): void {
        this.onChange = fn;
    }

    registerOnTouched(fn: () => void): void {
        this.onTouched = fn;
    }

    validate(control: AbstractControl): ValidationErrors | null {
        return control.validator(this.phoneNumberInput.control);
    }

    writeValue(value: any): void {
        if (typeof(value) !== 'string') {
            this.value = null;
            return;
        }

        const phoneNumber = parsePhoneNumberFromString(value, 'MD');
        if (phoneNumber == null) {
            this.value = null;
            return;
        }

        this.rawValue = phoneNumber.formatNational();
        this.value = phoneNumber.formatInternational();
    }

    private formatRawValue(): void {
        if (this.rawValue == null) {
            return;
        }

        const phoneNumber = parsePhoneNumberFromString(this.rawValue, 'MD');
        if (phoneNumber != null) {
            this.rawValue = phoneNumber.formatNational();
        }
    }
}
