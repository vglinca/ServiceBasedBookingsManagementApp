import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {AuthService} from '../../../services/auth.service';
import {Router} from '@angular/router';
import {ConfirmationDialogComponent} from '../confirmation-dialog/confirmation-dialog.component';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {NgOnDestroy} from '../../../services/on-destroy.service';
import {filter, shareReplay, switchMap, takeUntil, tap} from 'rxjs/operators';
import {ConfirmationDialogDataModel} from '../../../models/confirmation-dialog-data.model';
import {ChangePasswordComponent} from '../change-password/change-password.component';
import {BehaviorSubject, Observable} from 'rxjs';
import {MatSlideToggle, MatSlideToggleChange} from '@angular/material/slide-toggle';
import {AppThemeService} from '../../../services/app-theme.service';
import {SignalrHubService} from '../../../services/signalr-hub.service';
import * as signalR from '@aspnet/signalr';
import {NotificationsService} from '../../../services/notifications.service';
import {NotificationModel} from '../../../models/notification/notification.model';
import {Select} from '@ngxs/store';
import {CurrentUserState} from '../../../store/current-user.state';
import {environment} from '../../../../environments/environment';

@Component({
    selector: 'app-header',
    templateUrl: 'app-header.component.html',
    styleUrls: ['./app-header.component.scss'],
    providers: [NgOnDestroy]
})
export class AppHeaderComponent implements OnInit {

    @Input() isMenuButtonShown: boolean = false;
    @Output() toggleSidenav: EventEmitter<void> = new EventEmitter<void>();
    @ViewChild('toggleElement', {static: true}) public toggle: MatSlideToggle;

    @Select(CurrentUserState.userId) userId$: Observable<number>;

    public confirmationDialogRef: MatDialogRef<ConfirmationDialogComponent>;
    public toggleChecked: boolean = false;
    public hubConnection: signalR.HubConnection = null;
    public notifications: NotificationModel[] = [];
    public notificationsCount$: BehaviorSubject<number> = new BehaviorSubject<number>(0);
    public matBadgeHidden$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);

    constructor(
        private readonly authService: AuthService,
        private readonly dialog: MatDialog,
        private readonly onDestroy$: NgOnDestroy,
        private readonly themeService: AppThemeService,
        private readonly hubService: SignalrHubService,
        private readonly notificationService: NotificationsService,
        private readonly router: Router
    ) {
        this.themeService.load();
        this.toggleChecked = this.themeService.currentActive() === 'dark';
    }

    ngOnInit(): void {
        this.fetchNotifications();
        this.hubConnection = this.hubService.getConnection();
        //this.buildConnection();
        this.listen();
    }

    buildConnection(): void {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(`${environment.apiBaseUrl}/notificationsHub`, {
                accessTokenFactory: () => this.authService.getAccessToken()
            }).build();

        this.hubConnection
            .start()
            .then(() => console.log('Hub connection established.'))
            .catch((err) => console.log(err));
    }

    private listen(): void {
        this.hubConnection.on('NotifySpecialist', () => {
            console.log('Change');
            this.fetchNotifications();
        });
    }

    private fetchNotifications(): void {
        this.userId$.pipe(
            takeUntil(this.onDestroy$),
            filter(x => !isNaN(x)),
            switchMap((userId) => this.notificationService.getForUser(userId)),
            tap((data) => this.notificationsCount$.next(data.length)),
            tap((data) => this.matBadgeHidden$.next(data.length < 1)),
            shareReplay()
        ).subscribe(notifications => {
            this.notifications = notifications;
            console.log(notifications);
        });
    }

    toggleSidebar(): void {
        this.toggleSidenav.emit();
    }

    onSignOutClick(): void {
        this.confirmationDialogRef = this.dialog.open(ConfirmationDialogComponent, {
            disableClose: true,
            data: <ConfirmationDialogDataModel>{
                isWarning: false,
                title: 'Sign Out',
                message: 'Are you sure you want to Sign Out?',
                okButtonText: 'Yes',
                cancelButtonText: 'No'
            }
        });
        this.confirmationDialogRef.afterClosed()
            .pipe(
                takeUntil(this.onDestroy$),
                filter(res => res),
                switchMap(() => this.authService.signOut())
            ).subscribe((result) => {
                this.router.navigate(['/login']);
            });
    }

    navigateToAccount(): void {
        this.router.navigate(['/account']);
    }

    openChangePassword(): void {
        const dialogRef = this.dialog.open(ChangePasswordComponent, {
            disableClose: true,
            height: '420px',
            width: '400px'
        });

        dialogRef.afterClosed().pipe(
            filter(res => res),
            switchMap(() => this.openConfirmationDialog().pipe(
                filter(res => res),
                takeUntil(this.onDestroy$),
                switchMap(() => this.authService.signOut())
            )),
            takeUntil(this.onDestroy$)
        ).subscribe(() => {
            this.router.navigate(['/login']);
        });
    }

    private openConfirmationDialog(): Observable<boolean> {
        return this.dialog.open(ConfirmationDialogComponent, {
            disableClose: true,
            data: <ConfirmationDialogDataModel>{
                message: 'It\'s recommended to re-log in now. Proceed?',
                title: 'Warning'
            },
            width: '600px',
            height: '180px;'
        }).afterClosed();
    }

    toggleNightMode($event: MatSlideToggleChange): void {
        if ($event.checked) {
            this.toggle.checked = true;
            this.themeService.update('dark');
        } else {
            this.themeService.update('light');
        }
    }
}

