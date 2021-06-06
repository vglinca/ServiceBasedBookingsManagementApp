import {DayType} from '../../enums/day.type';
import {DayOfWeek} from '../../enums/day-of-week';

export class WorkScheduleModel {
    workScheduleId!: number;
    dayType!: DayType;
    workingHoursFrom!: number;
    workingMinutesFrom!: number;
    workingHoursTo!: number;
    workingMinutesTo!: number;
    daysOfWeek: DayOfWeek[] = [];
}
