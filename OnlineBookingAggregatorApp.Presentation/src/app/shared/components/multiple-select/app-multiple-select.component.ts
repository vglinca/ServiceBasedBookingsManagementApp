import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {AbstractValueAccessor, makeValueAccessorProvider} from '../form-components/abstract-value.accessor';
import {SelectionViewModel} from '../../../models/selection-view.model';

@Component({
    selector: 'app-multiple-select',
    templateUrl: './app-multiple-select.component.html',
    styleUrls: ['./app-multiple-select.component.scss'],
    providers: [makeValueAccessorProvider(AppMultipleSelectComponent)]
})
export class AppMultipleSelectComponent extends AbstractValueAccessor implements OnInit {

    @Input() placeholder: string;
    @Input() selectItems: SelectionViewModel[];
    @Input() inputDisabled: boolean = false;
    @Input() ignoreId: boolean = false;
    @Output() optionClicked: EventEmitter<any> = new EventEmitter<any>();

    constructor() {
        super();
    }

    hasValue(): boolean {
        return !(this.value == null || this.value === '');
    }

    onItemClick(): void {
        this.optionClicked.emit(this.value);
    }

    ngOnInit(): void {
    }
}
