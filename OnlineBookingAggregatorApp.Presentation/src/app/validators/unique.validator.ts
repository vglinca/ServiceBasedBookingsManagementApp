import {Observable, of, timer} from 'rxjs';
import {AbstractControl, ValidationErrors} from '@angular/forms';
import {map, switchMap, take} from 'rxjs/operators';

export class UniqueValidator {
    public static uniqueValidator<T>(
        service: T,
        func: (value: string) => Observable<boolean>,
        entityId$: Observable<number>
    ): (control: AbstractControl) => Observable<ValidationErrors> {
        let isFirstTime: boolean = true;
        return (control: AbstractControl): Observable<ValidationErrors | null> => {
            return timer(800).pipe(take(1),
                switchMap(() => entityId$.pipe(take(1))),
                switchMap((id: number) => {
                    if(isFirstTime){
                        isFirstTime = false;
                        if(id){
                            return of(null);
                        }
                    }
                    if(!control.value){
                        return of(null);
                    }
                    return func.call(service, <string>control.value.trim(), id).pipe(
                        map(res => res ? null : {unique: true})
                    );
                })
            );
        }
    }
}
