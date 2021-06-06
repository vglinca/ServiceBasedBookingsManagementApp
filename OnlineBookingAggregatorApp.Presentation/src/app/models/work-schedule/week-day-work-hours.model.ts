import {WorkHoursModel} from './work-hours.model';

export class WeekDayWorkHoursModel {
    employeeId: number;
    workHours: WorkHoursModel[] = [];
    workHoursMatrix: number[][] = [];
}
