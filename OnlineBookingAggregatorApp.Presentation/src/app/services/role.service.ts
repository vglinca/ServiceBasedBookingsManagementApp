import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {RolePoliciesModel} from '../models/role-policies/role-policies.model';
import {UpdateRolePoliciesModel} from '../models/role-policies/update-role-policies.model';
import {JSON_CONTENT_TYPE} from '../constants/app.constants';

@Injectable({providedIn: 'root'})
export class RoleService {
    private readonly apiUrl: string = `${environment.apiBaseUrl}/api/roles`;
    constructor(private readonly http: HttpClient) {}

    public getRolePolicies(): Observable<RolePoliciesModel[]> {
        return this.http.get<RolePoliciesModel[]>(`${this.apiUrl}/role-policies`);
    }

    public updateRolePolicies(model: UpdateRolePoliciesModel) {
        return this.http.put(`${this.apiUrl}`, {...model}, JSON_CONTENT_TYPE);
    }
}
