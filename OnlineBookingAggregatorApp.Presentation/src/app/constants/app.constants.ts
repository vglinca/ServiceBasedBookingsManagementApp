import {HttpHeaders} from '@angular/common/http';

export const EMAIL_PATTERN: string = '^(?!.*\\.{2})(?:[A-Za-z0-9_-]+(?:\\.[A-Za-z0-9_-]+)*|(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)@(?:(?:[A-Za-z0-9-](?:[A-Za-z0-9-]*[A-Za-z0-9-])?\\.)+[A-Za-z0-9-](?:[A-Za-z0-9-]*[A-Za-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[A-Za-z0-9-]*[A-Za-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\\])+$';
export const POSITIVE_NUMBER_PATTERN: string = '^[+]?\\d+([.]\\d+)?$';

export const JSON_CONTENT_TYPE = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' })
};

export const REQUEST_OPTIONS = {
    observe: "response",
    headers: new HttpHeaders({
        "Accept": "application/json"
    })
};

export class UserClaims{
    static readonly FIRST_NAME: string = 'FirstName';
    static readonly LAST_NAME: string = 'LastName';
    static readonly SUB: string = 'UserId';
    static readonly COMPANY_ID = 'CompanyId';
    static readonly EMAIL: string = 'email';
    static readonly USER_POLICIES: string = 'UserPolicies';
    static readonly DOB: string = 'DateOfBirth';
}
