import {Component, Input, OnInit} from '@angular/core';
import {EmailRedirectionModel} from '../../../../models/email.redirection.model';

@Component({
    selector: 'app-complete-registration',
    templateUrl: './complete-registration.component.html',
    styleUrls: ['./complete-registration.component.scss']
})

export class CompleteRegistrationComponent implements OnInit {

    @Input() emailRedirectionModel: EmailRedirectionModel;
    constructor() {}

    ngOnInit(): void {
    }

    redirectToEmailSite(): void {
        (window as any).location = this.emailRedirectionModel.redirectTo;
    }
}
