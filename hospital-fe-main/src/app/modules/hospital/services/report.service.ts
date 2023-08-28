import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  apiHost: string = 'http://localhost:16177/api/report';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http:HttpClient) { }

  GetAllReports(): Observable<any>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<any>(this.apiHost + '/allReports',{headers});
  }


  CreateReport(report: any): Observable<any>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.post<any>(this.apiHost + '/createReport', report, {headers});
  }
}
