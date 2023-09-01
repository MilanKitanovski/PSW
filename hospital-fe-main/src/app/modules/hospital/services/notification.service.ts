import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {BlogDTO} from "../model/blogDTO";
import {Observable} from "rxjs";
import {NotificationDTO} from "../model/notificationDTO";

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  apiHost: string = 'http://localhost:16177/api/notification';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http:HttpClient) { }

  createNotification(notification : NotificationDTO) : Observable<any> {
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.post<NotificationDTO>(this.apiHost + '/createNotification', notification, {headers});
  }


  allNotifications() : Observable<any[]>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<any[]>(this.apiHost + '/allNotifications', {headers});
  }
}
