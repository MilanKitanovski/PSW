import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {Register} from "../model/register.model";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiHost: string = 'http://localhost:16177/api/user';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http:HttpClient) { }

  registration(user : Register) : Observable<any> {
    return this.http.post<Register>(this.apiHost + '/register', user);
  }

  getAllDoctor_Opste_Prakse(){
    return this.http.get<any>(this.apiHost + '/allDoctorOpstePrakse');
  }

  GetDoctorsBySpecijalization(num:number){
    return this.http.get<any>(this.apiHost + '/allSpecialists/'+num);
  }

  login(user: any){
    return this.http.post<any>(this.apiHost+'/login', user);
  }
}
