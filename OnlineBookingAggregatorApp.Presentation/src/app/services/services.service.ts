import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {PagedRequest} from '../models/paged-request.model';
import {Observable} from 'rxjs';
import {PagedResponseModel} from '../models/paged-response.model';
import {ServiceModel, ServiceCreateUpdateModel, ServiceForSelectModel} from '../models';
import {JSON_CONTENT_TYPE} from '../constants/app.constants';

@Injectable({providedIn: 'root'})
export class ServicesService {
    private readonly apiUrl: string = `${environment.apiBaseUrl}/api/services`;
    constructor(private readonly http: HttpClient) {}

    public getPaged(companyId: number, pagedRequest: PagedRequest): Observable<PagedResponseModel<ServiceModel>>{
        const query: string = PagedRequest.buildQueryString(pagedRequest);
        return this.http.get<PagedResponseModel<ServiceModel>>(`${this.apiUrl}/${companyId}/services-paged?${query}`);
    }

    public getForSelect(companyId: number): Observable<ServiceForSelectModel[]> {
        return this.http.get<ServiceForSelectModel[]>(`${this.apiUrl}/${companyId}/for-select`);
    }

    public getForSelectBySpecialist(specialistId: number): Observable<ServiceForSelectModel[]> {
        return this.http.get<ServiceForSelectModel[]>(`${this.apiUrl}/for-select/${specialistId}`);
    }

    public getById(serviceId: number): Observable<ServiceModel>{
        return this.http.get<ServiceModel>(`${this.apiUrl}/${serviceId}`);
    }

    public nameIsUnique(name: string, id?: number): Observable<boolean>{
        return this.http.get<boolean>(`${this.apiUrl}/name-is-unique`,
            id ? {'params': {'name': name, 'id': `${id}`}} : {'params': {'name': name}});
    }

    public canDelete(serviceId: number): Observable<boolean> {
        return this.http.get<boolean>(`${this.apiUrl}/${serviceId}/can-delete`);
    }

    public create(companyId: number, model: ServiceCreateUpdateModel): Observable<number>{
        return this.http.post<number>(`${this.apiUrl}/${companyId}`, {...model}, JSON_CONTENT_TYPE);
    }

    public update(serviceId: number, model: ServiceCreateUpdateModel): Observable<void>{
        return this.http.put<void>(`${this.apiUrl}/${serviceId}`, {...model}, JSON_CONTENT_TYPE);
    }

    public delete(serviceId: number): Observable<void>{
        return this.http.delete<void>(`${this.apiUrl}/${serviceId}`);
    }
}
