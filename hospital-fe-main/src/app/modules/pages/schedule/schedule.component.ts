import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl} from '@angular/forms';
import {AppointmentService} from "../../hospital/services/appointment.service";
import {SearchAppointmentDTO} from "../../hospital/model/searchAppointmentDTO";
import {DateRange} from "../../hospital/model/date-range.model";
import {SearchAppointmentResultDTO} from "../../hospital/model/searchAppointmentResultDTO";
import {ScheduleAppointmentDTO} from "../../hospital/model/scheduleAppointmentDTO";

const today = new Date();
const month = today.getMonth();
const year = today.getFullYear();




@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css'],

})
export class ScheduleComponent implements OnInit {

  campaignOne = new FormGroup({
    start: new FormControl(new Date(year, month, 13)),
    end: new FormControl(new Date(year, month, 16)),
  });





  displayedColumns: string[] = ['Time', 'Doctor', 'Schedule'];
  dataSource : SearchAppointmentResultDTO[] = [];

  constructor(private appointmentService : AppointmentService) { }


  ngOnInit(): void {
  }



    schedule(dto : SearchAppointmentResultDTO){
    let scheduledto : ScheduleAppointmentDTO=new ScheduleAppointmentDTO(dto.doctorId, dto.date);
    this.appointmentService.ScheduleAppointment(scheduledto).subscribe((data ) => {
      this.dataSource = data;
      console.log(this.dataSource)
    });
  }

  search(){
    const start = this.campaignOne.get('start')?.value as Date;
    const end = this.campaignOne.get('end')?.value as Date;
    console.log('Start Date:', start);
    console.log('End Date:', end);

   let range: DateRange = new DateRange(start, end);

    let app : SearchAppointmentDTO = new SearchAppointmentDTO(range);

      this.appointmentService.SearchForPatientDoctor(app).subscribe((data ) => {
        this.dataSource = data;
        console.log(this.dataSource)
      });

  }

}
