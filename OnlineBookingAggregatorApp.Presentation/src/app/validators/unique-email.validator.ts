import {AsyncValidatorFn, FormControl} from '@angular/forms';
import {timer} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {UsersService} from '../services/users.service';

export function uniqueEmailValidator(usersClient: UsersService): AsyncValidatorFn {
    return (control: FormControl) => {
        const value: string = <string> control.value;
        return timer(600).pipe(
            switchMap(() => usersClient.checkUserEmailUnique(value)),
            map(res => res ? null : {isDuplicate: true})
        );
    };
}
