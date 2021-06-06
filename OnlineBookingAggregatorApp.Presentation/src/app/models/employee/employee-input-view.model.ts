import {EmployeeStatus} from '../../enums/employee-status';
import {Gender} from '../../enums/gender';
import {DayType} from '../../enums/day.type';
import {WeekendType} from '../../enums/weekend-type';
import {DayOfWeek} from '../../enums/day-of-week';

export class EmployeeInputViewModel {
    firstName: string;
    lastName: string;
    email: string;
    gender?: Gender;
    status: EmployeeStatus;
    phone: string;
    positionId?: number;
    specialization: string;
    information: string;
    workSchedules: WorkScheduleInputViewModel[] = [];
    roleId: number;
}

export class WorkScheduleInputViewModel {
    workScheduleId: number;
    workingHoursFrom: number;
    workingMinutesFrom!: number;
    workingHoursTo: number;
    workingMinutesTo: number;
    daysOfWeek: DayOfWeek[] = [];
}
