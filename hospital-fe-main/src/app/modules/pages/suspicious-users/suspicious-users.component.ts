import { Component, OnInit } from '@angular/core';
import {UserService} from "../../hospital/services/user.service";
import {ViewAppointmentByPatientDTO} from "../../hospital/model/ViewAppointmentByPatientDTO";

@Component({
  selector: 'app-suspicious-users',
  templateUrl: './suspicious-users.component.html',
  styleUrls: ['./suspicious-users.component.css']
})
export class SuspiciousUsersComponent implements OnInit {
  displayedColumns: string[] = ['Email', 'Count', 'IsBlocked', 'Block', 'Unblock'];
  dataSource : any[] = [];
  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  private getUsers() {
    this.userService.GetAllUserBySuspiciousActivity().subscribe((data) => {
      this.dataSource = data;
    });
  }

  block(dto : any){
    this.userService.BlockUser(dto.userId).subscribe((data ) => {
      this.getUsers();
    });
  }

  unblock(dto : any){
    this.userService.UnblockUser(dto.userId).subscribe((data ) => {
      this.getUsers();
    });
  }
}
