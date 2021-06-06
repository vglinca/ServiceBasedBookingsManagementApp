import {Directive, Injectable, Input, OnDestroy, OnInit, TemplateRef, ViewContainerRef} from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';
import {AuthService} from '../services/auth.service';
import {NgOnDestroy} from '../services/on-destroy.service';
import {filter, takeUntil, takeWhile} from 'rxjs/operators';
import {Policy} from '../enums/policy';

@Injectable()
@Directive({
    selector: '[policyAuthorize]'
})
export class PolicyAuthorizeDirective implements OnInit, OnDestroy{

    private hasView: boolean;
    private isAlive: boolean = true;

    private functionality$ = new BehaviorSubject<Policy>(null);
    private _functionality$: Observable<Policy>;

    @Input() set policyAuthorize(policy: Policy) {
        this.functionality$.next(policy);
    }

    constructor(
        private templateRef: TemplateRef<any>,
        private viewContainerRef: ViewContainerRef,
        private readonly authService: AuthService,
        private readonly onDestroy$: NgOnDestroy
    ) {
        this._functionality$ = this.functionality$.asObservable();
    }

    ngOnInit(): void {
        this._functionality$.pipe(
            takeWhile(() => this.isAlive),
            filter(permission => this.authService.isAuthenticated() && permission != null),
            takeUntil(this.onDestroy$)
        ).subscribe((permission) => {
            this.toggleEmbeddedView(this.checkUserHasPermission(permission));
        });
    }

    private checkUserHasPermission(permission: Policy): boolean {
        return this.authService.userHasPermission(permission);
    }

    private createEmbeddedView(): void {
        this.viewContainerRef.createEmbeddedView(this.templateRef);
        this.hasView = true;
    }

    private clearEmbeddedView(): void {
        this.viewContainerRef.clear();
        this.hasView = false;
    }

    private toggleEmbeddedView(condition: boolean): void {
        if(condition && !this.hasView){
            this.createEmbeddedView();
        } else if(!condition && this.hasView){
            this.clearEmbeddedView();
        }
    }

    ngOnDestroy(): void {
        this.isAlive = false;
    }
}
