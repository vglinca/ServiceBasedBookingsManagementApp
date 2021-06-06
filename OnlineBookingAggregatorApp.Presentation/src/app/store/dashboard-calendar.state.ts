import {Injectable} from '@angular/core';
import {CalendarView} from 'angular-calendar';
import {Action, Selector, State, StateContext} from '@ngxs/store';
import {CalendarActions} from './dashboard-calendar.actions';
import {PositionModel} from '../models/position/position.model';
import {PositionsService} from '../services/positions.service';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';

export interface CalendarStateModel {
    view: CalendarView,
    viewDate: Date,
    positionId: number,
    employeesIds: number[],
    positions: PositionModel[]
}

@State<CalendarStateModel>({
    name: 'calendarState',
    defaults: {
        view: CalendarView.Week,
        viewDate: new Date(),
        positionId: 0,
        employeesIds: [],
        positions: []
    }
})
@Injectable()
export class DashboardCalendarState {

    constructor(private readonly positionService: PositionsService) {}

    @Selector()
    public static getCalendarView(state: CalendarStateModel): CalendarView {
        return state.view;
    }

    @Selector()
    public static getViewDate(state: CalendarStateModel): Date {
        return state.viewDate;
    }

    @Selector()
    public static getSelectedPosition(state: CalendarStateModel): number {
        return state.positionId;
    }

    @Selector()
    public static getSelectedEmployees(state: CalendarStateModel): number[] {
        return state.employeesIds;
    }

    @Selector()
    public static getPositions(state: CalendarStateModel): PositionModel[] {
        return state.positions;
    }

    @Action(CalendarActions.SetCalendarView)
    setDashboardCalendarView(ctx: StateContext<CalendarStateModel>, action: CalendarActions.SetCalendarView){
        ctx.patchState({
            view: action.view
        });
    }

    @Action(CalendarActions.SetCalendarViewDate)
    setCalendarViewDate(ctx: StateContext<CalendarStateModel>, action: CalendarActions.SetCalendarViewDate){
        ctx.patchState({
            viewDate: action.date
        });
    }

    @Action(CalendarActions.SetSelectedPosition)
    setSelectedPosition(ctx: StateContext<CalendarStateModel>, action: CalendarActions.SetSelectedPosition){
        ctx.patchState({
            positionId: action.positionId
        });
    }

    @Action(CalendarActions.SetPositions)
    setPositions(ctx: StateContext<CalendarStateModel>, action: CalendarActions.SetPositions): Observable<PositionModel[]>{
        return this.positionService.getPositionsForSelect(action.companyId)
            .pipe(
                tap((positions: PositionModel[]) => {
                    ctx.patchState({
                        positions: positions,
                        positionId: positions[0]?.id
                    });
                })
            );
    }

    @Action(CalendarActions.SetSelectedEmployees)
    setSelectedEmployees(ctx: StateContext<CalendarStateModel>, action: CalendarActions.SetSelectedEmployees){
        ctx.patchState({
            employeesIds: action.employeesIds
        });
    }

    @Action(CalendarActions.SetPositionWithEmployees)
    setPositionAndEmployees(ctx: StateContext<CalendarStateModel>, action: CalendarActions.SetPositionWithEmployees) {
        ctx.patchState({
            positionId: action.positionId,
            employeesIds: action.employees
        });
    }

    @Action(CalendarActions.SetCalendarDefaults)
    setDefaults(ctx: StateContext<CalendarStateModel>){
        ctx.setState({
            viewDate: new Date(),
            view: CalendarView.Week,
            positionId: 0,
            employeesIds: [],
            positions: []
        });
    }
}
