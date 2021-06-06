import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../services/auth.service';
import {AllLookupsService} from '../../services/all-lookups.service';
import {switchMap, takeUntil} from 'rxjs/operators';
import {forkJoin, Observable, of} from 'rxjs';
import {fromPromise} from 'rxjs/internal-compatibility';
import {SnackbarNotificationService} from '../../services/snackbar-notification.service';
import {NgOnDestroy} from '../../services/on-destroy.service';
import {BusinessAreaModel, CompanyBusinessAreaModel, CompanyModel, EmployeeQuantityModel, AddressModel} from '../../models';
import {CompaniesService} from '../../services/companies.service';
import {CompanyUpdateModel, ICompanyUpdateModel} from '../../models/company/company-update.model';
import {HttpErrorResponse} from '@angular/common/http';
import {Policy} from '../../enums/policy';
import {Select} from '@ngxs/store';
import {CurrentUserState} from '../../store/current-user.state';

@Component({
    selector: 'company-info',
    templateUrl: './company-info.component.html',
    styleUrls: ['./company-info.component.scss'],
    providers: [NgOnDestroy]
})
export class CompanyInfoComponent implements OnInit {

    @Select(CurrentUserState.getCompanyId) companyId$: Observable<number>;

    public isLoading: boolean;
    public companyForm: FormGroup;
    public companyEditMode: boolean = false;
    public companyBusinessAreas: CompanyBusinessAreaModel[] = [];
    public businessAreas: BusinessAreaModel[] = [];
    public employeeQuantities: EmployeeQuantityModel[] = [];
    public companyModel: CompanyModel;
    public selectedBusinessAreasControl: FormControl;
    public readonly Policy = Policy;

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly authService: AuthService,
        private readonly lookupService: AllLookupsService,
        private readonly companiesClient: CompaniesService,
        private readonly notification: SnackbarNotificationService,
        private readonly ngOnDestroy$: NgOnDestroy
    ) {
    }

    ngOnInit(): void {
        this.fetchCompanyData();
    }

    private fetchCompanyData(id: number = undefined): void {
        this.isLoading = true;

        this.companyId$.pipe(
            takeUntil(this.ngOnDestroy$),
            switchMap((companyId: number) => this.companiesClient.getCompanyById(id === undefined ? companyId : id)
                .pipe(
                    takeUntil(this.ngOnDestroy$),
                    switchMap((company) => {
                        this.companyModel = company;
                        return forkJoin([
                            this.companiesClient.getCompanyBusinessAreas(companyId),
                            fromPromise(this.lookupService.getBusinessAreas()),
                            fromPromise(this.lookupService.getEmployeesQuantities()),
                            of(company)
                        ])
                    })
                ))
        ).subscribe((result) => {
            this.companyBusinessAreas = result[0];
            this.employeeQuantities = result[2];
            this.selectedBusinessAreasControl = new FormControl({value: this.companyBusinessAreas?.map(x => x.businessAreaId), disabled: true});
            this.businessAreas = result[1].filter(x => x.businessType === result[3].businessTypeId);
            this.isLoading = false;
            this.initForm();
        }, (error: HttpErrorResponse) => {
            this.notification.openErrorWithResponseMessage('Could not get company info.', error);
            this.isLoading = false;
            this.selectedBusinessAreasControl = new FormControl('');
            this.initForm();
        });
    }

    private initForm() {
        this.companyForm = this.formBuilder.group({
            name: new FormControl({value: this.companyModel?.name || '', disabled: !this.companyEditMode}, [Validators.required]),
            email: new FormControl({value: this.companyModel?.email || '', disabled: !this.companyEditMode}, [Validators.email, Validators.required]),
            companyType: new FormControl({value: this.companyModel?.companyType || '', disabled: true},[Validators.required]),
            businessType: new FormControl({value: this.companyModel?.businessType || '', disabled: true}),
            //country: new FormControl({value: this.companyModel?.address.country || '', disabled: !this.companyEditMode}, [Validators.required]),
            city: new FormControl({value: this.companyModel?.address.city || '', disabled: !this.companyEditMode}, [Validators.required]),
            street: new FormControl({value: this.companyModel?.address.street || '', disabled: !this.companyEditMode}, [Validators.required]),
            employeesSize: new FormControl({value: this.companyModel?.employeesSize || '', disabled: !this.companyEditMode}, [Validators.required])
        });
    }

    onEditCompanyInfoClick(): void {
        this.companyEditMode = true;
        this.enableCompanyForm();
    }

    private enableCompanyForm(): void {
        this.companyForm.enable();
        this.companyForm.controls['companyType'].disable();
        this.companyForm.controls['businessType'].disable();
        this.selectedBusinessAreasControl.enable({onlySelf: true});
    }

    private disableCompanyForm(): void {
        this.companyForm.disable();
    }

    toggleCompanyEditMode(): void {
        this.companyEditMode = false;
        this.disableCompanyForm();
        this.selectedBusinessAreasControl.disable({onlySelf: true});
    }

    submit(): void {
        this.isLoading = true;
        const model: CompanyUpdateModel = new CompanyUpdateModel(<ICompanyUpdateModel> {...this.companyForm.value,
            address: <AddressModel>{
                country: 'MD',
                city: this.companyForm.controls['city'].value,
                street: this.companyForm.controls['street'].value
        }});
        model.businessAreas = this.selectedBusinessAreasControl.value;

        this.companiesClient.updateCompany(this.companyModel.id, model)
            .subscribe(() => {
                this.notification.openSuccess('Company info updated');
                this.toggleCompanyEditMode();
                this.fetchCompanyData(this.companyModel.id);
            }, (error: HttpErrorResponse) =>{
                this.notification.openErrorWithResponseMessage('Could not update company info.', error);
                this.isLoading = false;
            }, () => this.isLoading = false);
    }
}

