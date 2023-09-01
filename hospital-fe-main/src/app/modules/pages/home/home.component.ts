import { Component, OnInit } from '@angular/core';
import {NotificationService} from "../../hospital/services/notification.service";
import {BlogService} from "../../hospital/services/blog.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  notifications : any[] = [];

  constructor(private notificationService:NotificationService, private router: Router,
  ) { }

  ngOnInit(): void {
    this.notificationService.allNotifications().subscribe((data ) => {
      this.notifications = data;
    })
  }

  registration()
  {
    this.router.navigate(['/register'])
  }

  login()
  {
    this.router.navigate(['/login'])
  }
}
