import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {AllLookupsService} from '../../../../services/all-lookups.service';
import {BehaviorSubject, Observable} from 'rxjs';
import {fromPromise} from 'rxjs/internal-compatibility';
import {uniqueEmailValidator} from '../../../../validators/unique-email.validator';
import {GenderModel} from '../../../../models';
import {UsersService} from '../../../../services/users.service';
import {EmployeeModel} from '../../../../models';
import {PositionsService} from '../../../../services/positions.service';
import {PositionModel} from '../../../../models';
import {NgOnDestroy} from '../../../../services/on-destroy.service';
import {AuthService} from '../../../../services/auth.service';
import {takeUntil} from 'rxjs/operators';
import {RoleModel} from '../../../../models';
import {MatSelectChange} from '@angular/material/select';
import {MatDialog} from '@angular/material/dialog';
import {WarningDialogComponent} from '../../../../shared/components/warning-dialog/warning-dialog.component';
import {PhoneInputComponent} from '../../../../shared/components/phone-input/phone-input.component';

@Component({
    selector: 'employee-information',
    templateUrl: './employee-information.component.html',
    styleUrls: ['./employee-information.component.scss'],
    providers: [NgOnDestroy]
})
export class EmployeeInformationComponent implements OnInit {

    @Input() employee$: BehaviorSubject<EmployeeModel> = new BehaviorSubject<EmployeeModel>(null);
    @ViewChild('phoneInput', {static: false}) public phoneInput: PhoneInputComponent;

    employeeInfoForm: FormGroup;
    genders$: Observable<GenderModel[]>;
    positions$: Observable<PositionModel[]>;
    roles$: Observable<RoleModel[]>;

    phoneNumber: string = null;

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly lookupService: AllLookupsService,
        private readonly usersClient: UsersService,
        private readonly positionsService: PositionsService,
        private readonly authService: AuthService,
        private readonly onDestroy$: NgOnDestroy,
        public dialog: MatDialog
    ) {
        this.genders$ = fromPromise(this.lookupService.getGenders());
        this.roles$ = fromPromise(this.lookupService.getRoles());
    }

    ngOnInit(): void {
        this.positions$ = this.positionsService.getPositionsForSelect(this.authService.getCurrentUser().companyId);
        this.employee$.pipe(takeUntil(this.onDestroy$)).subscribe((employee) => {
            this.phoneNumber = employee?.phoneNumber;
            this.employeeInfoForm = this.formBuilder.group({
                firstName: new FormControl(employee?.firstName || '', Validators.required),
                lastName: new FormControl(employee?.lastName || '', Validators.required),
                email: new FormControl(employee?.email || '',
                    [Validators.email, Validators.required], uniqueEmailValidator(this.usersClient)),
                //phone: new FormControl(employee?.phoneNumber || '', [Validators.required]),
                gender: new FormControl(employee?.gender || ''),
                positionId: new FormControl(employee?.positionId || ''),
                specialization: new FormControl(employee?.specialization || ''),
                information: new FormControl(employee?.information || ''),
                role: new FormControl(employee?.roleId || '')
            });
        });
    }

    onRoleSelectionChange($event: MatSelectChange): void {
        this.dialog.open(WarningDialogComponent, {
            disableClose: true,
            data: {
                title: 'Employee Role',
                message: 'You are about to change the employee\'s role'
            }
        });
    }
}
