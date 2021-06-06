import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {CompanyBusinessAreaModel, CompanyModel} from '../models';
import {CompanyCreateModel} from '../models/company/create-company-view.model';
import {JSON_CONTENT_TYPE} from '../constants/app.constants';
import {CompanyUpdateModel} from '../models/company/company-update.model';

@Injectable({providedIn: 'root'})
export class CompaniesService {
    private readonly apiUrl: string = `${environment.apiBaseUrl}/api/companies`;
    constructor(private readonly http: HttpClient) {}

    public getCompanyById(companyId: number): Observable<CompanyModel> {
        return this.http.get<CompanyModel>(`${this.apiUrl}/${companyId}`);
    }

    public getCompanyBusinessAreas(companyId: number): Observable<CompanyBusinessAreaModel[]>{
        return this.http.get<CompanyBusinessAreaModel[]>(`${this.apiUrl}/${companyId}/business-areas`);
    }

    public createCompany(model: CompanyCreateModel): Observable<number>{
        return this.http.post<number>(`${this.apiUrl}/create-company`, {...model}, JSON_CONTENT_TYPE);
    }

    public updateCompany(companyId: number, model: CompanyUpdateModel): Observable<void>{
        return this.http.put<void>(`${this.apiUrl}/${companyId}`, {...model}, JSON_CONTENT_TYPE);
    }
}
