export class UpdateRolePoliciesModel {
    roleId: number;
    policies: number[] = [];

    constructor(roleId: number, policies: number[]) {
        this.roleId = roleId;
        this.policies = policies;
    }
}
