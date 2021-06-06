import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {AuthService} from '../services/auth.service';
import {Policy} from '../enums/policy';

@Injectable({providedIn: 'root'})
export class AuthGuard implements CanActivate {
    constructor(
        private readonly router: Router,
        private readonly authService: AuthService
    ) {}

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        if(!localStorage.getItem(environment.accessToken)){
            this.router.navigate(['/login']);
            return false;
        }

        const permission: Policy = route.data['permission'] as Policy;

        if(permission){
            return this.authService.userHasPermission(permission);
        }

        return true;
    }
}
