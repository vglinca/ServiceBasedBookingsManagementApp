import * as moment from 'moment';

enum ComparisonTypes {
    SMALLER,
    SMALLER_OR_EQUAL,
    GREATER,
    GREATER_OR_EQUAL,
    EQUAL
}

export class TimeUtils {
    // convert to hh:mm AM/PM format
    public static convertTime(time: string): string {
        return moment(time, 'hh:mm').format('hh:mm A');
    }

    public static convertSecondsToMdh(seconds: number): string {
        seconds = Number(seconds);
        const time = moment.duration(seconds, 'seconds');
        const h: number = Math.floor(time.asHours());
        const d: number = Math.floor(time.asDays());
        const m: number = Math.floor(time.asMonths());

        if (m > 0) {
            return m + (m === 1 ? ' month' : ' months');
        }

        if (d > 0) {
            return d + (d === 1 ? ' day' : ' days');
        }

        return h + (h === 1 ? ' hour' : ' hours');
    }

    // Example: return Jan-18
    public static getShortDate(date: Date): string {
        return moment(date).format('ll');
    }

    // Example: return Jan 2018
    public static getMonthNameFullYear(date: Date): string {
        return moment(date).format('MMM YYYY');
    }

    // format dd/MM/yyyy
    public static shortDate(date: Date): string {
        return moment(date, 'DD/MM/YYYY').format('DD/MM/YYYY');
    }

    // format dd-MM-yyyy
    public static dashShortDate(date: Date): string {
        return moment(date, 'DD-MM-YYYY').format('DD-MM-YYYY');
    }

    // format dd MMM yyyy
    public static toMonthNameDate(date: Date): string {
        return moment(date).format('DD MMM YYYY');
    }

    // format dd MMM yyyy
    public static toMonthNameAndTime(date: Date,): string {
        return moment(date).format('DD MMM HH:mm');
    }

    // format h: mm a
    public static toShortTime(date: Date): string {
        return moment(date).format('HH:mm');
    }

    public static setTimeToDate(date: Date, time: string): Date {
        if(!date || !time){
            return;
        }
        const splitTime: string[] = time.split(':');
        const hours: number = Number.parseInt(splitTime[0]);
        const minutes: number = Number.parseInt(splitTime[1]);
        date.setHours(hours);
        date.setMinutes(minutes);

        return date;
    }

    // returns date with no time
    public static getDate(date: Date): Date {
        if (!date) {
            return;
        }
        date.setHours(0, 0, 0, 0);
        return date;
    }

    // format YYYY-MM-DD
    public static getSimpleDateString(date: Date): string {
        return moment(date).format('YYYY-MM-DD');
    }

    public static getDateFormat(date: Date, format: string): Date {
        if (!date) { return null; }
        const formattedDate = moment(date).format(format);
        return moment(formattedDate, format).isValid() ? new Date(formattedDate) : null;
    }

    // compare dates
    public static isGreaterThan(sourceDate: Date, targetDate: Date, format: string = 'DD-MM-YYYY'): boolean {
        return this.compareDates(sourceDate, targetDate, format, ComparisonTypes.GREATER);
    }

    public static isGreaterThanOrEqual(sourceDate: Date, targetDate: Date, format: string = 'DD-MM-YYYY'): boolean {
        return this.compareDates(sourceDate, targetDate, format, ComparisonTypes.GREATER_OR_EQUAL);
    }

    public static isSmallerThan(sourceDate: Date, targetDate: Date, format: string = 'DD-MM-YYYY'): boolean {
        return this.compareDates(sourceDate, targetDate, format, ComparisonTypes.SMALLER);
    }

    public static isSmallerThanOrEqual(sourceDate: Date, targetDate: Date, format: string = 'DD-MM-YYYY'): boolean {
        return this.compareDates(sourceDate, targetDate, format, ComparisonTypes.SMALLER_OR_EQUAL);
    }

    public static areEqual(sourceDate: Date, targetDate: Date, format: string = 'DD-MM-YYYY'): boolean {
        return this.compareDates(sourceDate, targetDate, format, ComparisonTypes.EQUAL);
    }

    public static isValidDate(date: any): boolean {
        return moment(date).isValid();
    }

    public static normalizeDate(date: Date): Date {
        return new Date(
            Date.UTC(
                date.getFullYear(),
                date.getMonth(),
                date.getDate()
            )
        );
    }

    private static compareDates(sourceDate: Date, targetDate: Date, format: string, comparisonType: ComparisonTypes): boolean {
        const srcDate = this.getDateFormat(sourceDate, format);
        const tgDate = this.getDateFormat(targetDate, format);
        if (!srcDate || !tgDate) {
            return null;
        } else {
            const src = srcDate.getTime();
            const tg = tgDate.getTime();
            switch (comparisonType) {
                case ComparisonTypes.EQUAL: return src === tg;
                case ComparisonTypes.GREATER: return src > tg;
                case ComparisonTypes.GREATER_OR_EQUAL: return src >= tg;
                case ComparisonTypes.SMALLER: return src < tg;
                case ComparisonTypes.SMALLER_OR_EQUAL: return src <= tg;
                default: return null;
            }
        }
    }
}
