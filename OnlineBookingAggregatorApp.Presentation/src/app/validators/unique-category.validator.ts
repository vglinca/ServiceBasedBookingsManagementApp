import {CategoriesService} from '../services/categories.service';
import {AsyncValidatorFn, FormControl} from '@angular/forms';
import {timer} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';

export function uniqueCategoryValidator(categoryService: CategoriesService): AsyncValidatorFn {
    return ((control: FormControl) => {
        const value: string = <string>control.value;
        return timer(600).pipe(
            switchMap(() => categoryService.categoryNameUnique(value)),
            map(res => res ? null : {isDuplicate: true})
        );
    });
}
