import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {
    AllLookupsModel,
    BusinessTypeModel,
    BusinessAreaModel,
    GenderModel,
    CompanyTypeModel,
    EmployeeQuantityModel,
    EmployeeStatusModel,
    ServiceTargetGroupModel,
    PolicyLookupModel,
    RoleModel,
    ClientCategoryModel,
    ColourModel,
    BookingStateModel
} from '../models';

@Injectable({
    providedIn: 'root'
})
export class AllLookupsService {
    private readonly apiBaseUrl: string = environment.apiBaseUrl;
    private allLookups: AllLookupsModel = null;

    constructor(private readonly http: HttpClient) {}

    private async getAllLookups(): Promise<void> {
        this.allLookups = await this.fetchAllLookups().toPromise();
    }

    private async getLookupsOfType<K extends keyof AllLookupsModel>(key: K): Promise<AllLookupsModel[K]> {
        if(this.allLookups == null){
            await this.getAllLookups();
        }
        return this.allLookups[key];
    }

    public async getBusinessTypes(): Promise<BusinessTypeModel[]> {
        return [...await this.getLookupsOfType('businessTypes')];
    }

    public async getBusinessAreas(): Promise<BusinessAreaModel[]> {
        return [...await this.getLookupsOfType('businessAreas')];
    }

    public async getGenders(): Promise<GenderModel[]> {
        return [...await this.getLookupsOfType('genders')];
    }

    public async getCompanyTypes(): Promise<CompanyTypeModel[]> {
        return [...await this.getLookupsOfType('companyTypes')];
    }

    public async getEmployeesQuantities(): Promise<EmployeeQuantityModel[]> {
        return [...await this.getLookupsOfType('employeesQuantities')];
    }

    public async getEmployeeStatuses(): Promise<EmployeeStatusModel[]> {
        return [...await this.getLookupsOfType('employeeStatuses')];
    }

    public async getServiceTargetGroups(): Promise<ServiceTargetGroupModel[]> {
        return [...await this.getLookupsOfType('serviceTargetGroups')];
    }

    public async getPolicies(): Promise<PolicyLookupModel[]> {
        return [...await this.getLookupsOfType('policies')];
    }

    public async getRoles(): Promise<RoleModel[]> {
        return [...await this.getLookupsOfType('roles')];
    }

    public async getClientCategories(): Promise<ClientCategoryModel[]> {
        return [...await this.getLookupsOfType('clientCategories')];
    }

    public async getBookingColours(): Promise<ColourModel[]> {
        return [...await this.getLookupsOfType('colours')];
    }

    public async getBookingStates(): Promise<BookingStateModel[]> {
        return [...await this.getLookupsOfType('bookingStates')];
    }

    private fetchAllLookups(): Observable<AllLookupsModel> {
        let url_ = this.apiBaseUrl + "/api/Lookup/all-lookups";
        return this.http.get<AllLookupsModel>(url_);
    }
}
