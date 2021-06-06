import {Component, OnInit} from '@angular/core';
import {AbstractControl, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {NgOnDestroy} from '../../services/on-destroy.service';
import {takeUntil} from 'rxjs/operators';
import {MatSelectChange} from '@angular/material/select';
import {CompanyCreateModel, CreateCompanyViewModel} from '../../models/company/create-company-view.model';
import {SnackbarNotificationService} from '../../services/snackbar-notification.service';
import {AuthService} from '../../services/auth.service';
import {AllLookupsService} from '../../services/all-lookups.service';
import {Observable} from 'rxjs';
import {fromPromise} from 'rxjs/internal-compatibility';
import {CompanyTypeModel} from '../../models';
import {BusinessAreaModel} from '../../models';
import {BusinessTypeModel} from '../../models';
import {EmployeeQuantityModel} from '../../models';
import {CompaniesService} from '../../services/companies.service';
import {BusinessType} from '../../enums/business-type';
import {HttpErrorResponse} from '@angular/common/http';
import {UserClaims} from '../../constants/app.constants';
import {Store} from '@ngxs/store';
import {CalendarActions} from '../../store/dashboard-calendar.actions';
import {SetCompanyId} from '../../store/current-user.actions';

@Component({
    selector: 'company-creation',
    templateUrl: './company-creation.component.html',
    styleUrls: ['./company-creation.component.scss'],
    providers: [NgOnDestroy]
})
export class CompanyCreationComponent implements OnInit {

    companyForm: FormGroup;
    businessTypes: BusinessTypeModel[] = [];
    businessAreas: BusinessAreaModel[] = [];
    companyTypes: CompanyTypeModel[] = [];
    businessAreasForSelect: BusinessAreaModel[] = [];
    employeesQuantities$: Observable<EmployeeQuantityModel[]>;
    selectedNumberOfEmployees: number = null;

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly activatedRoute: ActivatedRoute,
        private readonly onDestroy$: NgOnDestroy,
        private readonly companiesClient: CompaniesService,
        private readonly notification: SnackbarNotificationService,
        private readonly router: Router,
        private readonly authService: AuthService,
        private readonly lookupService: AllLookupsService,
        private readonly store: Store
    ) {
        this.activatedRoute.data
            .pipe(takeUntil(this.onDestroy$))
            .subscribe((result: { data: {
                    businessTypes: BusinessTypeModel[],
                    businessAreas: BusinessAreaModel[],
                    companyTypes: CompanyTypeModel[]}}) => {
                this.businessTypes = result.data.businessTypes;
                this.businessAreas = result.data.businessAreas;
                this.companyTypes = result.data.companyTypes;
        });
    }

    ngOnInit(): void {
        this.employeesQuantities$ = fromPromise(this.lookupService.getEmployeesQuantities());
        this.companyForm = this.formBuilder.group({
            name: new FormControl('', [Validators.required]),
            companyType: new FormControl('', [Validators.required]),
            businessType: new FormControl('', [Validators.required]),
            businessArea: new FormControl('', [Validators.required]),
            //country: new FormControl('', [Validators.required]),
            city: new FormControl('', [Validators.required]),
            street: new FormControl('', [Validators.required])
        });
    }

    onBusinessTypeChange($event: MatSelectChange): void {
        this.businessAreasForSelect = [];
        this.businessAreasForSelect = this.businessAreas.filter(x => x.businessType === <BusinessType> $event.value);
    }

    onSaveClick(): void {
        const viewModel: CreateCompanyViewModel = {...this.companyForm.value, country: 'MD'};
        viewModel.email = this.authService.getCurrentUser().email;
        viewModel.employeesQuantity = this.selectedNumberOfEmployees;
        const model: CompanyCreateModel = CreateCompanyViewModel.convertToCreateUpdateModel(viewModel);
        this.companiesClient.createCompany(model).subscribe(
            (response) => {
                localStorage.setItem(UserClaims.COMPANY_ID, response.toString());
                this.store.dispatch(new SetCompanyId(response));
                this.store.dispatch(new CalendarActions.SetPositions(response));
                this.notification.openSuccess('Company has been created.');
                this.router.navigate(['/dashboard']);
            },
            (error: HttpErrorResponse) => {
                this.notification.openErrorWithResponseMessage('Could not save changes', error);
            }
        );
    }

    isFormControlValid = (control: AbstractControl): boolean => control.untouched || control.valid;
}
