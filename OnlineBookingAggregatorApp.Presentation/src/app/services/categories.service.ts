import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {CategoryModel} from '../models/category/category.model';
import {CategoryCreateUpdateModel} from '../models/category/category-create-update.model';
import {JSON_CONTENT_TYPE} from '../constants/app.constants';
import {PagedResponseModel} from '../models/paged-response.model';
import {PagedRequest} from '../models/paged-request.model';
import {CategoryBriefModel} from '../models/category/category-brief.model';

@Injectable({providedIn: 'root'})
export class CategoriesService {
    private readonly apiUrl: string = `${environment.apiBaseUrl}/api/categories`;
    constructor(private readonly http: HttpClient) {}

    public getPaged(companyId: number, pagedRequest: PagedRequest): Observable<PagedResponseModel<CategoryModel>> {
        return this.http.get<PagedResponseModel<CategoryModel>>(`${this.apiUrl}/${companyId}/paged?${PagedRequest.buildQueryString(pagedRequest)}`);
    }

    public getCategoriesBrief(companyId: number): Observable<CategoryBriefModel[]> {
        return this.http.get<CategoryBriefModel[]>(`${this.apiUrl}/${companyId}/brief`);
    }

    public getById(categoryId: number): Observable<CategoryModel> {
        return this.http.get<CategoryModel>(`${this.apiUrl}/${categoryId}`);
    }

    public categoryNameUnique(category: string, id?: number): Observable<boolean> {
        return this.http.get<boolean>(`${this.apiUrl}/category-unique-name`,
            id ? {'params': {'name': name, 'id': `${id}`}} : {'params': {'name': name}});
    }

    public checkCategoryContainsService(categoryId: number): Observable<boolean>{
        return this.http.get<boolean>(`${this.apiUrl}/${categoryId}/contains-service`);
    }

    public create(companyId: number, model: CategoryCreateUpdateModel): Observable<number> {
        return this.http.post<number>(`${this.apiUrl}/${companyId}`, {...model}, JSON_CONTENT_TYPE);
    }

    public update(categoryId: number, model: CategoryCreateUpdateModel): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${categoryId}`, {...model}, JSON_CONTENT_TYPE);
    }

    public delete(categoryId: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${categoryId}`);
    }
}
