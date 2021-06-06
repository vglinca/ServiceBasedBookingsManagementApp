import {BookingModel} from './booking.model';
import {EventColor} from 'calendar-utils';
import {EmployeeSelectionModel} from '../employee/employee-selection.model';
import {BookingStateModel} from '../lookup/booking-state.model';

export class BookingCalendarEventModel {
    public id: number;
    public clientId: number;
    public serviceId: number;
    public specialistId: number;
    public firstName: string;
    public lastName: string;
    public email: string;
    public phone: string;
    public specialist: string;
    public dateFrom: Date;
    public dateTo: Date;
    public colour: EventColor;
    public colourId: number;
    public comments: string;
    public specialistModel: EmployeeSelectionModel;
    public state: BookingStateModel;

    public static fromBooking(model: BookingModel, specialist: EmployeeSelectionModel = null): BookingCalendarEventModel {
        if(!model){
            return undefined;
        }

        return <BookingCalendarEventModel> {
            id: model.id,
            clientId: model.clientId,
            serviceId: model.serviceId,
            specialistId: model.specialistId,
            dateFrom: model.dateFrom,
            dateTo: model.dateTo,
            firstName: model.firstName,
            lastName: model.lastName,
            email: model.email,
            phone: model.phone,
            specialist: model.specialist,
            colour: <EventColor>{primary: model.colour.primary, secondary: model.colour.secondary},
            colourId: model.colour.id,
            specialistModel: specialist,
            comments: model.comments
        };
    }
}
