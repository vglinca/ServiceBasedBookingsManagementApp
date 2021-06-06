import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {EmployeeSelectionModel} from '../models';

@Injectable({providedIn: 'root'})
export class UsersService {
    private readonly apiUrl: string = `${environment.apiBaseUrl}/api/users`;

    constructor(private readonly http: HttpClient) {}

    public checkUserEmailUnique(email: string): Observable<boolean> {
        return this.http.get<boolean>(`${this.apiUrl}/check-unique-email?email=${email}`);
    }

    public checkUserHasCreatedCompany(userId: number): Observable<boolean> {
        return this.http.get<boolean>(`${this.apiUrl}/check-user-has-created-company/${userId}`);
    }

    public getBriefInfo(userId: number): Observable<EmployeeSelectionModel> {
        return this.http.get<EmployeeSelectionModel>(`${this.apiUrl}/${userId}/brief-info`);
    }
}
