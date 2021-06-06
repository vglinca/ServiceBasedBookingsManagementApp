import {CalendarView} from 'angular-calendar';
import {PositionModel} from '../models/position/position.model';

export namespace CalendarActions {

    export class SetCalendarView {
        public static readonly type: string = '[Calendar] Set View';
        constructor(public view: CalendarView) {}
    }

    export class SetCalendarViewDate {
        public static readonly type: string = '[Calendar] Set View Date';
        constructor(public date: Date) {}
    }

    export class SetSelectedPosition {
        public static readonly type: string = '[Calendar] Set Position to Select';
        constructor(public positionId: number) {}
    }

    export class SetPositions {
        public static readonly type: string = '[Calendar] Ser Positions';
        constructor(public companyId: number) {}
    }

    export class SetSelectedEmployees {
        public static readonly type: string = '[Calendar] Set Selected Employees';
        constructor(public employeesIds: number[]) {}
    }

    export class SetPositionWithEmployees {
        public static readonly type: string = '[Calendar] Set Position and Employees';
        constructor(public positionId: number, public employees: number[]) {}
    }

    export class SetCalendarDefaults {
        public static readonly type: string = '[Calendar] Set Defaults';
    }
}
