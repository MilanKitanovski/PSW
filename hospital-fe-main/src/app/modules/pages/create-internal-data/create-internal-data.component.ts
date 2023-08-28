import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {InternalDataService} from "../../hospital/services/internal-data.service";
import {ToastrService} from "ngx-toastr";
import {HttpErrorResponse} from "@angular/common/http";
import {DateRange} from "../../hospital/model/date-range.model";
import {InternalDataDTO} from "../../hospital/model/internalDataDTO";


const today = new Date();
const month = today.getMonth();
const year = today.getFullYear();

@Component({
  selector: 'app-create-internal-data',
  templateUrl: './create-internal-data.component.html',
  styleUrls: ['./create-internal-data.component.css']
})
export class CreateInternalDataComponent implements OnInit {

  internalDataForm! : FormGroup;
  campaignOne = new FormGroup({
    start: new FormControl(new Date(year, month, 13)),
    end: new FormControl(new Date(year, month, 16)),
  });
  constructor(
    private formBuilder: FormBuilder,
    private internalDataService: InternalDataService,
    private toastr: ToastrService,

  ) { }

  ngOnInit(): void {
    this.internalDataForm = this.formBuilder.group({
      bloodPressure: ['', Validators.required],
      bloodSugar: [0, Validators.required],
      fats: [0, Validators.required],
      weight: [0, Validators.required]

  })
  }




  submit(){
    const start = this.campaignOne.get('start')?.value as Date;
    const end = this.campaignOne.get('end')?.value as Date;
    let range: DateRange = new DateRange(start, end);

    let InternalData :InternalDataDTO=new InternalDataDTO(
      this.internalDataForm.get('bloodPressure')?.value,
      this.internalDataForm.get('bloodSugar')?.value,
      this.internalDataForm.get('fats')?.value,
      this.internalDataForm.get('weight')?.value, range
      );

    this.internalDataService.PatientCreateData(InternalData).subscribe((data) => {
        this.toastr.success("Data created", "InternalData");
      },
      (err: HttpErrorResponse) =>
      {
        this.toastr.error("Error", "InternalData");
      });
  }
}
