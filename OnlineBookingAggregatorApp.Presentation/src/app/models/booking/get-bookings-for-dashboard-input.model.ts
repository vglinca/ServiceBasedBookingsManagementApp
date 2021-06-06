import {TimeUtils} from '../../utils/time.utils';

export class GetBookingsForDashboardInputModel {
    constructor(
        public companyId: number,
        public specialistsIds: number[],
        public dateFrom: Date,
        public dateTo: Date,
        public queriedForOneDay: boolean
    ) {}

    public toQueryString(): string {
        let query: string = `companyId=${this.companyId}`;
        for(const id of this.specialistsIds){
            query += `&specialistsIds=${id}`;
        }
        query += `&dateFrom=${TimeUtils.getSimpleDateString(new Date(this.dateFrom))}`;
        query += `&dateTo=${TimeUtils.getSimpleDateString(new Date(this.dateTo))}`;
        query += `&queriedForOneDay=${this.queriedForOneDay}`;

        return query;
    }
}
