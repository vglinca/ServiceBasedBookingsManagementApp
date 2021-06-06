export class UserModel {
    userId: number;
    firstName: string;
    lastName: string;
    email: string;
    companyId?:number;
    role: string;
    permissions: string[];
    dateOfBirth: Date;
}
