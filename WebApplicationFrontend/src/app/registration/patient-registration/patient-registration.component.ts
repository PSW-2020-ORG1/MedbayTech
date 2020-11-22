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

  minDateOfBirth : Date;
  maxDateOfBirth : Date;
  
  minDatePolicy : Date;
  maxDatePolicy : Date;

  constructor(private taostr : ToastrService) { 
    this.maxDateOfBirth = new Date();
    this.minDateOfBirth = new Date();
    this.minDateOfBirth.setFullYear(this.minDateOfBirth.getFullYear() - 180);

    this.minDatePolicy = new Date();
    this.minDatePolicy.setFullYear(this.minDatePolicy.getFullYear() - 10);

    this.maxDatePolicy = new Date();
  }

  ngOnInit(): void {
    this.createForm = new FormGroup({
      'name' : new FormControl(null, [Validators.required, Validators.pattern("^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ ]*$")]),
      'surname' : new FormControl(null , [Validators.required, Validators.pattern("^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ ]*$")]),
      'id' : new FormControl(null, [Validators.required, Validators.pattern("^\\d{13}$")]),
      'dateOfBirth' : new FormControl(null, [Validators.required]),
      'email' : new FormControl(null, [Validators.required, Validators.email]),
      'phone' : new FormControl(null, [Validators.required]),
      'username' : new FormControl(null, [Validators.required, Validators.minLength(5)]),
      'password' : new FormControl(null, [Validators.required, Validators.minLength(8)]),
      'confirmPassword' : new FormControl(null, [Validators.required, Validators.minLength(8)]),
      'profession' : new FormControl(null, [Validators.minLength(3)]),
      'gender' : new FormControl(null, [Validators.required]),
      'insurancePolicyNumber' : new FormControl(null, [Validators.required]),
      'insurancePolicyCompany' : new FormControl(null, [Validators.required]),
      'insurancePolicyStartDate' : new FormControl(null, [Validators.required]),
      'insurancePolicyEndDate' : new FormControl(null, [Validators.required]),
      'cityOfBirth' : new FormControl(null, [Validators.required, Validators.pattern("^[A-ZŠĐŽČĆa-zšđćčžA-ZŠĐŽČĆ ]*$")]),
      'postalCodeBirth' : new FormControl(null, [Validators.required, Validators.pattern("^\\d{5}$")]),
      'stateBirth' : new FormControl(null, [Validators.required, Validators.pattern("^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ ]*$")]),
      'street' : new FormControl(null, [Validators.required]),
      'number' : new FormControl(null, [Validators.required]),
      'apartment' : new FormControl(null, [Validators.pattern("^\\d{1,6}$")]),
      'floor' : new FormControl(null, [Validators.pattern("^\\d{1,4}$")]),
      'educationLevel' : new FormControl(null, [Validators.required]),
      'patientCondition' : new FormControl(null),
      'bloodType' : new FormControl(null),
      'choosenDoctor' : new FormControl(null, [Validators.required])
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
