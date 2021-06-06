import {BaseLookupModel} from './base-lookup.model';

export class GenderModel extends BaseLookupModel {
    constructor(id: number, name: string) {
        super(id, name);
    }
}
