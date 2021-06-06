import {Injectable} from '@angular/core';
import {Action, Selector, State, StateContext} from '@ngxs/store';
import {EmployeeSelectionModel, UserModel} from '../models';
import {SetCompanyId, SetCurrentUser, SetCurrentUserBriefInfo, SetDashboardCalendarView, SetDefaultUserState} from './current-user.actions';
import {CalendarView} from 'angular-calendar';
import {UsersService} from '../services/users.service';
import {tap} from 'rxjs/operators';

export interface UserStateModel {
    currentUser: UserModel;
    dashboardCalendarView: CalendarView;
    briefInfo: EmployeeSelectionModel;
}

@State<UserStateModel>({
    name: 'currentUser',
    defaults: {
        currentUser: {
            userId: 0,
            companyId: 0,
            email: null,
            lastName: null,
            firstName: null,
            role: null,
            permissions: [],
            dateOfBirth: null
        },
        dashboardCalendarView: CalendarView.Week,
        briefInfo: null
    }
})
@Injectable()
export class CurrentUserState {

    constructor(private readonly userService: UsersService) {}

    @Selector()
    public static userPermissions(state: UserStateModel): string[] {
        return state.currentUser.permissions;
    }

    @Selector()
    public static getCompanyId(state: UserStateModel): number {
        return state.currentUser.companyId;
    }

    @Selector()
    public static userId(state: UserStateModel): number {
        return state.currentUser.userId;
    }

    @Selector()
    public static getCalendarView(state: UserStateModel): CalendarView {
        return state.dashboardCalendarView;
    }

    @Selector()
    public static getUserInfo(state: UserStateModel): UserModel {
        return state.currentUser;
    }

    @Selector()
    public static getBriefInfo(state: UserStateModel): EmployeeSelectionModel {
        return state.briefInfo;
    }

    @Action(SetCompanyId)
    setCompanyId(ctx: StateContext<UserStateModel>, action: SetCompanyId) {
        const state = ctx.getState();
        ctx.patchState({
            currentUser: {
                ...state.currentUser,
                companyId: action.companyId
            }
        });
    }

    @Action(SetCurrentUser, {cancelUncompleted: true})
    setUserInfo(ctx: StateContext<UserStateModel>, action: SetCurrentUser){
        ctx.patchState({
            currentUser: {...action.user}
        });
    }

    @Action(SetDashboardCalendarView)
    setDashboardCalendarView(ctx: StateContext<UserStateModel>, action: SetDashboardCalendarView){
        ctx.patchState({
            dashboardCalendarView: action.view
        });
    }

    @Action(SetCurrentUserBriefInfo)
    setBriefInfo(ctx: StateContext<UserStateModel>, action: SetCurrentUserBriefInfo) {
        return this.userService.getBriefInfo(action.userId).pipe(
            tap((userInfo) => {
                ctx.patchState({
                    briefInfo: userInfo
                })
            })
        );
    }

    @Action(SetDefaultUserState)
    setDefaultState(ctx: StateContext<UserStateModel>){
        ctx.setState({
            dashboardCalendarView: CalendarView.Week,
            currentUser: <UserModel>{},
            briefInfo: null
        });
    }
}
