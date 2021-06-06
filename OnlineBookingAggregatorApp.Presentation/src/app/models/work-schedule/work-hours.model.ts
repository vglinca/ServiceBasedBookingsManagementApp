import {DayOfWeek} from '../../enums/day-of-week';

export class WorkHoursModel {
    weekDay: DayOfWeek;
    hourFrom: number;
    minutesFrom: number;
    hourTo: number;
    minutesTo: number;
}
