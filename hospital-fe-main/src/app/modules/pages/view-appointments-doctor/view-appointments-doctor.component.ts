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
  displayedColumns: string[] = ['Time', 'Patient', 'Direction'];
  dataSource : any[] = [];

  constructor(private appointmentService:AppointmentService) { }



  ngOnInit(): void {

    this.appointmentService.GetAllAppointmentsByDoctor().subscribe((data ) => {
      this.dataSource = data;
  });
  }

  direction(){

  }

}
