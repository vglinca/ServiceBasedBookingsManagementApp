import {AddressModel} from '../address/address.model';
import {CompanyType} from '../../enums/company-type';
import {BusinessType} from '../../enums/business-type';
import {BusinessArea} from '../../enums/business-area';
import {EmployeesSize} from '../../enums/employees-size';

export class CreateCompanyViewModel {
    name: string;
    companyType: CompanyType;
    businessType: BusinessType;
    businessArea: BusinessArea;
    employeesQuantity: EmployeesSize;
    email: string;
    country: string;
    city: string;
    street: string;

    public static convertToCreateUpdateModel(viewModel: CreateCompanyViewModel): CompanyCreateModel {
        const model: ICompanyCreateModel = <ICompanyCreateModel>{
            name: viewModel.name,
            companyType: viewModel.companyType,
            businessType: viewModel.businessType,
            businessArea: viewModel.businessArea,
            employeesSize: viewModel.employeesQuantity,
            email: viewModel.email,
            address: <AddressModel>{
                country: viewModel.country,
                city: viewModel.city,
                street: viewModel.street
            }
        };

        return new CompanyCreateModel(model);
    }
}

export interface ICompanyCreateModel {
    name?: string | undefined;
    companyType: CompanyType;
    businessType: BusinessType;
    businessArea: BusinessArea;
    employeesSize: EmployeesSize;
    email?: string | undefined;
    address?: AddressModel | undefined;
}

export class CompanyCreateModel {
    name: string | undefined;
    companyType!: CompanyType;
    businessType!: BusinessType;
    businessArea!: BusinessArea;
    employeesSize!: EmployeesSize;
    email: string | undefined;
    address: AddressModel | undefined;

    constructor(data?: ICompanyCreateModel) {
        this.name= data.name;
        this.companyType = data.companyType;
        this.businessType = data.businessType;
        this.businessArea = data.businessArea;
        this.employeesSize = data.employeesSize;
        this.email = data.email;
        this.address = data.address;
    }
}
