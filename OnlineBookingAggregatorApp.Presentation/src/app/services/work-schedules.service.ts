import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {WorkScheduleModel} from '../models';
import {WeekDayWorkHoursModel} from '../models/work-schedule/week-day-work-hours.model';

@Injectable({providedIn: 'root'})
export class WorkSchedulesService {

    private readonly apiUrl: string = `${environment.apiBaseUrl}/api/WorkSchedules`;
    constructor(private readonly http: HttpClient) {}

    public getEmployeeWorkSchedules(employeeId: number): Observable<WorkScheduleModel[]> {
        return this.http.get<WorkScheduleModel[]>(`${this.apiUrl}/${employeeId}`);
    }

    public getEmployeesWorkHours(employeesIds: number[]): Observable<WeekDayWorkHoursModel[]>{
        if(employeesIds.length === 0){
            return;
        }
        let query: string = `employeeIds=${employeesIds[0]}`;
        if(employeesIds.length === 1){
            return this.http.get<WeekDayWorkHoursModel[]>(`${this.apiUrl}/employees-work-hours?${query}`);
        }

        for(let i = 1; i < employeesIds.length; i++){
            query += `&employeeIds=${employeesIds[i]}`;
        }

        return this.http.get<WeekDayWorkHoursModel[]>(`${this.apiUrl}/employees-work-hours?${query}`);
    }
}
