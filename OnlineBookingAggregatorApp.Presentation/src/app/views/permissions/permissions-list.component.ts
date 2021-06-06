import {Component, OnInit} from '@angular/core';
import {RoleService} from '../../services/role.service';
import {Observable} from 'rxjs';
import {RolePoliciesModel} from '../../models';

@Component({
    selector: 'app-permissions-list',
    templateUrl: './permissions-list.component.html',
    styleUrls: ['./permissions-list.component.scss']
})
export class PermissionsListComponent implements OnInit {
    isLoading: boolean;
    rolePolicies$: Observable<RolePoliciesModel[]>;
    constructor(
        private readonly roleService: RoleService
    ) {
    }

    ngOnInit() {
        this.rolePolicies$ = this.roleService.getRolePolicies();
    }
}
