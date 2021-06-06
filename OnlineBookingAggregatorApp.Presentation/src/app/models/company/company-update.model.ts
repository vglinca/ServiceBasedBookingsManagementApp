import {CompanyType} from '../../enums/company-type';
import {EmployeesSize} from '../../enums/employees-size';
import {BusinessArea} from '../../enums/business-area';
import {AddressModel} from '../address/address.model';
import {IAddressModel} from '../../services/clients';

export interface ICompanyUpdateModel {
    name?: string | undefined;
    companyType: CompanyType;
    employeesSize: EmployeesSize;
    businessAreas?: BusinessArea[] | undefined;
    email?: string | undefined;
    address?: IAddressModel | undefined;
}

export class CompanyUpdateModel {
    name?: string | undefined;
    companyType!: CompanyType;
    employeesSize!: EmployeesSize;
    businessAreas: BusinessArea[] = [];
    email?: string | undefined;
    address?: AddressModel | undefined;

    constructor(data?: ICompanyUpdateModel) {
        this.name = data.name;
        this.companyType = data.companyType;
        this.employeesSize = data.employeesSize;
        this.businessAreas = data.businessAreas;
        this.email = data.email;
        this.address = data.address;
    }
}
