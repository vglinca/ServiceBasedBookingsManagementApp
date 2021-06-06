import {CompanyTypeModel} from './company-type.model';
import {BusinessAreaModel} from './business-area.model';
import {BusinessTypeModel} from './business-type.model';
import {GenderModel} from './gender.model';
import {EmployeeQuantityModel} from './employee-quantity.model';
import {EmployeeStatusModel} from './employee-status.model';
import {ServiceTargetGroupModel} from './service-target-group.model';
import {PolicyLookupModel} from './policy-lookup.model';
import {RoleModel} from './role.model';
import {ClientCategoryModel} from './client-category.model';
import {ColourModel} from './colour.model';
import {BookingStateModel} from './booking-state.model';

export class AllLookupsModel {
    companyTypes?: CompanyTypeModel[];
    businessAreas?: BusinessAreaModel[];
    businessTypes?: BusinessTypeModel[];
    genders?: GenderModel[];
    employeesQuantities?: EmployeeQuantityModel[];
    employeeStatuses?: EmployeeStatusModel[];
    serviceTargetGroups?: ServiceTargetGroupModel[];
    policies?: PolicyLookupModel[];
    roles?: RoleModel[];
    clientCategories?: ClientCategoryModel[];
    colours?: ColourModel[];
    bookingStates?: BookingStateModel[];
}
