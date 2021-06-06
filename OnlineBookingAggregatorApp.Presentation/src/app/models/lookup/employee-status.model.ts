import {BaseLookupModel} from './base-lookup.model';

export class EmployeeStatusModel extends BaseLookupModel {
    description: string;
    icon: string;

    constructor(id: number, name: string, description: string, icon: string) {
        super(id, name);
        this.description = description;
        this.icon = icon;
    }
}
