import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Register} from "../model/register.model";
import {Observable} from "rxjs";
import {BlogDTO} from "../model/blogDTO";

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  apiHost: string = 'http://localhost:16177/api/blog';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http:HttpClient) { }

  createBlog(blog : BlogDTO) : Observable<any> {
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.post<BlogDTO>(this.apiHost + '/createBlog', blog, {headers});
  }


  allBlogs() : Observable<any[]>{
    let headers = new HttpHeaders({
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + localStorage.getItem("token"),
    });
    return this.http.get<any[]>(this.apiHost + '/allBlogs', {headers});
  }
}
