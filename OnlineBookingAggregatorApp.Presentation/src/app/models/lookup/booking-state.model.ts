import {BaseLookupModel} from './base-lookup.model';

export class BookingStateModel extends BaseLookupModel {
    constructor(public id: number, public name: string, public icon: string) {
        super(id, name);
    }
}
