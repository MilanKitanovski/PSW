import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {SearchAppointmentDTO} from "../model/searchAppointmentDTO";
import {SearchAppointmentResultDTO} from "../model/searchAppointmentResultDTO";
import {ScheduleAppointmentDTO} from "../model/scheduleAppointmentDTO";
import {ViewAppointmentByDoctorDTO} from "../model/viewAppointmentByDoctorDTO";
import {SpecializationSearchAppointmentDTO} from "../model/specializationSearchAppointmentDTO";
import {ViewAppointmentByPatientDTO} from "../model/ViewAppointmentByPatientDTO";

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  apiHost: string = 'http://localhost:16177/api/appointment';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http:HttpClient) { }

  SearchForPatientDoctor(appointmentDTO : SearchAppointmentDTO) : Observable<SearchAppointmentResultDTO[]>{
    let headers = new HttpHeaders({
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.post<SearchAppointmentResultDTO[]>(this.apiHost + '/searchForPatientDoctor', appointmentDTO, {headers});
  }

  SearchByDoctorsDirection(appointmentDTO : SpecializationSearchAppointmentDTO) : Observable<SearchAppointmentResultDTO[]>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });

    return this.http.post<SearchAppointmentResultDTO[]>(this.apiHost + '/searchByDoctorsDirection', appointmentDTO, {headers});
  }

  ScheduleAppointment(scheduleAppointmentDTO : ScheduleAppointmentDTO) : Observable<any>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.post<any>(this.apiHost + '/scheduleAppointment', scheduleAppointmentDTO, {headers});
  }

  GetAllPendingAppointment(id: string): Observable<any> {
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<any>(this.apiHost + '/getAllPending', {headers});
  }

  CancelAppointment(id: string = ""): Observable<any>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<any>(this.apiHost + '/cancleAppointment/'+id, {headers});
  }
  GetAllAppointmentsByPatient(): Observable<ViewAppointmentByPatientDTO[]>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<ViewAppointmentByPatientDTO[]>(this.apiHost + '/getAllAppointmentByPatient', {headers});
  }

  GetAllAppointmentsByDoctor(): Observable<ViewAppointmentByDoctorDTO[]>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<ViewAppointmentByDoctorDTO[]>(this.apiHost + '/getAllAppointmentByDoctor', {headers});
  }
}
