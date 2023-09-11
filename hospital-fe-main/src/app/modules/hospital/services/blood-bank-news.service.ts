import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class BloodBankNewsService {
  apiHost: string = 'http://localhost:16177/api/bloodBankNews';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http:HttpClient) { }

  GetAllNews(): Observable<any> {
    let headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Authorization": "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<any>(this.apiHost + '/getAllNews', {headers});
  }

  ArchiveNews(id: any):Observable<any> {
    let headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Authorization": "Bearer " + localStorage.getItem("token"),
    });
    return this.http.put<any>(this.apiHost + '/archive/' +id , {headers});
  }


  PublishNews(id:any):Observable<any> {
    console.log(1.1)
    let headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Authorization": "Bearer " + localStorage.getItem("token"),
    });
    console.log(1.2)
    return this.http.put<any>(this.apiHost + '/publish/' +id ,[], {headers});
    console.log(1.3)
  }

  Consume():Observable<any> {
    let headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Authorization": "Bearer " + localStorage.getItem("token"),
    });
    return this.http.put<any>(this.apiHost + '/consume' , {headers});
  }
}
