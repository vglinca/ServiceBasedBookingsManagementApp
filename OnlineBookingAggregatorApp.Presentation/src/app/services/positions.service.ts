import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {PagedRequest} from '../models/paged-request.model';
import {Observable} from 'rxjs';
import {PagedResponseModel} from '../models/paged-response.model';
import {PositionModel} from '../models/position/position.model';
import {PositionCreateUpdateModel} from '../models/position/position-create-update-model';
import {JSON_CONTENT_TYPE} from '../constants/app.constants';

@Injectable({providedIn: 'root'})
export class PositionsService {
    private readonly apiUrl: string = `${environment.apiBaseUrl}/api/positions`;
    constructor(private readonly http: HttpClient) {}

    public getCompanyPositionsPaged(companyId: number, pagedRequest: PagedRequest): Observable<PagedResponseModel<PositionModel>> {
        return this.http.get<PagedResponseModel<PositionModel>>(
            `${this.apiUrl}/${companyId}/paged?${PagedRequest.buildQueryString(pagedRequest)}`);
    }

    public getPositionsForSelect(companyId: number): Observable<PositionModel[]> {
        return this.http.get<PositionModel[]>(`${this.apiUrl}/${companyId}/for-select`);
    }

    public getPositionById(positionId: number): Observable<PositionModel> {
        return this.http.get<PositionModel>(`${this.apiUrl}/${positionId}`);
    }

    public addPosition(companyId: number, model: PositionCreateUpdateModel): Observable<number> {
        return this.http.post<number>(`${this.apiUrl}/${companyId}`, {...model}, JSON_CONTENT_TYPE);
    }

    public updatePosition(positionId: number, model: PositionCreateUpdateModel): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${positionId}`, {...model}, JSON_CONTENT_TYPE);
    }

    public deletePosition(positionId: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${positionId}`);
    }
}
