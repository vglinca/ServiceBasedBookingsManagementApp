import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {BookingModel, BookingPageModel} from '../models';
import {BookingCreateModel} from '../models';
import {JSON_CONTENT_TYPE} from '../constants/app.constants';
import {BookingUpdateModel} from '../models';
import {GetBookingsForDashboardInputModel} from '../models';
import {PagedRequest} from '../models/paged-request.model';
import {PagedResponseModel} from '../models/paged-response.model';

@Injectable({providedIn: 'root'})
export class BookingsService {
    private readonly apiUrl: string = `${environment.apiBaseUrl}/api/bookings`;

    constructor(private readonly http: HttpClient) {}

    public getBookingById(bookingId: number): Observable<BookingModel> {
        return this.http.get<BookingModel>(`${this.apiUrl}/${bookingId}`);
    }

    public getForDashboard(query: GetBookingsForDashboardInputModel): Observable<BookingModel[]> {
        return this.http.get<BookingModel[]>(`${this.apiUrl}/for-dashboard?${query.toQueryString()}`);
    }

    public getPaged(companyId: number, request: PagedRequest): Observable<PagedResponseModel<BookingPageModel>> {
        return this.http.get<PagedResponseModel<BookingPageModel>>
        (`${this.apiUrl}/paged/${companyId}?${PagedRequest.buildQueryString(request)}`);
    }

    public addBooking(companyId: number, model: BookingCreateModel): Observable<number> {
        return this.http.post<number>(`${this.apiUrl}/${companyId}`, {...model}, JSON_CONTENT_TYPE);
    }

    public updateBooking(bookingId: number, model: BookingUpdateModel): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${bookingId}`, {...model}, JSON_CONTENT_TYPE);
    }

    public delete(bookingId: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${bookingId}`);
    }
}
