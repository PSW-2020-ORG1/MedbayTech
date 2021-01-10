import { ToastrModule, ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Authentication } from 'src/app/model/authentication';
import { Role } from 'src/app/model/role';
import { AuthenticationService } from 'src/app/service/authentication/authentication.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  invalidLogin: boolean;
  username: string;
  password: string;
  credentials: Authentication;
  
  constructor(private authService: AuthenticationService, private router: Router, private toastr : ToastrService) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      'username' : new FormControl(null, Validators.required),
      'password' : new FormControl(null, Validators.required)
    });
  }

  signIn(){
    this.username = this.loginForm.value.username;
    this.password = this.loginForm.value.password;

    this.credentials = new Authentication(this.username, this.password);
    this.authService.login(this.credentials).subscribe(
      result => {
        if(result.role == Role.Admin){
          this.router.navigate(['/allFeedback'])
        }
        else if(result.role == Role.Patient) {
          this.router.navigate(['/home']);
        }
      },
      error => {
        this.toastr.error("Invalid username or password");
      }
    );
  }

}
