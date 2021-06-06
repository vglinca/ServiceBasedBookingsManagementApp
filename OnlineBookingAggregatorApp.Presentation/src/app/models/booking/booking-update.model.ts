import {BookingState} from '../../enums/booking-state';

export class BookingUpdateModel {
    clientId: number | undefined;
    serviceId!: number;
    dateFrom!: Date;
    hourFrom: number;
    minutesFrom: number;
    dateTo!: Date;
    hourTo: number;
    minutesTo: number;
    comments?: string | undefined;
    specialistId!: number;
    colour?: number;
    state: BookingState;
    isFromResize: boolean = false;
}
