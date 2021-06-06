import {Injectable} from '@angular/core';
import {
    MatSnackBar,
    MatSnackBarConfig,
    MatSnackBarHorizontalPosition, MatSnackBarRef,
    MatSnackBarVerticalPosition,
    SimpleSnackBar
} from '@angular/material/snack-bar';
import {HttpErrorResponse} from '@angular/common/http';

@Injectable({providedIn: 'root'})
export class SnackbarNotificationService {

    constructor(public readonly snackBar: MatSnackBar) {}

    open(
        message: string,
        duration?: number,
        panelClass?: string | string[],
        positionVertical?: MatSnackBarVerticalPosition,
        positionHorizontal?: MatSnackBarHorizontalPosition,
        action?: string
    ): MatSnackBarRef<SimpleSnackBar> {
        const config = new MatSnackBarConfig();

        config.duration = duration || 4000;
        config.panelClass = panelClass || ['snack-bar-default'];
        config.verticalPosition = positionVertical || 'top';
        config.horizontalPosition = positionHorizontal || 'center';

        return this.snackBar.open(message, action, config);
    }

    openSuccess(
        message: string,
        duration?: number,
        positionVertical?: MatSnackBarVerticalPosition,
        positionHorizontal?: MatSnackBarHorizontalPosition,
        action?: string
    ): MatSnackBarRef<SimpleSnackBar> {
        return this.open(message, duration, ['snack-bar-success'], positionVertical, positionHorizontal, action);
    }

    openWarning(message: string,
                duration?: number,
                positionVertical?: MatSnackBarVerticalPosition,
                positionHorizontal?: MatSnackBarHorizontalPosition,
                action?: string
    ): MatSnackBarRef<SimpleSnackBar> {
        return this.open(message, duration, ['snack-bar-warning'], positionVertical, positionHorizontal, action);
    }

    openError(
        message: string,
        duration?: number,
        positionVertical?: MatSnackBarVerticalPosition,
        positionHorizontal?: MatSnackBarHorizontalPosition,
        action?: string
    ): MatSnackBarRef<SimpleSnackBar> {
        return this.open(message, duration, ['snack-bar-error'], positionVertical, positionHorizontal, action);
    }

    openErrorWithResponseMessage(
        message: string,
        error?: HttpErrorResponse,
        duration?: number,
        positionVertical?: MatSnackBarVerticalPosition,
        positionHorizontal?: MatSnackBarHorizontalPosition,
        action?: string
    ): MatSnackBarRef<SimpleSnackBar> {
        if (!navigator.onLine) {
            this.openOfflineMessage();
        } else if (error.error && error.error instanceof Object) {
            const values = <Array<string>>Object.values(error.error);
            message = values[0];
            for (let i = 1; i < values.length; i++) {
                message = `${message};\n${values[i]}`;
            }
        }
        return this.open(message, duration, ['snack-bar-error'], positionVertical, positionHorizontal, action);
    }

    private openOfflineMessage(
        message: string = 'You are offline. Please check your internet connection',
        duration?: number
    ): MatSnackBarRef<SimpleSnackBar> {
        return this.openWarning(message, duration);
    }

    private openOnlineMessage(message: string = 'You are online!', duration?: number): MatSnackBarRef<SimpleSnackBar> {
        return this.openSuccess(message, duration);
    }
}
