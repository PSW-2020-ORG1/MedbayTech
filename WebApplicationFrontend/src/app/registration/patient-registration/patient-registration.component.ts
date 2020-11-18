import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-patient-registration',
  templateUrl: './patient-registration.component.html',
  styleUrls: ['./patient-registration.component.css']
})
export class PatientRegistrationComponent implements OnInit {

  createForm : FormGroup;
  constructor(private taostr : ToastrService) { }

  ngOnInit(): void {
    this.createForm = new FormGroup({
      'name' : new FormControl(null, [Validators.required, Validators.pattern("^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ ]*$")]),
      'surname' : new FormControl(null , [Validators.required, Validators.pattern("^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ ]*$")]),
      'id' : new FormControl(null, [Validators.required, Validators.pattern('')]),
      'dateOfBirth' : new FormControl(null, [Validators.required]),
      'email' : new FormControl(null, [Validators.required, Validators.email]),
      'phone' : new FormControl(null, [Validators.required]),
      'username' : new FormControl(null, [Validators.required, Validators.minLength(5)]),
      'password' : new FormControl(null, [Validators.required, Validators.minLength(8)]),
      'confirmPassword' : new FormControl(null, [Validators.required, Validators.minLength(8)]),
      'profession' : new FormControl(null, [Validators.minLength(3)])
    });
  }

  onSubmit() {
    console.log(this.createForm.value.dateOfBirth);
    if(!this.passwordMatch()) {
      this.taostr.error("Password does not match!");
      console.log(this.createForm.value.username);
      return;
    }
  }

  passwordMatch() : boolean {
    if(this.createForm.value.password === this.createForm.value.confirmPassword)
    {
      return true;  
    }
    return false;
  }
}
