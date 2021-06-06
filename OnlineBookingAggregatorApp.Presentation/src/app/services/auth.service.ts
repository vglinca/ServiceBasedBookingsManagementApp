import {Injectable} from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {UserRegisterModel, UserUpdateModel} from '../models';
import {JSON_CONTENT_TYPE, UserClaims} from '../constants/app.constants';
import {UserLoginModel} from '../models';
import {tap} from 'rxjs/operators';
import jwtDecode from 'jwt-decode';
import {UserModel} from '../models';
import {BehaviorSubject, Observable, of} from 'rxjs';
import {RefreshAccessTokenModel} from '../models';
import {Store} from '@ngxs/store';
import {SetCurrentUser, SetCurrentUserBriefInfo, SetDefaultUserState} from '../store/current-user.actions';
import {CalendarActions} from '../store/dashboard-calendar.actions';
import {Policy} from '../enums/policy';
import {PasswordChangeModel} from '../models/user/password-change.model';


@Injectable({providedIn: 'root'})
export class AuthService {
    private readonly apiUrl: string = environment.apiBaseUrl;
    private currentUser: UserModel = null;
    companyId$: BehaviorSubject<number> = new BehaviorSubject<number>(-1);
    currentUser$: BehaviorSubject<UserModel> = new BehaviorSubject<UserModel>(null);

    constructor(
        private readonly http: HttpClient,
       private readonly store: Store
    ) {}

    getAccessToken(): string {
        return localStorage.getItem(environment.accessToken);
    }

    getRefreshToken(): string {
        return localStorage.getItem(environment.jit);
    }

    public registerCompanyAdmin(model: UserRegisterModel){
        return this.http.post(`${this.apiUrl}/api/auth/register-company-chief`, model, JSON_CONTENT_TYPE);
    }

    public authenticate(model: UserLoginModel): Observable<any> {
        return this.http.post<RefreshAccessTokenModel>(`${this.apiUrl}/api/auth/employee-authorize`, model, {observe: 'response'})
            .pipe(
                tap((response: HttpResponse<RefreshAccessTokenModel>)  => {
                    const decoded = jwtDecode(response.body.accessToken);
                    localStorage.removeItem(environment.jit);
                    localStorage.removeItem(environment.accessToken);
                    localStorage.setItem(environment.jit, response.body.refreshToken);
                    localStorage.setItem(environment.accessToken, response.body.accessToken);
                    let dateOfBirth: Date = null;
                    const dob: string = decoded[UserClaims.DOB];
                    if(dob){
                        dateOfBirth = new Date(Date.parse(decoded[UserClaims.DOB]));
                    }

                    this.currentUser = <UserModel> {
                        userId: decoded[UserClaims.SUB],
                        firstName: decoded[UserClaims.FIRST_NAME],
                        lastName: decoded[UserClaims.LAST_NAME],
                        email: decoded[UserClaims.EMAIL],
                        companyId: Number.parseInt(decoded[UserClaims.COMPANY_ID]),
                        permissions: decoded[UserClaims.USER_POLICIES].split(','),
                        dateOfBirth: dateOfBirth
                    };
                    this.store.dispatch(new SetCurrentUser(this.currentUser));
                    this.store.dispatch(new SetCurrentUserBriefInfo(this.currentUser.userId));
                    if(!isNaN(this.currentUser.companyId) && this.currentUser.companyId > 0){
                        this.store.dispatch(new CalendarActions.SetPositions(this.currentUser.companyId));
                    }
                    this.currentUser$.next(this.currentUser);
                    this.companyId$.next(this.currentUser.companyId);
                    localStorage.setItem(UserClaims.COMPANY_ID, this.currentUser.companyId.toString());
                })
            );
    }

    public refreshToken(explicitRefresh: boolean = false): Observable<any> {
        if(!this.isRefreshNeeded() && !explicitRefresh){
            return of(null);
        }
        const model = new RefreshAccessTokenModel(this.getAccessToken(), this.getRefreshToken());
        return this.http.post<RefreshAccessTokenModel>(`${this.apiUrl}/api/auth/${this.currentUser.userId}/refresh-token`,
            model, {observe: 'response'}).pipe(
                tap((response: HttpResponse<RefreshAccessTokenModel>) => {
                    const decoded = jwtDecode(response.body.accessToken);
                    const currentUser = <UserModel> {
                        userId: decoded[UserClaims.SUB],
                        firstName: decoded[UserClaims.FIRST_NAME],
                        lastName: decoded[UserClaims.LAST_NAME],
                        email: decoded[UserClaims.EMAIL],
                        companyId: Number.parseInt(decoded[UserClaims.COMPANY_ID]),
                        permissions: decoded[UserClaims.USER_POLICIES].split(',')
                    };

                    this.currentUser = currentUser;
                    this.store.dispatch(new SetCurrentUser(this.currentUser));
                    this.currentUser$.next(currentUser);
                })
        );
    }

    public signOut(): Observable<any> {
        return this.http.post(`${this.apiUrl}/api/auth/sign-out`, {}, {observe: 'response'})
            .pipe(
                tap(() => {
                    localStorage.removeItem(UserClaims.COMPANY_ID);
                    localStorage.removeItem(environment.accessToken);
                    localStorage.removeItem(environment.jit);
                    this.currentUser$.next(null);
                    this.store.dispatch(new SetDefaultUserState());
                })
            );
    }

    public setCurrentUser(user: UserModel): void {
        this.currentUser = user;
        this.currentUser$.next(user);
    }

    public isAuthenticated(): boolean {
        const token: string = localStorage.getItem(environment.accessToken);
        return token != null;
    }

    public userHasRole(role: string): boolean {
        return this.currentUser.role === role;
    }

    public getCurrentUser(): UserModel {
        return this.currentUser;
    }

    public userHasPermission(permission: Policy): boolean {
        const permissions: number[] = this.currentUser?.permissions.map(x => Number.parseInt(x));
        return permissions?.indexOf(permission) > -1;
    }

    public isRefreshNeeded(): boolean {
        const decoded: any = jwtDecode(this.getAccessToken());
        const exp: string = decoded.exp;
        if(!exp) return false;
        const expiresAt = JSON.parse(exp);
        return  new Date().getTime() > (expiresAt - 60000);
    }

    public changePassword(model: PasswordChangeModel): Observable<void>{
        return this.http.post<void>(`${this.apiUrl}/api/auth/employee-change-password`, model,  JSON_CONTENT_TYPE);
    }

    public editProfile(model: UserUpdateModel): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/api/auth/employee-update-profile`, model, JSON_CONTENT_TYPE)
    }
}
