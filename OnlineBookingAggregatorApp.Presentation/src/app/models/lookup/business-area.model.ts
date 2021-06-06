import {BaseLookupModel} from './base-lookup.model';
import {BusinessType} from '../../enums/business-type';

export class BusinessAreaModel extends BaseLookupModel {
    businessType!: BusinessType;
    constructor(id: number, name: string, businessType: BusinessType) {
        super(id, name);
        this.businessType = businessType;
    }
}
