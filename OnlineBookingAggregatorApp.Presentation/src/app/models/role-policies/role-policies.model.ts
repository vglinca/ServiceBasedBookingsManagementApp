import {PolicyModel} from './policy.model';

export class RolePoliciesModel {
    roleId: number;
    roleName: string;
    policies: PolicyModel[] = [];
}
