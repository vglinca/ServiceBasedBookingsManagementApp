import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {RolePoliciesModel} from '../../../models/role-policies/role-policies.model';
import {AllLookupsService} from '../../../services/all-lookups.service';
import {Observable} from 'rxjs';
import {PolicyLookupModel} from '../../../models/lookup/policy-lookup.model';
import {fromPromise} from 'rxjs/internal-compatibility';
import {UpdateRolePoliciesModel} from '../../../models/role-policies/update-role-policies.model';
import {MatCheckboxChange} from '@angular/material/checkbox';
import {RoleService} from '../../../services/role.service';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {HttpErrorResponse} from '@angular/common/http';
import {Policy} from '../../../enums/policy';

@Component({
    selector: 'app-role-policies',
    templateUrl: './role-policies.component.html',
    styleUrls: ['./role-policies.component.scss']
})
export class RolePoliciesComponent implements OnInit {

    @Input() rolePolicies: RolePoliciesModel;
    @Output() closeExpansionPanel: EventEmitter<void> = new EventEmitter<void>();

    policies$: Observable<PolicyLookupModel[]>;
    policies: number[] = [];
    readonly Policy = Policy;

    constructor(
        private readonly lookupService: AllLookupsService,
        private readonly roleService: RoleService,
        private readonly snackbar: SnackbarNotificationService
    ) {
        this.policies$ = fromPromise(this.lookupService.getPolicies());
    }

    ngOnInit() {
        this.policies = this.rolePolicies.policies.filter(x => x.isSetByDefault).map(x => x.policyId);
    }

    checkboxChecked(policyId: number): boolean {
        return this.rolePolicies.policies.find(x => x.policyId === policyId) != undefined;
    }

    checkboxDisabled(policyId: number): boolean {
        return this.checkboxChecked(policyId) && this.rolePolicies.policies.find(x => x.policyId === policyId).isSetByDefault === true;
    }

    onCheckboxStateChange($event: MatCheckboxChange, policyId: number): void {
        if($event.checked){
            this.policies.push(policyId);
            return;
        }
        this.policies = this.policies.filter(x => x !== policyId);
    }

    onSaveClick(): void {
        const model: UpdateRolePoliciesModel = new UpdateRolePoliciesModel(this.rolePolicies.roleId, this.policies);
        this.roleService.updateRolePolicies(model)
            .subscribe(
                () => this.snackbar.openSuccess('Permissions updated.'),
                (error: HttpErrorResponse) => this.snackbar.openErrorWithResponseMessage('Could not save permissions', error),
                () => this.closeExpansionPanel.emit());
    }

    onCancelClick(): void {
        this.policies = [];
        this.closeExpansionPanel.emit();
    }
}
