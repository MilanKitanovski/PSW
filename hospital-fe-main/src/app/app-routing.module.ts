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

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: '', redirectTo: '/register', pathMatch: 'full'},
  { path: 'regularSchedule', component: ScheduleComponent},
  { path: 'allAppointments', component: ViewAppointmentsDoctorComponent},
  { path: 'createBlog', component: CreateBlogComponent},
  { path: 'allBlogs', component:AllBlogsComponent},
  { path: 'createIData', component: CreateInternalDataComponent},
  { path: 'allIDatas', component: ViewInternalDataPatientComponent},
  { path: 'specialistSchedule', component: SpecialistScheduleComponent},
  { path: 'allDirections', component: AllDIrectionsComponent},
  { path: "allAppointmentsPatient", component: ViewAppointmentsPatientComponent},
  { path: "createDirection", component: CreateDirectionComponent},
  { path: "createReport", component: CreateReportComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
