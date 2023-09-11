import { Component, OnInit } from '@angular/core';
import {Register} from "../../hospital/model/register.model";
import {UserService} from "../../hospital/services/user.service";
import {Router} from "@angular/router";
import {FormGroup, FormControl, Validators, Form, FormBuilder} from "@angular/forms";
import {HttpErrorResponse} from "@angular/common/http";
import {ToastrService} from "ngx-toastr";
import {BlogDTO} from "../../hospital/model/blogDTO";
import {DoctorService} from "../../hospital/services/doctor.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  doctors : any[] = [];
  registerForm! : FormGroup;
  constructor(
    private userService: UserService,
    private doctorService: DoctorService,
    private router: Router,
    private formBuilder: FormBuilder,
    private toastr: ToastrService
  ) { }
  ngOnInit(): void {
      this.doctorService.getAllDoctor_Opste_Prakse().subscribe((data: any) => {
        this.doctors = data;
        console.log(this.doctors)
      });

      this.registerForm = this.formBuilder.group({
        name: ['', Validators.required],
        surname: ['', Validators.required],
        email: ['', Validators.required],
        password: ['', Validators.required],
        phoneNumber: ['', Validators.required],
        doctorId: ['', Validators.required],
        gender: ['', Validators.required]
      })
  }

  login(){
    this.router.navigate(['/login']);
  }

  register(){
    console.log(this.registerForm)
    if(this.registerForm.invalid)
    {
      this.toastr.error("Popuni sva polja", "Registration");
      return;
    }

    let register :Register = new Register(
      this.registerForm.get('name')?.value,
      this.registerForm.get('surname')?.value,
      this.registerForm.get('email')?.value,
      this.registerForm.get('password')?.value,
      this.registerForm.get('phoneNumber')?.value,
      this.registerForm.get('doctorId')?.value,
    );
    switch (this.registerForm.get('gender')?.value) {
      case 'Male':
        register.gender = 0;
        break;
      case 'Female':
        register.gender = 1;
        break;
    }
    this.userService.registration(this.registerForm.value).subscribe((data) => {
      this.toastr.success("Registration successfull", "Registration");
      this.router.navigate(['/login']);
    },
      (err: HttpErrorResponse) =>
      {
        this.toastr.error("Bad registration", "Registration");
      });
  }
}
