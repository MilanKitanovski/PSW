import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./modules/pages/home/home.component";
import {LoginComponent} from "./modules/pages/login/login.component";
import {RegisterComponent} from "./modules/pages/register/register.component";
import {ScheduleComponent} from "./modules/pages/schedule/schedule.component";
import {ViewAppointmentsDoctorComponent} from "./modules/pages/view-appointments-doctor/view-appointments-doctor.component";
import {CreateBlogComponent} from "./modules/pages/create-blog/create-blog.component";
import {AllBlogsComponent} from "./modules/pages/all-blogs/all-blogs.component";
import {CreateInternalDataComponent} from "./modules/pages/create-internal-data/create-internal-data.component";
import {
  ViewInternalDataPatientComponent
} from "./modules/pages/view-internal-data-patient/view-internal-data-patient.component";
import {SpecialistScheduleComponent} from "./modules/pages/specialist-schedule/specialist-schedule.component";
import {AllDIrectionsComponent} from "./modules/pages/all-directions/all-directions.component";
import {ViewAppointmentsPatientComponent} from "./modules/pages/view-appointments-patient/view-appointments-patient.component";
import {CreateDirectionComponent} from "./modules/pages/create-direction/create-direction.component";
import {CreateReportComponent} from "./modules/pages/create-report/create-report.component";
import {ViewReportsPatientComponent} from "./modules/pages/view-reports-patient/view-reports-patient.component";
import {RoleGuardService} from "./modules/hospital/auth/role-guard.service";
import {SuspiciousUsersComponent} from "./modules/pages/suspicious-users/suspicious-users.component";
import {NavbarComponent} from "./modules/pages/navbar/navbar.component";
import {CreateNotificationComponent} from "./modules/pages/create-notification/create-notification.component";
import {GraphTableComponent} from "./modules/pages/graph/graph-table/graph-table.component";
import {FatsComponent} from "./modules/pages/graph/fats/fats.component";
import {BloodBankNewsComponent} from "./modules/pages/blood-bank-news/blood-bank-news.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent,canActivate:[RoleGuardService] ,data: {role:['anon']}},
  { path: 'register', component: RegisterComponent,canActivate:[RoleGuardService] ,data: {role:['anon']}},
  { path: '', redirectTo: '/register', pathMatch: 'full'},
  { path: 'regularSchedule', component: ScheduleComponent , canActivate:[RoleGuardService] ,data: {role:['Patient']}},
  { path: 'allAppointments', component: ViewAppointmentsDoctorComponent, canActivate:[RoleGuardService] ,data: {role:['Doctor']}},
  { path: 'createBlog', component: CreateBlogComponent, canActivate:[RoleGuardService] ,data: {role:['Doctor']}},
  { path: 'allBlogs', component:AllBlogsComponent, canActivate:[RoleGuardService] ,data: {role:['Doctor', 'Patient', 'Admin']}},
  { path: 'createIData', component: CreateInternalDataComponent, canActivate:[RoleGuardService] ,data: {role:['Patient']}},
  { path: 'allIDatas', component: ViewInternalDataPatientComponent, canActivate:[RoleGuardService] ,data: {role:['Patient']}},
  { path: 'specialistSchedule', component: SpecialistScheduleComponent, canActivate:[RoleGuardService] ,data: {role:['Patient']}},
  { path: 'allDirections', component: AllDIrectionsComponent, canActivate:[RoleGuardService] ,data: {role:['Patient']}},
  { path: "allAppointmentsPatient", component: ViewAppointmentsPatientComponent, canActivate:[RoleGuardService] ,data: {role:['Patient']}},
  { path: "createDirection", component: CreateDirectionComponent, canActivate:[RoleGuardService] ,data: {role:['Doctor']}},
  { path: "createReport", component: CreateReportComponent, canActivate:[RoleGuardService] ,data: {role:['Doctor']}},
  { path: "createNotification", component: CreateNotificationComponent, canActivate:[RoleGuardService] ,data: {role:['Admin']}},
  { path: "allReports", component: ViewReportsPatientComponent, canActivate:[RoleGuardService] ,data: {role:['Patient']}},
  { path: "suspiciousUsers", component: SuspiciousUsersComponent, canActivate:[RoleGuardService], data:{role:['Admin']}},
  { path: "graph", component: GraphTableComponent, canActivate:[RoleGuardService], data:{role:['Patient']}},
  { path: "news", component: BloodBankNewsComponent, canActivate:[RoleGuardService], data:{role:['Admin']}},
  { path: '*', redirectTo: '/register',},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
