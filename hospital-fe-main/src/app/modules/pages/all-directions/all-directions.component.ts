import { Component, OnInit } from '@angular/core';
import {DirectionService} from "../../hospital/services/direction.service";
import {MatDialog} from "@angular/material/dialog";
import {SpecialistScheduleComponent} from "../specialist-schedule/specialist-schedule.component";

@Component({
  selector: 'app-all-directions',
  templateUrl: './all-directions.component.html',
  styleUrls: ['./all-directions.component.css']
})
export class AllDIrectionsComponent implements OnInit {

  displayedColumns = ['Spetialization', 'Schedule']
  dataSource : any[] = []

  constructor(private directionService:DirectionService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.directionService.GetAllDirections().subscribe((data ) => {
      this.dataSource = data;
    })
  }


  openDialog(element:any) {
    const dialogRef = this.dialog.open(SpecialistScheduleComponent, {
      data: element  // Pass the element to the dialog component
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }


  convert(num : number): string {
    switch (num) {
      case 0:
        return 'Dermatolog';
      case 1:
        return 'Opsta praksa';
      case 2:
        return 'Kardiolog';
      case 3:
        return 'Fizijatar';
      default:
        return 'error';
    }
  }
}
