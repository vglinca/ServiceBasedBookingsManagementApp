import {Gender} from '../../enums/gender';
import {EmployeeStatus} from '../../enums/employee-status';

export class EmployeeModel {
    id!: number;
    firstName?: string | undefined;
    lastName?: string | undefined;
    email?: string | undefined;
    phoneNumber?: string | undefined;
    companyId?: number | undefined;
    gender?: Gender | undefined;
    positionId: number | undefined;
    position?: string | undefined;
    information?: string | undefined;
    specialization?: string | undefined;
    status: EmployeeStatus;
    systemRole?: string | undefined;
    roleId: number;
}
