import {SelectionViewModel} from '../models/selection-view.model';

export enum DayOfWeek {
    Sunday = 1,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

export namespace DayOfWeekNs {

    export function getDaysOfWeek(): DayOfWeek[] {
        return [DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
            DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday];
    }

    export function toSelectionViewModel(dayOfWeek: DayOfWeek): SelectionViewModel {
        switch (dayOfWeek){
            case DayOfWeek.Sunday:
                return new SelectionViewModel(dayOfWeek, 'Sunday');
            case DayOfWeek.Monday:
                return new SelectionViewModel(dayOfWeek, 'Monday');
            case DayOfWeek.Tuesday:
                return new SelectionViewModel(dayOfWeek, 'Tuesday');
            case DayOfWeek.Wednesday:
                return new SelectionViewModel(dayOfWeek, 'Wednesday');
            case DayOfWeek.Thursday:
                return new SelectionViewModel(dayOfWeek, 'Thursday');
            case DayOfWeek.Friday:
                return new SelectionViewModel(dayOfWeek, 'Friday');
            case DayOfWeek.Saturday:
                return new SelectionViewModel(dayOfWeek, 'Saturday');
        }
    }
}
