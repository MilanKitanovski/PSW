import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {AppointmentService} from "../../hospital/services/appointment.service";
import {ViewAppointmentByPatientDTO} from "../../hospital/model/ViewAppointmentByPatientDTO";
import {ScheduleAppointmentDTO} from "../../hospital/model/scheduleAppointmentDTO";

const today = new Date();
const month = today.getMonth();
const year = today.getFullYear();
@Component({
  selector: 'app-view-appointments-patient',
  templateUrl: './view-appointments-patient.component.html',
  styleUrls: ['./view-appointments-patient.component.css']
})
export class ViewAppointmentsPatientComponent implements OnInit {
  campaignOne = new FormGroup({
    start: new FormControl(new Date(year, month, 13)),
    end: new FormControl(new Date(year, month, 16)),
  });
  displayedColumns: string[] = ['Time', 'Doctor', 'Cancel'];
  dataSource : any[] = [];
  constructor(private appointmentService:AppointmentService) { }

  ngOnInit(): void {
    this.appointmentService.GetAllAppointmentsByPatient().subscribe((data ) => {
      this.dataSource = data;
    });
  }

  cancel(dto : ViewAppointmentByPatientDTO){

    this.appointmentService.CancelAppointment(dto.appointmentId).subscribe((data ) => {
      this.dataSource = data;
    });
  }

}
