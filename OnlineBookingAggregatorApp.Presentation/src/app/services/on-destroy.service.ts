import {HostListener, Injectable, OnDestroy} from '@angular/core';
import {Subject} from 'rxjs';

@Injectable()
export class NgOnDestroy extends Subject<null> implements OnDestroy{

    constructor() {
        super();
    }

    @HostListener('window:beforeunload')
    ngOnDestroy(): void {
        this.next(null);
        this.complete();
        this.unsubscribe();
    }
}
