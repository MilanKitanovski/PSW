import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  apiHost: string = 'http://localhost:16177/api/doctor';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http:HttpClient) { }
  getAllDoctor_Opste_Prakse(): Observable<any[]>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<any[]>(this.apiHost + '/allDoctorOpstePrakse');
  }

  GetDoctorsBySpecijalization(num:number){
    return this.http.get<any>(this.apiHost + '/allSpecialists/'+num);
  }
}
