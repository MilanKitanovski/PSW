import { Component, OnInit } from '@angular/core';
import {InternalDataDTO} from "../../hospital/model/internalDataDTO";
import {ReportService} from "../../hospital/services/report.service";
import {ViewReportsPatientDTO} from "../../hospital/model/viewReportsPatientDTO";

@Component({
  selector: 'app-view-reports-patient',
  templateUrl: './view-reports-patient.component.html',
  styleUrls: ['./view-reports-patient.component.css']
})
export class ViewReportsPatientComponent implements OnInit {

  constructor(private reportService: ReportService) { }
  dataSource : ViewReportsPatientDTO[] = [];
  displayedColumns: string[] = ['diagnosis', 'treatment'];


  ngOnInit(): void {
    this.reportService.GetAllReports().subscribe((data ) => {
      this.dataSource = data;
      console.log(this.dataSource)
    })
  }

}
