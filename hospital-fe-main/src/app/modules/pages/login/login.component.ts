import { Component, OnInit } from '@angular/core';
import {Route, Router} from "@angular/router";
import {Form, FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ToastrService} from "ngx-toastr";
import {UserService} from "../../hospital/services/user.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm! : FormGroup;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['',Validators.required],
      password: ['', Validators.required]
    })
  }

  login(){
    if(this.loginForm.invalid){
      this.toastr.error("Popunite polja", "Login");
      return;
    }
    this.userService.login(this.loginForm.value).subscribe((data) => {
        this.toastr.success("Login successfull", "Login");
        this.router.navigate(['/home']);
        localStorage.setItem("token",data.jwt);
        console.log("token")
      },
      (err: HttpErrorResponse) =>
      {
        this.toastr.error("Bad login", "Login");
      });
  }
  registration()
  {
    this.router.navigate(['/register'])
  }
}
