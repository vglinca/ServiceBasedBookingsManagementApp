import {UserModel} from '../models/user/user.model';
import {CalendarView} from 'angular-calendar';

export class SetCurrentUser {
    public static readonly type: string = '[CurrentUser] Set User Info';
    constructor(public user: UserModel) {}
}

export class SetCurrentUserBriefInfo {
    public static readonly type: string = '[Current User] Set Brief Info';
    constructor(public userId: number) {}
}

export class SetDashboardCalendarView {
    public static readonly type: string = '[Current User] Set Dashboard Calendar View';
    constructor(public view: CalendarView) {}
}

export class SetDefaultUserState {
    public static readonly type: string = '[Current User] Set Default State';
}

export class SetCompanyId {
    public static readonly type: string = '[Current User] Set Company Id';
    constructor(public companyId: number) {}
}
