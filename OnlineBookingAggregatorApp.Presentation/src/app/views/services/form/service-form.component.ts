import {Component, Inject, OnInit, ViewChild} from '@angular/core';
import {AbstractControl, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {ServicesService} from '../../../services/services.service';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {UniqueValidator} from '../../../validators/unique.validator';
import {POSITIVE_NUMBER_PATTERN, UserClaims} from '../../../constants/app.constants';
import {ServiceModel} from '../../../models';
import {HttpErrorResponse} from '@angular/common/http';
import {CategoriesService} from '../../../services/categories.service';
import {EmployeesService} from '../../../services/employees.service';
import {Observable, of, ReplaySubject} from 'rxjs';
import {NgOnDestroy} from '../../../services/on-destroy.service';
import {CategoryBriefModel} from '../../../models';
import {EmployeeSelectionModel} from '../../../models';
import {MatSelect} from '@angular/material/select';
import {takeUntil} from 'rxjs/operators';
import {ServiceCreateUpdateModel} from '../../../models';

@Component({
    selector: 'service-form',
    templateUrl: './service-form.component.html',
    styleUrls: ['./service-form.component.scss'],
    providers: [NgOnDestroy]
})
export class ServiceFormComponent implements OnInit {

    public serviceForm: FormGroup;
    public editing: boolean = false;
    public companyId: number;
    public categories$: Observable<CategoryBriefModel[]>;
    public employees$: ReplaySubject<EmployeeSelectionModel[]> = new ReplaySubject<EmployeeSelectionModel[]>(1);
    public employees: EmployeeSelectionModel[] = [];
    public employeesMultiFilterControl: FormControl = new FormControl();

    @ViewChild('employeesMultiSelect', {static: true}) employeesSelect: MatSelect;

    constructor(
        private readonly dialogRef: MatDialogRef<ServiceFormComponent>,
        @Inject(MAT_DIALOG_DATA) public data: {service: ServiceModel},
        private readonly serviceClient: ServicesService,
        private readonly categoryService: CategoriesService,
        private readonly employeeService: EmployeesService,
        private readonly formBuilder: FormBuilder,
        private readonly snackbar: SnackbarNotificationService,
        private readonly onDestroy$: NgOnDestroy
    ) {
        this.editing = this.data.service.id !== 0;
        this.companyId = Number.parseInt(localStorage.getItem(UserClaims.COMPANY_ID));
    }

    ngOnInit(): void {
        this.initForm();
        if(this.editing){
            this.serviceForm.patchValue({...this.data.service});
        }

        this.categories$ = this.categoryService.getCategoriesBrief(this.companyId);
        this.employeeService.getForSelect(this.companyId).subscribe((result) => {
            this.employees = result;
            this.employees$.next(result);
        });

        this.employeesMultiFilterControl.valueChanges
            .pipe(takeUntil(this.onDestroy$))
            .subscribe(() => {
                this.filterEmployees();
            });
    }

    private initForm(): void {
        this.serviceForm = this.formBuilder.group({
            name: new FormControl(null, [Validators.required, Validators.maxLength(50)],
                UniqueValidator.uniqueValidator(
                    this.serviceClient, ServicesService.prototype.nameIsUnique,
                    this.editing ? of(this.data.service.id) : of(null))),
            description: new FormControl(null, [Validators.maxLength(1000)]),
            categoryId: new FormControl(null, [Validators.required]),
            employeeIds: new FormControl(null, [Validators.required])
        });
    }

    onSubmit(): void {
        const model: ServiceCreateUpdateModel = {...this.serviceForm.value};
        if(this.editing){
            this.serviceClient.update(this.data.service.id, model).subscribe(() => {
                this.snackbar.openSuccess('Service successfully updated');
                this.dialogRef.close(true);
            }, (error: HttpErrorResponse) => {
                this.snackbar.openErrorWithResponseMessage('Could not save changes.', error);
                this.dialogRef.close(false);
            });

            return;
        }

        this.serviceClient.create(this.companyId, model).subscribe((id) => {
            this.snackbar.openSuccess('Service successfully added');
            this.dialogRef.close(true);
        }, (error: HttpErrorResponse) => {
            this.snackbar.openErrorWithResponseMessage('Could not save changes.', error);
            this.dialogRef.close(false);
        });
    }

    onCancelClick(): void {
        this.dialogRef.close(false);
    }

    private filterEmployees(): void {
        if(!this.employees || this.employees.length === 0){
            return;
        }

        let search: string = this.employeesMultiFilterControl.value;
        if(!search){
            this.employees$.next(this.employees);
            return;
        }

        search = search.toLowerCase();
        this.employees$.next(
            this.employees.filter(x => x.fullName.toLowerCase().indexOf(search) > -1)
        );
    }
}
