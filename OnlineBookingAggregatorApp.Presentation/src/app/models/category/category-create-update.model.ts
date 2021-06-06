import {BusinessArea} from '../../enums/business-area';
import {ServiceTargetGroup} from '../../enums/service-target-group';

export class CategoryCreateUpdateModel {
    name: string;
    businessArea: BusinessArea;
    serviceTargetGroup: ServiceTargetGroup
}
