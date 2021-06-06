import { NgModule } from '@angular/core';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatDividerModule} from '@angular/material/divider';
import {MatCardModule} from '@angular/material/card';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatChipsModule} from '@angular/material/chips';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatMenuModule} from '@angular/material/menu';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatDialogModule} from '@angular/material/dialog';
import {MatNativeDateModule} from '@angular/material/core';
import {MatTabsModule} from '@angular/material/tabs';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatButtonModule} from '@angular/material/button';
import {MatRadioModule} from '@angular/material/radio';
import {MatSortModule} from '@angular/material/sort';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatBadgeModule} from '@angular/material/badge';

const materialModules = [
    MatSidenavModule,
    MatDividerModule,
    MatCardModule,
    MatPaginatorModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatToolbarModule,
    MatTabsModule,
    MatListModule,
    MatExpansionModule,
    MatDatepickerModule,
    MatButtonModule,
    MatIconModule,
    MatCheckboxModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
    MatChipsModule,
    MatSnackBarModule,
    MatDialogModule,
    MatMenuModule,
    MatNativeDateModule,
    MatRadioModule,
    MatSortModule,
    MatButtonToggleModule,
    MatSlideToggleModule,
    MatBadgeModule
  ];

@NgModule({
    imports: [materialModules],
    exports: [materialModules],
    declarations: [],
})
export class MaterialModule { }
