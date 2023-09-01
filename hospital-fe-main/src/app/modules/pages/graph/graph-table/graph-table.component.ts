import { Component, OnInit } from '@angular/core';
import {InternalDataService} from "../../../hospital/services/internal-data.service";

@Component({
  selector: 'app-graph-table',
  templateUrl: './graph-table.component.html',
  styleUrls: ['./graph-table.component.css']
})
export class GraphTableComponent implements OnInit {
  chartDataF:any[]=[{nest:"gas",fats:3}]
  constructor(private iDataService:InternalDataService) { }
  ngOnInit(): void {
    this.iDataService.GetAllInternalDatas().subscribe((data) => {
      console.log(data)
      this.chartDataF = data.map((dto: { fats: any; }, index: { toString: () => any; }) => ({
        name: index.toString(),
        value: dto.fats,
      }));
    });
  }

}
