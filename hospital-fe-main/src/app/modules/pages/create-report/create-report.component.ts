import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {ReportService} from "../../hospital/services/report.service";
import {SearchAppointmentResultDTO} from "../../hospital/model/searchAppointmentResultDTO";
import {DateRange} from "../../hospital/model/date-range.model";
import {HttpErrorResponse} from "@angular/common/http";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-create-report',
  templateUrl: './create-report.component.html',
  styleUrls: ['./create-report.component.css']
})
export class CreateReportComponent implements OnInit {
  campaignOne = new FormGroup({
    start: new FormControl(),
    end: new FormControl(),
  });
  constructor(private reportService:ReportService, private toastr: ToastrService
    ,private formBuilder: FormBuilder,  @Inject(MAT_DIALOG_DATA) public data: any) { }

  reportForm! : FormGroup;
  internalDataForm!: FormGroup;

  favoriteSeason = 'Only report';
  seasons: string[] = ['Only report', 'Report with internal data'];
  dataSource : SearchAppointmentResultDTO[] = [];
  displayedColumns: string[] = ['Report', 'InternalData'];
  ngOnInit(): void {
    this.reportForm = this.formBuilder.group({

      diagnosis: ['...', Validators.required],
      treatment: ['...', Validators.required],
    })
    this.internalDataForm = this.formBuilder.group({

      bloodPressure: ['...', Validators.required],
      bloodSugar: [1, Validators.required],
      fats: [1, Validators.required],
      weight: [1, Validators.required],
    })
  }


  submit(){
    const start = this.campaignOne.get('start')?.value as Date;
    const end = this.campaignOne.get('end')?.value as Date;
    let range: DateRange = new DateRange(start, end);
    let men=null;
    if(start!=null && end!=null  ){
      men =range;
    }


    let internalData={
      bloodPressure: this.internalDataForm.get('bloodPressure')?.value,
      bloodSugar: this.internalDataForm.get('bloodSugar')?.value,
      fats: this.internalDataForm.get('fats')?.value,
      weight: this.internalDataForm.get('weight')?.value,
      menstruals: men
    }


    let reportData={
      diagnosis: this.reportForm.get('diagnosis')?.value,
      treatment: this.reportForm.get('treatment')?.value,
      appointmentId :this.data.appointmentId,
      patientId :this.data.patientId,
      internalData: {}
    }

    if(this.favoriteSeason === "Report with internal data"){
      reportData.internalData = internalData;
    }
    this.reportService.CreateReport(reportData).subscribe((data) => {
        this.toastr.success("Report created", "Report");
      },
      (err: HttpErrorResponse) =>
      {
        this.toastr.error("Error", "Report");
      });
  }
}
