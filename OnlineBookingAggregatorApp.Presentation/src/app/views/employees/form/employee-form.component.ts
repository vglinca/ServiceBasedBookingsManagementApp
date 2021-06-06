import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {EmployeeInformationComponent} from './employee-information/employee-information.component';
import {EmployeeScheduleComponent} from './employee-schedule/employee-schedule.component';
import {AuthService} from '../../../services/auth.service';
import {BehaviorSubject, forkJoin} from 'rxjs';
import {NgOnDestroy} from '../../../services/on-destroy.service';
import {takeUntil} from 'rxjs/operators';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {EmployeeInputViewModel, WorkScheduleInputViewModel} from '../../../models/employee/employee-input-view.model';
import {FormGroup} from '@angular/forms';
import {WorkSchedulesService} from '../../../services/work-schedules.service';
import {EmployeesService} from '../../../services/employees.service';
import {EmployeeModel} from '../../../models';
import {WorkScheduleModel} from '../../../models';
import {HttpErrorResponse} from '@angular/common/http';
import {UserClaims} from '../../../constants/app.constants';

@Component({
    selector: 'employee-form',
    templateUrl: './employee-form.component.html',
    styleUrls: ['./employee-form.component.scss'],
    providers: [NgOnDestroy]
})
export class EmployeeFormComponent implements OnInit, AfterViewInit {
    isLoading: boolean = false;
    returnUrl: string;
    employeeId: number;
    companyId: number;
    employeeModel: BehaviorSubject<EmployeeModel> = new BehaviorSubject<EmployeeModel>(null);
    workSchedules: BehaviorSubject<WorkScheduleModel[]> = new BehaviorSubject<WorkScheduleModel[]>([]);
    private saveDisabled: boolean = true;

    @ViewChild(EmployeeInformationComponent, {static: true}) private employeeInformation: EmployeeInformationComponent;
    @ViewChild(EmployeeScheduleComponent, {static: true}) private employeeSchedule: EmployeeScheduleComponent;

    get formInvalid(): boolean {
        return false;
        // return this.employeeInformation.employeeInfoForm.invalid ||
        //     this.employeeSchedule.scheduleForm.invalid ||
        //     this.employeeInformation.phoneInput.invalid;
    }

    get isSaveDisabled(): boolean {
        return this.saveDisabled;
    }

    constructor(
        private readonly router: Router,
        private readonly route: ActivatedRoute,
        private readonly employeesClient: EmployeesService,
        private readonly workSchedulesClient: WorkSchedulesService,
        private readonly authService: AuthService,
        private readonly notification: SnackbarNotificationService,
        private onDestroy$: NgOnDestroy
    ) {}

    ngOnInit(): void {
        const editing: boolean = this.route.snapshot.url[0].path === 'edit';
        this.returnUrl = editing ? '../..' : '..';
        const id = Number.parseInt(this.route.snapshot.params['id']);
        this.employeeId = isNaN(id) ? null : id;
        this.companyId = isNaN(this.authService.getCurrentUser()?.companyId) ?
            Number.parseInt(localStorage.getItem(UserClaims.COMPANY_ID)) : this.authService.getCurrentUser()?.companyId;
        if(editing){
            forkJoin([
                this.employeesClient.getById(this.employeeId),
                this.workSchedulesClient.getEmployeeWorkSchedules(this.employeeId)
            ])
                .pipe(takeUntil(this.onDestroy$))
                .subscribe((result) => {
                    this.employeeModel.next(result[0]);
                    if(result[1].length > 0){
                        this.workSchedules.next(result[1]);
                    }
                });
        }
    }

    ngAfterViewInit(): void {
        this.saveDisabled = this.employeeInformation.employeeInfoForm.invalid || this.employeeSchedule.scheduleForm.invalid;
    }

    isUpdate(): boolean {
        return this.employeeId != null;
    }

    onSaveClick(): void {
        const employeeModel: EmployeeInputViewModel = new EmployeeInputViewModel();
        const workSchedules: WorkScheduleInputViewModel[] = this.employeeSchedule.getFormValues();
        const form: FormGroup = this.employeeInformation.employeeInfoForm;
        employeeModel.firstName = form.controls['firstName'].value;
        employeeModel.lastName = form.controls['lastName'].value;
        employeeModel.email = form.controls['email'].value;
        employeeModel.phone = this.employeeInformation.phoneNumber;
        employeeModel.gender = form.controls['gender'].value;
        employeeModel.positionId = form.controls['positionId']?.value;
        employeeModel.specialization = form.controls['specialization'].value;
        employeeModel.information = form.controls['information'].value;
        employeeModel.roleId = form.controls['role'].value;
        employeeModel.workSchedules = workSchedules;

        if(this.isUpdate()){
            this.employeesClient.update(this.employeeId, employeeModel)
                .subscribe(() => {
                    this.notification.openSuccess('Employee updated');
                    this.navigateBack();
                }, (err: HttpErrorResponse) => {
                    this.notification.openErrorWithResponseMessage('Could not update an employee.', err);
                });
            return;
        }
        this.employeesClient.create(this.companyId, employeeModel)
            .subscribe((result) => {
                this.notification.openSuccess('Employee created');
                this.navigateBack();
            }, (err: HttpErrorResponse) => {
                this.notification.openErrorWithResponseMessage('Could not add an employee', err);
            });
    }

    navigateBack(): void {
        this.router.navigate([this.returnUrl], {relativeTo: this.route});
    }

    onCancelClick(): void {
        this.navigateBack();
    }
}


