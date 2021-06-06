import {ControlValueAccessor, NG_VALUE_ACCESSOR} from '@angular/forms';
import {forwardRef, Provider} from '@angular/core';

export abstract class AbstractValueAccessor implements ControlValueAccessor {
    private _value: any = '';

    get value(): any {
        return this._value;
    }

    set value(v: any){
        if(v !== this._value){
            this.writeValue(v);
        }
    }

    onChange = (_: any) => { };
    onTouched = () => { };

    registerOnChange(fn: (_: any) => void): void {
        this.onChange = fn;
    }

    registerOnTouched(fn: () => void): void {
        this.onTouched = fn;
    }

    writeValue(value: any): void {
        this._value = value;
        this.onChange(value);
    }
}

export function makeValueAccessorProvider(type: any): Provider {
    return {
        provide: NG_VALUE_ACCESSOR,
        useExisting: forwardRef(() => type),
        multi: true
    };
}
