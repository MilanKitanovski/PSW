import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {InternalDataDTO} from "../model/internalDataDTO";
import {SearchAppointmentDTO} from "../model/searchAppointmentDTO";

@Injectable({
  providedIn: 'root'
})
export class InternalDataService {

  apiHost: string = 'http://localhost:16177/api/internalData';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http:HttpClient) { }

  GetAllInternalDatas(): Observable<InternalDataDTO[]>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<InternalDataDTO[]>(this.apiHost + '/allDatas',{headers});
  }

  PatientCreateData(internalData: InternalDataDTO): Observable<any>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.post<InternalDataDTO>(this.apiHost + '/patientCreateData', internalData, {headers});
  }
}
