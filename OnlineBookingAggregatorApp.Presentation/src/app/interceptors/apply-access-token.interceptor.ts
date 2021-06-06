import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Injectable} from '@angular/core';
import {AuthService} from '../services/auth.service';
import {environment} from '../../environments/environment';
import jwtDecode from 'jwt-decode';
import {UserModel} from '../models/user/user.model';
import {UserClaims} from '../constants/app.constants';

@Injectable()
export class ApplyAccessTokenInterceptor implements HttpInterceptor{

    constructor(private readonly authService: AuthService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(!req.url.includes('api/') || req.url.includes('register-company-chief') || req.url.includes('employee-authorize')){
            return next.handle(req);
        }

        if(localStorage.getItem(environment.accessToken) && this.authService.getCurrentUser() == null){
            const decoded = jwtDecode(localStorage.getItem(environment.accessToken));
            const currentUser = <UserModel> {
                userId: decoded[UserClaims.SUB],
                firstName: decoded[UserClaims.FIRST_NAME],
                lastName: decoded[UserClaims.LAST_NAME],
                email: decoded[UserClaims.EMAIL],
                companyId: Number.parseInt(decoded[UserClaims.COMPANY_ID]),
                permissions: decoded[UserClaims.USER_POLICIES].split(',')
            };
            if(currentUser != null){
                this.authService.setCurrentUser(currentUser);
            }
        }

        return next.handle(this.addAuthorizationHeader(req, this.authService.getAccessToken()));
    }

    private addAuthorizationHeader(request: HttpRequest<any>, token: string): HttpRequest<any> {
        return request.clone({setHeaders: {Authorization: `Bearer ${token}`}});
    }
}
