import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {NotificationModel} from '../models/notification/notification.model';
import {NotificationCreateModel} from '../models/notification/notification-create.model';
import {JSON_CONTENT_TYPE} from '../constants/app.constants';

@Injectable({
    providedIn: 'root'
})
export class NotificationsService {
    private readonly apiUrl: string = `${environment.apiBaseUrl}/api/notifications`;
    constructor(private readonly http: HttpClient) {}

    public getForUser(userId: number): Observable<NotificationModel[]> {
        return this.http.get<NotificationModel[]>(`${this.apiUrl}/for-user/${userId}`);
    }

    public add(model: NotificationCreateModel): Observable<void> {
        return this.http.post<void>(`${this.apiUrl}`, model, JSON_CONTENT_TYPE);
    }
}
