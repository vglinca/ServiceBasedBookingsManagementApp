import {CompanyType} from '../../enums/company-type';
import {BusinessType} from '../../enums/business-type';
import {EmployeesSize} from '../../enums/employees-size';
import {AddressModel} from '../address/address.model';

export class CompanyModel {
    id!: number;
    companyTypeId!: CompanyType;
    companyType?: string | undefined;
    businessTypeId!: BusinessType;
    businessType?: string | undefined;
    employeesSize!: EmployeesSize;
    name?: string | undefined;
    email?: string | undefined;
    address?: AddressModel | undefined;
    logoPath?: string | undefined;
}
