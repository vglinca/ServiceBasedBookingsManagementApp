import {BaseLookupModel} from './base-lookup.model';

export class BusinessTypeModel extends BaseLookupModel{
    constructor(id: number, name: string) {
        super(id, name);
    }
}
