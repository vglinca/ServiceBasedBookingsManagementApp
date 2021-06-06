import {Injectable} from '@angular/core';
import * as signalR from '@aspnet/signalr';
import {environment} from '../../environments/environment';
import {AuthService} from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class SignalrHubService {
    private _connection: signalR.HubConnection;

    getConnection(): signalR.HubConnection {
        return this._connection;
    }

    constructor(private readonly authService: AuthService) {
        this.buildConnection();
    }

    buildConnection(): void {
        this._connection = new signalR.HubConnectionBuilder()
            .withUrl(`${environment.apiBaseUrl}/notificationsHub`, {
                accessTokenFactory: () => this.authService.getAccessToken()
            }).build();

        this._connection
            .start()
            .then(() => console.log('Hub connection established.'))
            .catch((err) => console.log(err));
    }
}
