export class PagedRequest {
    pageSize: number;
    pageNumber: number;
    filter: string | undefined;
    filterFields: string | undefined;
    orderBy: string | undefined;
    ascending: boolean | undefined;

    public static buildQueryString(req: PagedRequest): string {
        let query: string = `pageSize=${req.pageSize}&pageNumber=${req.pageNumber}`;
        if(req.filter !== undefined && req.filter !== null){
            query += `&filter=${req.filter}`;
        }
        if(req.filterFields !== undefined && req.filterFields !== null){
            query += `&filterFields=${req.filterFields}`;
        }
        if(req.orderBy !== undefined && req.orderBy !== null){
            query += `&orderBy=${req.orderBy}`;
        }
        if(req.ascending !== undefined){
            query += `&ascending=${req.ascending}`;
        }
        return query;
    }
}
