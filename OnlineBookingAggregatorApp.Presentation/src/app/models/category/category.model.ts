import {BusinessArea} from '../../enums/business-area';
import {ServiceTargetGroup} from '../../enums/service-target-group';

export class CategoryModel {
    id: number;
    name: string;
    businessAreaId: BusinessArea;
    businessArea: string;
    serviceTargetGroupId: ServiceTargetGroup;
    serviceTargetGroup: string;
    totalServices: number;
}
