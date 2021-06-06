import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {divChangeHeightAnimation} from '../../../animations/div-change-height.animation';
import {Observable} from 'rxjs';
import {CategoriesService} from '../../../services/categories.service';
import {ActivatedRoute, Router} from '@angular/router';
import {CategoryBriefModel} from '../../../models';
import {UserClaims} from '../../../constants/app.constants';
import {Policy} from '../../../enums/policy';

@Component({
    selector: 'app-sidenav-list',
    templateUrl: './app-sidenav-list.component.html',
    styleUrls: ['./app-sidenav-list.component.scss'],
    animations: [divChangeHeightAnimation]
})
export class AppSidenavListComponent implements OnInit {
    @Output() closeSidenav: EventEmitter<void> = new EventEmitter<void>();

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

    onClose() {
        this.closeSidenav.emit();
    }

    changeState(): void {
        this.categoriesAnimationState = this.categoriesAnimationState === 'initial' ? 'final' : 'initial';
        localStorage.setItem('projectsAnimationState', this.categoriesAnimationState);
    }

    navigateToServices(id: number): void {
        this.router.navigate([`/categories/${id}/services`]);
    }
}
