import { Component, OnInit } from '@angular/core';
import {AuthService} from "../../hospital/auth/auth.service";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  userRole: string; // Property to hold the user's role
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.userRole = this.authService.getUserRole();
  }

}
