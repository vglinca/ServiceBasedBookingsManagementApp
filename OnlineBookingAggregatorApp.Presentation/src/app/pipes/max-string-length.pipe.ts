import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
    name: 'maxLength'
})
export class MaxStringLengthPipe implements PipeTransform{
    private readonly negativeLengthMsg: string  = 'Maximum length can not be negative';
    private readonly stringIsTooShort: string  = 'Cannot truncate a string shorter than 4 characters.';

    transform(value: string, maxLength: number): string {
        if(value == undefined || value.length === 0){
            return '-';
        }
        if(maxLength < 0){
            throw new Error(this.negativeLengthMsg);
        }

        if(value.length > maxLength){
            const substr: string = value.substring(0, maxLength);
            const lastSpaceIndex: number = substr.lastIndexOf(' ');

            if(lastSpaceIndex > 0){
                return lastSpaceIndex < maxLength - 3 ? `${value.substring(0, lastSpaceIndex)}...` :
                    `${value.substring(0, maxLength - 3)}...`;
            }
            if(maxLength > 3){
                return `${value.substring(0, maxLength - 3)}...`;
            }
            throw new Error(this.stringIsTooShort);
        }

        return value;
    }
}
