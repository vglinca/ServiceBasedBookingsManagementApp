import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {EmployeeModel} from '../models';
import {PagedRequest} from '../models/paged-request.model';
import {PagedResponseModel} from '../models/paged-response.model';
import {EmployeeInputViewModel} from '../models';
import {JSON_CONTENT_TYPE} from '../constants/app.constants';
import {EmployeeSelectionModel} from '../models';

@Injectable({providedIn: 'root'})
export class EmployeesService {
    private readonly apiUrl: string = `${environment.apiBaseUrl}/api/employees`;
    constructor(private readonly http: HttpClient) {}

    public getPaged(companyId: number, pagedRequest: PagedRequest): Observable<PagedResponseModel<EmployeeModel>> {
        return this.http.get<PagedResponseModel<EmployeeModel>>(
            `${this.apiUrl}/${companyId}/employees-paged?${PagedRequest.buildQueryString(pagedRequest)}`);
    }

    public getForSelect(companyId: number): Observable<EmployeeSelectionModel[]>{
        return this.http.get<EmployeeSelectionModel[]>(`${this.apiUrl}/${companyId}/for-select-list`);
    }

    public getById(employeeId: number): Observable<EmployeeModel> {
        return this.http.get<EmployeeModel>(`${this.apiUrl}/${employeeId}`);
    }

    public create(companyId: number, model: EmployeeInputViewModel): Observable<number> {
        return this.http.post<number>(`${this.apiUrl}/${companyId}/add-employee`, {...model}, JSON_CONTENT_TYPE);
    }

    public update(employeeId: number, model: EmployeeInputViewModel): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${employeeId}`, {...model}, JSON_CONTENT_TYPE);
    }

    public delete(employeeId: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${employeeId}`);
    }
}

