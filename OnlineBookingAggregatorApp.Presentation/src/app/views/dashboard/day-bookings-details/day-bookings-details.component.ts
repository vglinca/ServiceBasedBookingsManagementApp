import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {BookingCalendarEventModel} from '../../../models';
import {TimeUtils} from '../../../utils/time.utils';
import * as _ from 'lodash';

@Component({
    selector: 'app-day-bookings-details',
    templateUrl: './day-bookings-details.component.html',
    styleUrls: ['./day-bookings-details.component.scss']
})
export class DayBookingsDetailsComponent implements OnInit {
    public bookings: BookingCalendarEventModel[] = [];
    constructor(
        @Inject(MAT_DIALOG_DATA) public data : {day: Date, bookings: BookingCalendarEventModel[]},
        private readonly dialogRef: MatDialogRef<DayBookingsDetailsComponent>
    ) {
    }

    ngOnInit(): void {
        this.bookings = _.sortBy(this.data.bookings, ['dateFrom', 'dateTo']);
    }

    public getTime(date: Date): string {
        return TimeUtils.toShortTime(date);
    }

    close(): void {
        this.dialogRef.close(true);
    }
}
