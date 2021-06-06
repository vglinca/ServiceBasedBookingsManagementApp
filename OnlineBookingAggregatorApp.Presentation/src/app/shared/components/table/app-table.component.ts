import {AfterViewInit, ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {BehaviorSubject, merge, Observable} from 'rxjs';
import {ColumnDef} from '../../../models/column-def.model';
import {AppSearchButtonComponent} from '../app-search-button/app-search-button.component';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {PagedRequest} from '../../../models/paged-request.model';
import {FormControl} from '@angular/forms';
import {SelectionModel, SelectionViewModel} from '../../../models/selection-view.model';
import {NgOnDestroy} from '../../../services/on-destroy.service';
import {debounceTime, distinctUntilChanged, takeUntil} from 'rxjs/operators';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {HttpErrorResponse} from '@angular/common/http';
import {Policy} from '../../../enums/policy';

@Component({
    selector: 'app-table-component',
    templateUrl: './app-table.component.html',
    styleUrls: ['./app-table.component.scss'],
    providers: [NgOnDestroy]
})
export class AppTableComponent<T> implements OnInit, AfterViewInit {
    
    @Input() data$: Observable<T[]>;
    @Input() totalItems$: BehaviorSubject<number>;
    @Input() columnDefs: ColumnDef[];
    @Input() editable: boolean = true;
    @Input() showDialogOnEditInsteadOfPage: boolean = false;
    @Input() deletable: boolean = true;
    @Input() addEnabled: boolean = true;
    @Input() pageIndex: number = 0;
    @Input() pageSize: number = 10;
    @Input() pageSizeOptions: number[] = [5, 10, 25, 50, 100];
    @Input() defaultSort: string;
    @Input() showDetails: boolean = false;
    @Input() policyToAddResource: Policy;
    @Input() policyToEditResource: Policy;
    @Input() policyToDeleteResource: Policy;
    @Output() onAnyChange: EventEmitter<PagedRequest> = new EventEmitter<PagedRequest>();
    @Output() openDialogToAddOrEdit: EventEmitter<number> = new EventEmitter<number>();
    @Output() onDelete: EventEmitter<number> = new EventEmitter<number>();
    @Output() stopLoading: EventEmitter<void> = new EventEmitter<void>();

    @ViewChild(AppSearchButtonComponent, {static: true}) private search: AppSearchButtonComponent;
    @ViewChild(MatPaginator, {static: true}) private paginator: MatPaginator;
    @ViewChild(MatSort, {static: true}) private sort: MatSort;

    get columnIds(): string[] {
        const columnIds: string[] = this.columnDefs.map(x => x.id);
        columnIds.push('actions');
        return columnIds;
    }

    searchFields: SelectionModel<string>[] = [];
    itemsForMultipleSelect: SelectionViewModel[] = [];
    searchFieldsControl: FormControl = new FormControl();

    constructor(
        private cdRef: ChangeDetectorRef,
        private onDestroy$: NgOnDestroy,
        private readonly snackBarService: SnackbarNotificationService
    ) {}

    ngOnInit(): void {
        this.columnDefs
            .filter(x => x.columnToMap != null && x.useInSearch === true)
            .forEach(x => this.searchFields.push(new SelectionModel<string>(x.columnToMap, x.name)));
    }

    ngAfterViewInit(): void {
        this.searchFieldsControl.patchValue([...this.searchFields.map(x => x.id)]);
        this.sort.sortChange.pipe(takeUntil(this.onDestroy$)).subscribe(() => this.paginator.pageIndex = 0);
        merge(this.sort.sortChange, this.paginator.page, this.search.searchChange$,
            this.searchFieldsControl.valueChanges.pipe(debounceTime(1000), distinctUntilChanged())
        ).pipe(takeUntil(this.onDestroy$))
            .subscribe(() => {
                const request: PagedRequest = <PagedRequest> {
                    pageSize: this.paginator.pageSize,
                    pageNumber: this.paginator.pageIndex + 1,
                    filter: this.search.value.toLowerCase(),
                    filterFields: this.searchFieldsControl.value,
                    orderBy: this.getColumnToSortBy(this.sort.active),
                    ascending: this.sort.direction !== 'desc'
                };
                this.onAnyChange.emit(request);
            }, (error: HttpErrorResponse) => {
                this.snackBarService.openErrorWithResponseMessage('Could not load data', error);
            });
        this.cdRef.detectChanges();
    }

    onAddEditClick(id: number): void {
        this.openDialogToAddOrEdit.emit(id);
    }

    onDeleteItemClick(id: number): void {
        this.onDelete.emit(id);
    }

    private getColumnToSortBy(activeSort: string): string {
        const colDef: ColumnDef = this.columnDefs.find(x => x.id === activeSort);
        if(colDef === undefined){
            return activeSort;
        }
        return colDef.useSpecificColumnForSort ? colDef.columnToMap : activeSort;
    }
}
