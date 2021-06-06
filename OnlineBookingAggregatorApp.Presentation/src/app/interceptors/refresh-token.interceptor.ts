import {HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse} from '@angular/common/http';
import {Observable, Subscriber} from 'rxjs';
import {Injectable} from '@angular/core';
import {AuthService} from '../services/auth.service';
import {finalize} from 'rxjs/operators';
import {RefreshAccessTokenModel} from '../models';
import {environment} from '../../environments/environment';

type CallerRequest = {
    subscriber: Subscriber<any>;
    unauthorizedRequest: HttpRequest<any>;
};

@Injectable()
export class RefreshTokenInterceptor implements HttpInterceptor {

    private pendingRequests: CallerRequest[] = [];
    private refreshingIsInProgress: boolean;

    constructor(private readonly http: HttpClient, private readonly authService: AuthService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(!req.url.includes('api/') || req.url.includes('register-company-chief') || req.url.includes('employee-authorize')){
            return next.handle(req);
        }

        return new Observable<HttpEvent<any>>((subscriber) => {
            let originalRequestSubscription = next.handle(req)
                .subscribe((response) => {
                    subscriber.next(response);
                }, (error) => {
                    if (error.status === 401) {
                        this.handleUnauthorizedRequest(subscriber, req);
                    } else {
                        subscriber.error(error);
                    }
                }, () => subscriber.complete());
            return () => {
                originalRequestSubscription.unsubscribe();
            };
        });
    }

    private handleUnauthorizedRequest(subscriber: Subscriber<any>, request: HttpRequest<any>): void {
        this.pendingRequests.push({subscriber, unauthorizedRequest: request});
        if(!this.refreshingIsInProgress){
            this.refreshingIsInProgress = true;
            this.authService.refreshToken()
                .pipe(finalize(() => {
                    this.refreshingIsInProgress = false;
                }))
                .subscribe((result: HttpResponse<RefreshAccessTokenModel>) => {
                    if(result){
                        localStorage.removeItem(environment.jit);
                        localStorage.removeItem(environment.accessToken);
                        localStorage.setItem(environment.jit, result.body.refreshToken);
                        localStorage.setItem(environment.accessToken, result.body.accessToken);
                        this.repeatFailedRequests(result.body.accessToken);
                    }
                }, () => {
                    this.authService.signOut();
                });
        }
    }

    private repeatFailedRequests(accessToken: string): void {
        this.pendingRequests.forEach((req) => {
            const requestWithNewToken = req.unauthorizedRequest.clone({setHeaders: {Authorization: `Bearer ${accessToken}`}});
            this.repeatRequest(requestWithNewToken, req.subscriber);
        });

        this.pendingRequests = [];
    }

    private repeatRequest(req: HttpRequest<any>, subscriber: Subscriber<any>): void {
        this.http.request(req).subscribe((response) => {
            subscriber.next(response);
        }, (error) => {
            if(error.status === 401){
                this.authService.signOut();
            }
        }, () => {
            subscriber.complete();
        });
    }
}
