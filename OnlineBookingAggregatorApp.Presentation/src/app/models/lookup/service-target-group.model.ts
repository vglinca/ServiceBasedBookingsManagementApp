import {BaseLookupModel} from './base-lookup.model';

export class ServiceTargetGroupModel extends BaseLookupModel {
    constructor(id: number, name: string) {
        super(id, name);
    }
}
