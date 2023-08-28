import { Component, OnInit } from '@angular/core';
import {BlogService} from "../../hospital/services/blog.service";
import {HttpErrorResponse} from "@angular/common/http";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ToastrService} from "ngx-toastr";
import {InternalDataDTO} from "../../hospital/model/internalDataDTO";
import {BlogDTO} from "../../hospital/model/blogDTO";
@Component({
  selector: 'app-create-blog',
  templateUrl: './create-blog.component.html',
  styleUrls: ['./create-blog.component.css']
})
export class CreateBlogComponent implements OnInit {

  seasons: string[] = ['Medicine', 'Health', 'Actual'];

  blogForm! : FormGroup;

  constructor(private blogService: BlogService,
              private formBuilder: FormBuilder,
              private toastr: ToastrService,

  ) { }

  ngOnInit(): void {
    this.blogForm = this.formBuilder.group({
      blogText: ['', Validators.required],
      favoriteSeason: ['Medicine'] // Initialize with default value
    })
  }

  createBlog() {



    let blog :BlogDTO=new BlogDTO(
      this.blogForm.get('blogText')?.value,
    );
    switch (this.blogForm.get('favoriteSeason')?.value) {
      case 'Medicine':
        blog.theme = 0;
        break;
      case 'Health':
        blog.theme = 1;
        break;
      case 'Actual':
        blog.theme = 2;
        break;
    }

      this.blogService.createBlog(blog).subscribe((data ) => {
        this.toastr.success("Blog created", "Blog");
        },
        (err: HttpErrorResponse) => {
          this.toastr.error("Error", "Blog");
      });
  }


}
