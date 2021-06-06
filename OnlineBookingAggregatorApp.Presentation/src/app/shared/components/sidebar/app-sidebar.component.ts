import {Component, OnInit} from '@angular/core';
import {divChangeHeightAnimation} from '../../../animations/div-change-height.animation';
import {Observable} from 'rxjs';
import {CategoriesService} from '../../../services/categories.service';
import {ActivatedRoute, Router} from '@angular/router';
import {UserClaims} from '../../../constants/app.constants';
import {CategoryBriefModel} from '../../../models';
import {Policy} from '../../../enums/policy';

@Component({
    selector: 'app-sidebar',
    templateUrl: './app-sidebar.component.html',
    styleUrls: ['./app-sidebar.component.scss'],
    animations: [divChangeHeightAnimation]
})
export class AppSidebarComponent implements OnInit {

    categoriesAnimationState: string = localStorage.getItem('categoriesAnimationState') || 'initial';
    categories$: Observable<CategoryBriefModel[]>;
    readonly policy = Policy;

    constructor(
        private readonly categoriesService: CategoriesService,
        private readonly router: Router,
        private readonly route: ActivatedRoute
    ) {
    }

    ngOnInit(): void {
        const companyId: number = Number.parseInt(localStorage.getItem(UserClaims.COMPANY_ID));
        this.categories$ = this.categoriesService.getCategoriesBrief(companyId);
    }

    changeState(): void {
        this.categoriesAnimationState = this.categoriesAnimationState === 'initial' ? 'final' : 'initial';
        localStorage.setItem('projectsAnimationState', this.categoriesAnimationState);
    }

    navigateToServices(id: number): void {
        this.router.navigate([`/categories/${id}/services`]);
    }
}
