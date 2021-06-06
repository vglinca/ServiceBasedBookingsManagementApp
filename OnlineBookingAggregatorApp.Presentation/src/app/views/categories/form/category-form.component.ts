import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {AllLookupsService} from '../../../services/all-lookups.service';
import {AuthService} from '../../../services/auth.service';
import {CompaniesService} from '../../../services/companies.service';
import {SelectionViewModel} from '../../../models/selection-view.model';
import {CompanyBusinessAreaModel} from '../../../models/company/company-business-area.model';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {HttpErrorResponse} from '@angular/common/http';
import {ServiceTargetGroupModel} from '../../../models/lookup/service-target-group.model';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {CategoriesService} from '../../../services/categories.service';
import {UniqueValidator} from '../../../validators/unique.validator';
import {CategoryCreateUpdateModel} from '../../../models';
import {UserClaims} from '../../../constants/app.constants';
import {of} from 'rxjs';

@Component({
    selector: 'category-form',
    templateUrl: './category-form.component.html',
    styleUrls: ['./category-form.component.scss']
})
export class CategoryFormComponent implements OnInit {

    categoryForm: FormGroup;
    editing: boolean = false;
    companyId: number;
    businessAreas: SelectionViewModel[] = [];
    targetServiceGroups: ServiceTargetGroupModel[] = [];

    constructor(
        private readonly dialogRef: MatDialogRef<CategoryFormComponent>,
        @Inject(MAT_DIALOG_DATA) private categoryId: number,
        private readonly lookupService: AllLookupsService,
        private readonly authService: AuthService,
        private readonly companyService: CompaniesService,
        private readonly snackbar: SnackbarNotificationService,
        private readonly formBuilder: FormBuilder,
        private readonly categoryService: CategoriesService
    ) {
        this.editing = this.categoryId !== 0;
        this.lookupService.getServiceTargetGroups().then((res) => {
            this.targetServiceGroups = res;
        });
        this.companyId = isNaN(this.authService.getCurrentUser()?.companyId) ?
            Number.parseInt(localStorage.getItem(UserClaims.COMPANY_ID))
            : this.authService.getCurrentUser().companyId;
    }

    ngOnInit(): void {
        this.initForm();
        this.companyService.getCompanyBusinessAreas(this.companyId)
            .subscribe((response: CompanyBusinessAreaModel[]) => {
                response.forEach(x => this.businessAreas.push(
                    <SelectionViewModel>{id: x.businessAreaId, name: x.businessArea}));
            }, (error: HttpErrorResponse) =>
                this.snackbar.openErrorWithResponseMessage('Could not get data.', error));

        if(this.editing){
            this.categoryService.getById(this.categoryId).subscribe((category) => {
                if(category){
                    this.categoryForm.controls['name'].setValue(category.name);
                    this.categoryForm.controls['businessArea'].setValue(category.businessArea);
                    this.categoryForm.controls['serviceTargetGroup'].setValue(category.serviceTargetGroup);
                }
            }, (error: HttpErrorResponse) => this.snackbar.openErrorWithResponseMessage('Could not get category', error));
        }
    }

    initForm(): void {
        this.categoryForm = this.formBuilder.group({
            name: new FormControl('', [
                Validators.required, Validators.maxLength(100)],
                UniqueValidator.uniqueValidator(
                    this.categoryService, CategoriesService.prototype.categoryNameUnique,
                    this.editing ? of(this.categoryId) : of(null)
                )),
            businessArea: new FormControl('', [Validators.required]),
            serviceTargetGroup: new FormControl('', [Validators.required])
        });
    }

    onCancelClick(): void {
        this.dialogRef.close(false);
    }

    onSubmit(): void {
        const model: CategoryCreateUpdateModel = {...this.categoryForm.value};
        if(this.editing){
            this.categoryService.update(this.categoryId, model)
                .subscribe(() => {
                    this.snackbar.openSuccess('Category successfully updated');
                    this.dialogRef.close(true);
                }, (error: HttpErrorResponse) => {
                    this.snackbar.openErrorWithResponseMessage('Could not save changes.', error);
                    this.dialogRef.close(false);
                });
            return;
        }
        this.categoryService.create(this.companyId, model)
            .subscribe(() => {
                this.snackbar.openSuccess('Category successfully added');
                this.dialogRef.close(true);
            }, (error: HttpErrorResponse) => {
                this.snackbar.openErrorWithResponseMessage('Could not save changes.', error);
                this.dialogRef.close(false);
            });
    }
}
