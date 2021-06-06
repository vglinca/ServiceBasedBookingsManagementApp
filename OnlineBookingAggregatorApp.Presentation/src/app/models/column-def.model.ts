export class ColumnDef {
    id: string;
    name: string;
    icon?: string;
    format?: (value: any) => string;
    sortable: boolean = false;
    columnToMap: string;
    useInSearch: boolean = false;
    useSpecificColumnForSort: boolean = false;
    useAlternativeNameToDisplayForSearch: boolean = false;
    alternativeColumnToDisplay: string;
    columnForSortToMap: string;
    showsNumber: boolean = false;
    showsLargeText: boolean = false;
    showsStandardText: boolean = false;
}
