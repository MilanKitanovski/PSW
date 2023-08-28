import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {InternalDataDTO} from "../model/internalDataDTO";
import {Observable} from "rxjs";
import {DirectionDTO} from "../model/directionDTO";

@Injectable({
  providedIn: 'root'
})
export class DirectionService {
  apiHost: string = 'http://localhost:16177/api/direction';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http:HttpClient) { }

  GetAllDirections(): Observable<any>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<any>(this.apiHost + '/getDirectionsByPatient',{headers});
  }


  CreateDirection(direction: DirectionDTO): Observable<any>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.post<InternalDataDTO>(this.apiHost + '/CreateDirection', direction, {headers});
  }
}
