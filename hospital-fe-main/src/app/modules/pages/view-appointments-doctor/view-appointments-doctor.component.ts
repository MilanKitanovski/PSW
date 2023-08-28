import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {SearchAppointmentResultDTO} from "../../hospital/model/searchAppointmentResultDTO";
import {ViewAppointmentByDoctorDTO} from "../../hospital/model/viewAppointmentByDoctorDTO";
import {AppointmentService} from "../../hospital/services/appointment.service";
import {SearchAppointmentDTO} from "../../hospital/model/searchAppointmentDTO";
import {range} from "rxjs";
import {DateRange} from "../../hospital/model/date-range.model";
import {RegisterComponent} from "../register/register.component";
import {Register} from "../../hospital/model/register.model";
import {SpecialistScheduleComponent} from "../specialist-schedule/specialist-schedule.component";
import {MatDialog} from "@angular/material/dialog";
import {CreateDirectionComponent} from "../create-direction/create-direction.component";
import {CreateReportComponent} from "../create-report/create-report.component";

const today = new Date();
const month = today.getMonth();
const year = today.getFullYear();

@Component({
  selector: 'app-view-appointments-doctor',
  templateUrl: './view-appointments-doctor.component.html',
  styleUrls: ['./view-appointments-doctor.component.css']
})
export class ViewAppointmentsDoctorComponent implements OnInit {

  campaignOne = new FormGroup({
    start: new FormControl(new Date(year, month, 13)),
    end: new FormControl(new Date(year, month, 16)),
  });
  displayedColumns: string[] = ['Time', 'Patient', 'Direction', 'Report'];
  dataSource : any[] = [];

  constructor(private appointmentService:AppointmentService, public dialog: MatDialog) { }



  ngOnInit(): void {

    this.appointmentService.GetAllAppointmentsByDoctor().subscribe((data ) => {
      this.dataSource = data;
  });
  }

  direction(dto : any){
    const dialogRef = this.dialog.open(CreateDirectionComponent, {
      data: dto  // Pass the element to the dialog component
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });

  }

  report(dto : any){
    const dialogRef = this.dialog.open(CreateReportComponent, {
      data: dto  // Pass the element to the dialog component
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

}
