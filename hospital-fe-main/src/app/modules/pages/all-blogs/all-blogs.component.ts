import { Component, OnInit } from '@angular/core';
import {BlogService} from "../../hospital/services/blog.service";
import {InternalDataDTO} from "../../hospital/model/internalDataDTO";
import {BlogDTO} from "../../hospital/model/blogDTO";
import {error} from "@angular/compiler-cli/src/transformers/util";

@Component({
  selector: 'app-all-blogs',
  templateUrl: './all-blogs.component.html',
  styleUrls: ['./all-blogs.component.css']
})
export class AllBlogsComponent implements OnInit {
  blogs : any[] = [];


  constructor(private blogService:BlogService) { }

  ngOnInit(): void {
    this.blogService.allBlogs().subscribe((data ) => {
      this.blogs = data;

  })
  }
  convert(num : number): string {
    switch (num) {
      case 0:
        return 'Medicine';
      case 1:
        return 'Health';
      case 2:
        return 'Actual';
      default:
        return 'error';
    }
  }

}
