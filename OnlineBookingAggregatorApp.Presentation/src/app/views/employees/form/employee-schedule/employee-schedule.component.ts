import {Component, Input, OnInit} from '@angular/core';
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {SelectionViewModel} from '../../../../models/selection-view.model';
import {AllLookupsService} from '../../../../services/all-lookups.service';
import {fromPromise} from 'rxjs/internal-compatibility';
import {BehaviorSubject, Observable} from 'rxjs';
import {WorkScheduleInputViewModel} from '../../../../models/employee/employee-input-view.model';
import {WorkScheduleModel} from '../../../../models/work-schedule/work-schedule.model';
import {DayTypeModel} from '../../../../models/lookup/day-type.model';
import {WeekendTypeModel} from '../../../../models/lookup/weekend-type.model';
import {DayOfWeek, DayOfWeekNs} from '../../../../enums/day-of-week';
import getDaysOfWeek = DayOfWeekNs.getDaysOfWeek;
import toSelectionViewModel = DayOfWeekNs.toSelectionViewModel;

@Component({
    selector: 'employee-schedule',
    templateUrl: './employee-schedule.component.html',
    styleUrls: ['./employee-schedule.component.scss']
})
export class EmployeeScheduleComponent implements OnInit {

    @Input() workSchedules: BehaviorSubject<WorkScheduleModel[]> = new BehaviorSubject<WorkScheduleModel[]>([]);

    scheduleIds: number[] = [];
    scheduleForm: FormGroup;
    hourList: SelectionViewModel[] = [];
    minutesList: SelectionViewModel[] = [];
    weekDays: SelectionViewModel[] = [];

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly lookupService: AllLookupsService
    ) {
        this.scheduleForm = new FormGroup({
            schedules: new FormArray([])
        });

        for(let i = 0; i < 24; i++){
            this.hourList.push({id: i, name: i.toString().padStart(2, '0')});
        }
        for(let i = 0; i < 60; i +=15){
            this.minutesList.push({id: i, name: i.toString().padStart(2, '0')});
        }
    }

    ngOnInit(): void {
        getDaysOfWeek().forEach(x => this.weekDays.push(toSelectionViewModel(x)));
        this.workSchedules.subscribe((result) => {
            if(result == null || result.length === 0){
                this.addInterval();
            } else {
                this.removeInterval(0);
                let i: number = 0;
                result.forEach(schedule => {
                    this.scheduleIds[i] = schedule.workScheduleId;
                    i++;
                    this.addInterval(
                        schedule.workScheduleId,
                        schedule.workingHoursFrom,
                        schedule.workingMinutesFrom,
                        schedule.workingHoursTo,
                        schedule.workingMinutesTo,
                        schedule.daysOfWeek
                    );
                });
            }
        });
    }

    addInterval(workScheduleId: number = 0, startHour: number = null, startMinute: number = null, endHour: number = null,
                endMinute: number = null, daysOfWeek: DayOfWeek[] = null): void {
        const control = <FormArray>this.scheduleForm.controls['schedules'];
        this.scheduleIds.push(0);
        control.push(this.getScheduleForm(workScheduleId, startHour, startMinute, endHour, endMinute, daysOfWeek));
    }

    private getScheduleForm(workScheduleId: number = 0, startHour: number = null, startMinute: number = null, endHour: number = null,
                            endMinute: number = null, daysOfWeek: DayOfWeek[] = null): FormGroup {
        return this.formBuilder.group({
            workScheduleId: new FormControl(workScheduleId),
            workingHoursFrom: new FormControl({value: startHour, disabled: false}, [Validators.required]),
            workingMinutesFrom: new FormControl({value: startMinute, disabled: false}, [Validators.required]),
            workingHoursTo: new FormControl({value: endHour, disabled: false}, [Validators.required]),
            workingMinutesTo: new FormControl({value: endMinute, disabled: false}, [Validators.required]),
            daysOfWeek: new FormControl({value: daysOfWeek, disabled: false}, [Validators.required])
        });
    }

    getSchedules = (form: FormGroup): FormGroup[] => (<FormGroup[]>(<FormArray>form.controls.schedules).controls);

    removeInterval(i: number): void {
        const control = <FormArray>this.scheduleForm.controls['schedules'];
        control.removeAt(i);
        this.scheduleIds.slice(i, 1);
    }

    getFormValues(): WorkScheduleInputViewModel[] {
        const models: WorkScheduleInputViewModel[] = [];
        let i: number = 0;
        for(const schedule of <WorkScheduleInputViewModel[]>this.scheduleForm.value.schedules){
            const model: WorkScheduleInputViewModel = new WorkScheduleInputViewModel();
            model.workingHoursFrom = schedule.workingHoursFrom;
            model.workingMinutesFrom = schedule.workingMinutesFrom;
            model.workingHoursTo = schedule.workingHoursTo;
            model.workingMinutesTo = schedule.workingMinutesTo;
            model.workScheduleId = schedule.workScheduleId;
            model.daysOfWeek = schedule.daysOfWeek;
            i++;
            models.push(model);
        }

        return models;
    }
}
