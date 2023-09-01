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

  GetAllUserBySuspiciousActivity(): Observable<any> {
    let headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Authorization": "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<any>(this.apiHost + '/allSuspicious', {headers});
  }

  UnblockUser(id: any):Observable<any> {
    let headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Authorization": "Bearer " + localStorage.getItem("token"),
    });
    return this.http.put<any>(this.apiHost + '/unblockUser/' +id , {headers});
  }


  BlockUser(id:any):Observable<any> {
    let headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Authorization": "Bearer " + localStorage.getItem("token"),
    });
    return this.http.put<any>(this.apiHost + '/blockUser/' +id , {headers});
  }
}
