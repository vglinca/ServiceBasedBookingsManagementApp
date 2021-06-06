import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ClientModel} from '../models/clients/client.model';
import {PagedRequest} from '../models/paged-request.model';
import {PagedResponseModel} from '../models/paged-response.model';
import {ClientCreateUpdateModel} from '../models/clients/client-create-update.model';
import {JSON_CONTENT_TYPE} from '../constants/app.constants';
import {ClientCategoryUpdateModel} from '../models/clients/client-category-update.model';
import {ClientForSelectModel} from '../models/clients/client-for-select.model';

@Injectable({
    providedIn: 'root'
})
export class ClientsService {
    private readonly apiUrl: string = `${environment.apiBaseUrl}/api/clients`;
    constructor(private readonly http: HttpClient) {}

    public getPaged(companyId: number, request: PagedRequest): Observable<PagedResponseModel<ClientModel>> {
        const query: string = PagedRequest.buildQueryString(request);
        return this.http.get<PagedResponseModel<ClientModel>>(`${this.apiUrl}/${companyId}/paged?${query}`);
    }

    public getForSelect(companyId: number): Observable<ClientForSelectModel[]> {
        return this.http.get<ClientForSelectModel[]>(`${this.apiUrl}/${companyId}/for-select`);
    }

    public getById(clientId: number): Observable<ClientModel> {
        return this.http.get<ClientModel>(`${this.apiUrl}/${clientId}`);
    }

    public create(companyId: number, model: ClientCreateUpdateModel): Observable<number> {
        return this.http.post<number>(`${this.apiUrl}/${companyId}`, {...model}, JSON_CONTENT_TYPE);
    }

    public update(clientId: number, model: ClientCreateUpdateModel): Observable<void>{
        return this.http.put<void>(`${this.apiUrl}/${clientId}`, {...model}, JSON_CONTENT_TYPE);
    }

    public updateCategory(clientId: number, model: ClientCategoryUpdateModel): Observable<void>{
        return this.http.put<void>(`${this.apiUrl}/${clientId}/set-category`, {...model}, JSON_CONTENT_TYPE);
    }

    public delete(clientId: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${clientId}`);
    }
}
