import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {NotificationService} from "../../hospital/services/notification.service";
import {ToastrService} from "ngx-toastr";
import {HttpErrorResponse} from "@angular/common/http";
import {BlogDTO} from "../../hospital/model/blogDTO";
import {NotificationDTO} from "../../hospital/model/notificationDTO";

@Component({
  selector: 'app-create-notification',
  templateUrl: './create-notification.component.html',
  styleUrls: ['./create-notification.component.css']
})
export class CreateNotificationComponent implements OnInit {
  notificationForm! : FormGroup;

  constructor(private notificationService:NotificationService,
              private formBuilder: FormBuilder,
              private toastr: ToastrService,) { }

  ngOnInit(): void {
    this.notificationForm = this.formBuilder.group({
      notificationText: ['', Validators.required],
    })
  }
  createNotification(){
    let notification :NotificationDTO=new NotificationDTO(
      this.notificationForm.get('notificationText')?.value,
    );
    this.notificationService.createNotification(notification).subscribe((data ) => {
        this.toastr.success("Notification created", "Notification");
      },
      (err: HttpErrorResponse) => {
        this.toastr.error("Error", "Notification");
      });
  }
}
