import {BaseLookupModel} from './base-lookup.model';

export class CompanyTypeModel extends BaseLookupModel {
    constructor(id: number, name: string) {
        super(id, name);
    }
}
