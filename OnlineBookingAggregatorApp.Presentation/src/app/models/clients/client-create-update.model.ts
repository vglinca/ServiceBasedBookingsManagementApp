import {Gender} from '../../enums/gender';
import {ClientCategory} from '../../enums/client-category';

export class ClientCreateUpdateModel {
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
    additionalPhoneNumber: string;
    comments: string;
    gender?: Gender;
    dateOfBirth?: Date;
    clientCategory: ClientCategory;
}
