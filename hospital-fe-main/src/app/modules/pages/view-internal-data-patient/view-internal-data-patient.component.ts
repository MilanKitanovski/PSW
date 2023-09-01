import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {SearchAppointmentResultDTO} from "../../hospital/model/searchAppointmentResultDTO";
import {InternalDataDTO} from "../../hospital/model/internalDataDTO";
import {InternalDataService} from "../../hospital/services/internal-data.service";
import {DateRange} from "../../hospital/model/date-range.model";
import {SearchAppointmentDTO} from "../../hospital/model/searchAppointmentDTO";

const today = new Date();
const month = today.getMonth();
const year = today.getFullYear();
@Component({
  selector: 'app-view-internal-data-patient',
  templateUrl: './view-internal-data-patient.component.html',
  styleUrls: ['./view-internal-data-patient.component.css']
})
export class ViewInternalDataPatientComponent implements OnInit {

  dataSource : InternalDataDTO[] = [];
  displayedColumns: string[] = ['bloodPressure', 'bloodSugar', 'fats', 'weight', 'menstrual'];

  constructor(private internalDataService:InternalDataService) { }

  ngOnInit(): void {
    this.internalDataService.GetAllInternalDatas().subscribe((data ) => {
      this.dataSource = data;
      console.log(this.dataSource)
  })
  }

}
