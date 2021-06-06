import {Component, HostListener, OnInit, ViewChild} from '@angular/core';
import {MatSidenav} from '@angular/material/sidenav';
import {fadeAnimation} from '../animations/fade.animation';
import {RouterOutlet} from '@angular/router';

@Component({
    selector: 'app-default',
    templateUrl: './app-default.component.html',
    styleUrls: ['./app-default.component.scss'],
    animations: [fadeAnimation]
})
export class AppDefaultComponent implements OnInit{

    @ViewChild('sidenav', {static: true}) sidenav: MatSidenav;
    isSideNavVisible: boolean = false;
    constructor() {
    }

    ngOnInit(): void {
        this.toggleSidebar(window.innerWidth);
    }

    @HostListener('window:resize', ['$event'])
    onWindowResize(event): void {
        this.toggleSidebar(window.innerWidth);
    }

    toggleSidebar(width: number): void {
        this.isSideNavVisible = width > 700;

        if(this.isSideNavVisible && this.sidenav && this.sidenav.opened){
            this.sidenav.close();
        }
    }

    getRouterOutletState = (outlet: RouterOutlet) => outlet.isActivated ? outlet.activatedRoute : '';
}
