import { NgModule } from '@angular/core';
import {CommonModule, NgFor} from '@angular/common';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatButtonModule} from "@angular/material/button";
import {MatSelectModule} from "@angular/material/select";
import {MatRadioModule} from "@angular/material/radio";
import { ScheduleComponent } from './schedule/schedule.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatNativeDateModule} from '@angular/material/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTableModule} from "@angular/material/table";
import {MatCheckboxModule} from "@angular/material/checkbox";
import {MatCardModule} from "@angular/material/card";
import { ViewAppointmentsDoctorComponent } from './view-appointments-doctor/view-appointments-doctor.component';
import { CreateBlogComponent } from './create-blog/create-blog.component';
import { AllBlogsComponent } from './all-blogs/all-blogs.component';
import { CreateInternalDataComponent } from './create-internal-data/create-internal-data.component';
import { ViewInternalDataPatientComponent } from './view-internal-data-patient/view-internal-data-patient.component';
import {MatInputModule} from "@angular/material/input";
import { SpecialistScheduleComponent } from './specialist-schedule/specialist-schedule.component';
import {AllDIrectionsComponent} from './all-directions/all-directions.component';
import {MatDialogModule} from "@angular/material/dialog";
import { ViewAppointmentsPatientComponent } from './view-appointments-patient/view-appointments-patient.component';
import { CreateDirectionComponent } from './create-direction/create-direction.component';
import { CreateReportComponent } from './create-report/create-report.component';
import { ViewReportsPatientComponent } from './view-reports-patient/view-reports-patient.component';
import { SuspiciousUsersComponent } from './suspicious-users/suspicious-users.component';
import { CreateNotificationComponent } from './create-notification/create-notification.component';

import { GraphTableComponent } from './graph/graph-table/graph-table.component';
import {NgxChartsModule} from "@swimlane/ngx-charts";
import { FatsComponent } from './graph/fats/fats.component';
import { CanvasJSAngularChartsModule } from '@canvasjs/angular-charts';
import { WeightComponent } from './graph/weight/weight.component';
import { BloodSugarComponent } from './graph/blood-sugar/blood-sugar.component';


@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    ScheduleComponent,
    ViewAppointmentsDoctorComponent,
    CreateBlogComponent,
    AllBlogsComponent,
    CreateInternalDataComponent,
    ViewInternalDataPatientComponent,
    SpecialistScheduleComponent,
    AllDIrectionsComponent,
    ViewAppointmentsPatientComponent,
    ViewInternalDataPatientComponent,
    CreateDirectionComponent,
    CreateReportComponent,
    ViewReportsPatientComponent,
    SuspiciousUsersComponent,
    CreateNotificationComponent,
    GraphTableComponent,
     FatsComponent,
     WeightComponent,
     BloodSugarComponent,

  ],
  imports: [
    MatNativeDateModule,
    MatDatepickerModule,
    MatFormFieldModule,
    CommonModule,
    AppRoutingModule,
    MatToolbarModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatRadioModule,
    MatTableModule,
    MatCardModule,
    MatCheckboxModule,
    FormsModule,
    MatRadioModule,
    NgFor,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
    NgxChartsModule,
    CanvasJSAngularChartsModule

  ]
})
export class PagesModule { }
