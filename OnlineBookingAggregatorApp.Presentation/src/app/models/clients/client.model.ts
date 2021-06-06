import {ClientCategory} from '../../enums/client-category';
import {Gender} from '../../enums/gender';

export class ClientModel {
    id: number = 0;
    firstName: string;
    lastName: string;
    phoneNumber: string;
    additionalPhoneNumber: string;
    email: string;
    clientCategory: string;
    clientCategoryId: ClientCategory;
    gender: string;
    genderId?: Gender;
    dateOfBirth?: Date;
    comments: string;
}
