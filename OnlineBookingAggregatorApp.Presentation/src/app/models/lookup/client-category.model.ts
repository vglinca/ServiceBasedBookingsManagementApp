import {BaseLookupModel} from './base-lookup.model';

export class ClientCategoryModel extends BaseLookupModel{
    constructor(id: number, name: string) {
        super(id, name);
    }
}
