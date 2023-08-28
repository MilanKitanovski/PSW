import {Component, Inject, OnInit} from '@angular/core';
import {DateRange} from "../../hospital/model/date-range.model";
import {SearchAppointmentDTO} from "../../hospital/model/searchAppointmentDTO";
import {AppointmentService} from "../../hospital/services/appointment.service";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {SearchAppointmentResultDTO} from "../../hospital/model/searchAppointmentResultDTO";
import {ScheduleAppointmentDTO} from "../../hospital/model/scheduleAppointmentDTO";
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import {UserService} from "../../hospital/services/user.service";
import {SpecializationSearchAppointmentDTO} from "../../hospital/model/specializationSearchAppointmentDTO";


const today = new Date();
const month = today.getMonth();
const year = today.getFullYear();

@Component({
  selector: 'app-specialist-schedule',
  templateUrl: './specialist-schedule.component.html',
  styleUrls: ['./specialist-schedule.component.css']
})
export class SpecialistScheduleComponent implements OnInit {

  doctors : any[] = [];
  campaignOne = new FormGroup({
    start: new FormControl(new Date(year, month, 13)),
    end: new FormControl(new Date(year, month, 16)),
  });
  registerForm! : FormGroup;


  favoriteSeason = 'Doctor';
  seasons: string[] = ['Doctor', 'Time'];
  dataSource : SearchAppointmentResultDTO[] = [];
  displayedColumns: string[] = ['Time', 'Doctor', 'Schedule'];

  constructor(private appointmentService: AppointmentService,  @Inject(MAT_DIALOG_DATA) public data: any,
              private userService:UserService,   private formBuilder: FormBuilder,) {

    this.registerForm = this.formBuilder.group({
      doctorId: ['', Validators.required],
    })
    this.userService.GetDoctorsBySpecijalization(this.data.specialization).subscribe((data: any) => {
      this.doctors = data;
      if (this.doctors.length > 0) {
        this.registerForm.patchValue({ doctorId: this.doctors[0].id }); // Assuming the ID property of the doctor object is named "id"
      }
    });
  }

  ngOnInit(): void {

  }


  schedule(dto : SearchAppointmentResultDTO){
    let scheduledto : ScheduleAppointmentDTO=new ScheduleAppointmentDTO(dto.doctorId, dto.date);
    this.appointmentService.ScheduleAppointment(scheduledto).subscribe((data ) => {
      this.dataSource = data;

    });
  }
  search(){
    let range: DateRange = new DateRange(this.campaignOne.get('start')?.value as Date, this.campaignOne.get('end')?.value as Date);

    let app : SpecializationSearchAppointmentDTO = new SpecializationSearchAppointmentDTO(    this.registerForm.get('doctorId')?.value,range);




      this.appointmentService.SearchByDoctorsDirection(app).subscribe((data ) => {
        this.dataSource = data;
        console.log(this.dataSource)
      });

  }
}
