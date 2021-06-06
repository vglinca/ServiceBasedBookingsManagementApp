import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {AbstractValueAccessor, makeValueAccessorProvider} from '../form-components/abstract-value.accessor';
import {MatInput} from '@angular/material/input';
import {Observable} from 'rxjs';
import {debounceTime, distinctUntilChanged} from 'rxjs/operators';

@Component({
    selector: 'app-search-button',
    templateUrl: './app-search-button.component.html',
    styleUrls: ['./app-search-button.component.scss'],
    providers: [makeValueAccessorProvider(AppSearchButtonComponent)]
})
export class AppSearchButtonComponent extends AbstractValueAccessor implements OnInit {
    emitter: EventEmitter<string> = new EventEmitter<string>();
    @Input() color: string;
    @Input() placeholder: string;
    @ViewChild(MatInput, { static: true }) private input: MatInput;
    @Output() searchChange$: Observable<string> = this.emitter.pipe(debounceTime(1000), distinctUntilChanged());

    constructor() {
        super();
    }

    ngOnInit(): void {
        if(this.placeholder == null){
            this.placeholder = 'Search';
        }
    }

    onClick(): void {
        this.input.focus();
    }

    onChange = (value: string) => {
        this.emitter.emit(value);
    }
}
