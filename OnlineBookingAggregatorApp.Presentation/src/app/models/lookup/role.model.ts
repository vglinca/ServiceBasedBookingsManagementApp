import {BaseLookupModel} from './base-lookup.model';

export class RoleModel extends BaseLookupModel {
    constructor(id: number, name: string) {
        super(id, name);
    }
}
