import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from '@angular/router';
import {forkJoin, Observable} from 'rxjs';
import {AllLookupsService} from '../services/all-lookups.service';
import {fromPromise} from 'rxjs/internal-compatibility';
import {map} from 'rxjs/operators';
import {Injectable} from '@angular/core';
import {BusinessTypeModel} from '../models';
import {BusinessAreaModel} from '../models';
import {CompanyTypeModel} from '../models';

@Injectable({providedIn: 'root'})
export class CompanyCreationLookupModelsResolver implements Resolve<{businessTypes: BusinessTypeModel[], businessAreas: BusinessAreaModel[], companyTypes: CompanyTypeModel[]}> {

    constructor(private readonly lookupService: AllLookupsService) {}

    resolve(route: ActivatedRouteSnapshot,
            state: RouterStateSnapshot
    ): Observable<{ businessTypes: BusinessTypeModel[]; businessAreas: BusinessAreaModel[]; companyTypes: CompanyTypeModel[] }> |
        Promise<{ businessTypes: BusinessTypeModel[]; businessAreas: BusinessAreaModel[]; companyTypes: CompanyTypeModel[] }> |
        { businessTypes: BusinessTypeModel[]; businessAreas: BusinessAreaModel[]; companyTypes: CompanyTypeModel[] } {
        return forkJoin([
            fromPromise(this.lookupService.getBusinessTypes()),
            fromPromise(this.lookupService.getBusinessAreas()),
            fromPromise(this.lookupService.getCompanyTypes())
        ]).pipe(
            map(result => {
                return {
                    businessTypes: result[0],
                    businessAreas: result[1],
                    companyTypes: result[2]
                }
            })
        );
    }
}
