import {BusinessArea} from '../../enums/business-area';

export class ServiceModel {
    id: number = 0;
    companyId: number;
    categoryId: number;
    category: string;
    businessArea: BusinessArea;
    name: string;
    description: string;
    logoPath: string;
    employeeIds: number[];
    bookingsCount: number;
}
