import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {ConfirmationDialogDataModel} from '../../../models/confirmation-dialog-data.model';

@Component({
    selector: 'confirmation-dialog',
    templateUrl: './confirmation-dialog.component.html',
    styleUrls: ['./confirmation-dialog.component.scss']
})

export class ConfirmationDialogComponent implements OnInit {

    title: string;
    message: string;
    cancelButtonText: string;
    okButtonText: string;
    isWarning: boolean = false;

    constructor(
        public dialogRef: MatDialogRef<ConfirmationDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: ConfirmationDialogDataModel
    ) {}

    ngOnInit(): void {
        if(!this.data){
            this.data = <ConfirmationDialogDataModel>{
                title: null,
                message: null,
                cancelButtonText: null,
                okButtonText: null,
                isWarning: false
            };
        }

        this.title = this.data.title || 'Confirmation';
        this.message = this.data.message || 'Do You want to leave this page? No changes will be saved after.';
        this.okButtonText = this.data.okButtonText || 'Yes';
        this.cancelButtonText = this.data.cancelButtonText || 'No';
        this.isWarning = this.data.isWarning;
    }

    onConfirm(): void {
        this.dialogRef.close(true);
    }

    onCancel(): void {
        this.dialogRef.close(false);
    }
}
