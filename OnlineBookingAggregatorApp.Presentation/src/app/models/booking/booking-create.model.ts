export class BookingCreateModel {
    clientId: number | undefined;
    clientFirstName?: string | undefined;
    clientLastName?: string | undefined;
    clientEmail?: string | undefined;
    clientPhone?: string | undefined;
    serviceId!: number;
    colourId: number;
    dateFrom!: Date;
    hourFrom: number;
    minutesFrom: number;
    dateTo!: Date;
    hourTo: number;
    minutesTo: number;
    comments?: string | undefined;
    specialistId!: number;
    clientBirthDate?: Date | undefined;
}
