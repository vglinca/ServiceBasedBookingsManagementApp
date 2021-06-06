import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';

@Component({
    selector: 'warning-dialog',
    templateUrl: './warning-dialog.component.html',
    styleUrls: ['./warning-dialog.component.scss']
})
export class WarningDialogComponent implements OnInit {

    title: string;
    message: string;

    constructor(
        public dialogRef: MatDialogRef<WarningDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: {title: string, message: string}
    ) {}

    ngOnInit(): void {
        this.title = this.data.title || 'Warning';
        this.message = this.data.message || 'This item can not be deleted.';
    }

    confirm(): void {
        this.dialogRef.close(true);
    }
}
