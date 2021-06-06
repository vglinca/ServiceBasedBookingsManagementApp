import {BookingState} from '../../enums/booking-state';

export class BookingPageModel {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    phone: string;
    specialistFirstName: string;
    specialistLastName: string;
    dateFrom: Date;
    dateTo: Date;
    stateId: BookingState;
    state: string;
}
