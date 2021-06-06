import {Component, Inject, OnInit} from '@angular/core';
import {PositionsService} from '../../../services/positions.service';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {NgOnDestroy} from '../../../services/on-destroy.service';
import {PositionModel} from '../../../models';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {SnackbarNotificationService} from '../../../services/snackbar-notification.service';
import {HttpErrorResponse} from '@angular/common/http';
import {AuthService} from '../../../services/auth.service';
import {Select} from '@ngxs/store';
import {CurrentUserState} from '../../../store/current-user.state';
import {Observable} from 'rxjs';
import {filter, takeUntil} from 'rxjs/operators';

@Component({
    selector: 'position-form',
    templateUrl: './position-form.component.html',
    styleUrls: ['./position-form.component.scss'],
    providers: [NgOnDestroy]
})
export class PositionFormComponent implements OnInit {

    @Select(CurrentUserState.getCompanyId) companyId$: Observable<number>;

    readonly messageEditSuccessfully: string = 'Position successfully updated.';
    readonly messageEditError: string = 'Could not update position.';
    readonly messageAddedSuccessfully: string = 'Position successfully created.';
    readonly messageAddError: string = 'Could not add a new position.';

    editing: boolean = false;
    model: PositionModel;
    positionForm: FormGroup;
    companyId: number;

    constructor(
        @Inject(MAT_DIALOG_DATA) public positionId: number,
        private readonly positionService: PositionsService,
        private readonly authService: AuthService,
        private readonly dialogRef: MatDialogRef<PositionFormComponent>,
        private readonly onDestroy$: NgOnDestroy,
        private readonly formBuilder: FormBuilder,
        private readonly snackBarService: SnackbarNotificationService
    ) {
        this.editing = this.positionId !== 0;
        this.companyId$.pipe(takeUntil(this.onDestroy$), filter(x => x > 0))
            .subscribe((id) => this.companyId = id);
    }

    ngOnInit(): void {
        this.initForm();
        if(this.editing){
            this.positionService.getPositionById(this.positionId)
                .subscribe((pos) => {
                    this.model = pos;
                    this.positionForm.controls['name'].setValue(this.model.name);
                    this.positionForm.controls['description'].setValue(this.model.description);
                });
            return;
        }
    }

    private initForm(): void {
        this.positionForm = this.formBuilder.group({
            name: new FormControl('', [Validators.required]),
            description: new FormControl('', [
                Validators.required, Validators.maxLength(500)])
        });
    }

    closeDialog(): void {
        this.dialogRef.close(false);
    }

    submit(): void {
        if(this.editing){
            this.positionService.updatePosition(this.positionId, {...this.positionForm.value})
                .subscribe(() => {
                    this.snackBarService.openSuccess(this.messageEditSuccessfully);
                    this.dialogRef.close(true)
                }, (error: HttpErrorResponse) => {
                    this.snackBarService.openErrorWithResponseMessage(this.messageEditError, error);
                    this.dialogRef.close(false);
                });
            return;
        }
        this.positionService.addPosition(this.companyId, {...this.positionForm.value})
            .subscribe(() => {
                this.snackBarService.openSuccess(this.messageAddedSuccessfully);
                this.dialogRef.close(true);
            }, (error: HttpErrorResponse) => {
                this.snackBarService.openErrorWithResponseMessage(this.messageAddError, error);
                this.dialogRef.close(false);
            });
    }
}
