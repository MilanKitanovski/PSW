import { Component, OnInit } from '@angular/core';
import {InternalDataService} from "../../../hospital/services/internal-data.service";
import {Chart} from "chart.js/auto";

@Component({
  selector: 'app-blood-sugar',
  templateUrl: './blood-sugar.component.html',
  styleUrls: ['./blood-sugar.component.css']
})
export class BloodSugarComponent implements OnInit {
  public chart: any;
  private chartInfo: any[];
  private labeldata: any[] = [];
  private realdata: any[] = [];
  private colordata: any[] = [];
  constructor(private iDataService: InternalDataService) { }

  ngOnInit(): void {
    this.iDataService.GetAllInternalDatas().subscribe((response) => {
      this.chartInfo = response;
      if (this.chartInfo != null) {
        for (let i = 0; i < this.chartInfo.length; i++) {
          this.labeldata.push(i+1);
          this.realdata.push(this.chartInfo[i].bloodSugar);
          this.colordata.push("red");
        }
        this.createChart(this.labeldata, this.realdata, this.colordata);
      }
    });
  }

  createChart(labeldata: any, realdata: any, colordata: any) {
    this.chart = new Chart('MyChartSugar', {
      type: 'line', //this denotes tha type of chart
      data: {
        labels: labeldata,
        datasets: [
          {
            label: 'Blood sugar',
            data: realdata,
            backgroundColor: colordata,
          },
        ],
      },
      options: {
        aspectRatio: 2,
      },
    });
  }

}
