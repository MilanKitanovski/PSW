import {Component, Inject, OnInit} from '@angular/core';
import {UserService} from "../../hospital/services/user.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AppointmentService} from "../../hospital/services/appointment.service";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {HttpErrorResponse} from "@angular/common/http";
import {ToastrService} from "ngx-toastr";
import {Register} from "../../hospital/model/register.model";
import {DirectionService} from "../../hospital/services/direction.service";

@Component({
  selector: 'app-create-direction',
  templateUrl: './create-direction.component.html',
  styleUrls: ['./create-direction.component.css']
})
export class CreateDirectionComponent implements OnInit {
  specialization : any[] = [{id:0,text:"Dermatolog"}, {id:1,text:"Kardiolog"}, {id:2,text:"Fizijatar"}];
  directionForm! : FormGroup;
  constructor(private directionService:DirectionService, private formBuilder: FormBuilder,  @Inject(MAT_DIALOG_DATA) public data: any,     private toastr: ToastrService,) {}



  ngOnInit(): void {

    this.directionForm = this.formBuilder.group({

      doctorId: [0, Validators.required],

    })
  }

  directionCreate(){

    let direction  = {
      Specialization: this.directionForm.get('doctorId')?.value,
      PatientId: this.data.patientId}

    this.directionService.CreateDirection(direction).subscribe(() => {
        this.toastr.success("Direction created", "Direction");
      },
      (err: HttpErrorResponse) =>
      {
        this.toastr.error("Error", "Direction");
      });
  };



}
