import {ClientCategory} from '../../enums/client-category';
import {BookingColourModel} from './booking-colour.model';
import {BookingState} from '../../enums/booking-state';

export class BookingModel {
    id: number;
    clientId: number;
    serviceId: number;
    specialistId: number;
    firstName: string;
    lastName: string;
    email: string;
    phone: string;
    additionalPhone: string;
    specialist: string;
    dateFrom: Date;
    dateTo: Date;
    comments: string;
    clientCategory: ClientCategory;
    clientBirthDate?: Date;
    colour: BookingColourModel;
    state: BookingState;
}
