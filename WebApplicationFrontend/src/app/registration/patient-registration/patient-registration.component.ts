import { DoctorServiceService } from './../../service/doctor/doctor-service.service';
import { SearchDoctor } from './../../model/searchDoctor';
import { HttpClient } from '@angular/common/http';
import { PatientRegistrationService } from './../../service/registration/patient-registration.service';
import { PatientRegistration } from './../../model/patientRegistration';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-patient-registration',
  templateUrl: './patient-registration.component.html',
  styleUrls: ['./patient-registration.component.css']
})
export class PatientRegistrationComponent implements OnInit {

  selected : boolean;

  createForm : FormGroup;

  searchDoctors : SearchDoctor[] = new Array();

  minDateOfBirth : Date;
  maxDateOfBirth : Date;
  
  minDatePolicy : Date;
  maxDatePolicy : Date;

  formData : FormData;

  name : string;
  surname : string;
  id : string;
  dateOfBirth : Date;
  phone : string;
  email : string;
  username : string;
  password : string;
  confirmPassword : string;
  educationLevel : string;
  profession : string;
  gender : string;
  postalCode : number;
  city : string;
  state : string;
  street : string;
  number : number;
  apartment : number;
  floor : number;
  policyNumber : string;
  company : string;
  policyStart : Date;
  policyEnd : Date;
  patientCondition : string;
  bloodType : string;
  doctor : string;
  cityOfBirth : string;
  postalCodeBirth : string;
  stateOfBirth : string;


  patient : PatientRegistration;

  fileToUpload : File;

  constructor(private taostr : ToastrService, private service : PatientRegistrationService, private http : HttpClient, private doctorService : DoctorServiceService) { 
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
      'apartment' : new FormControl(0, [Validators.pattern("^\\d{1,6}$"), Validators.required]),
      'floor' : new FormControl(0, [Validators.pattern("^\\d{1,4}$"), Validators.required]),
      'educationLevel' : new FormControl(null, [Validators.required]),
      'city' : new FormControl(null, [Validators.required, Validators.pattern("^[A-ZŠĐŽČĆa-zšđćčžA-ZŠĐŽČĆ ]*$")]),
      'state' : new FormControl(null, [Validators.required, Validators.pattern("^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ ]*$")]),
      'postalCode' : new FormControl(null, [Validators.required, Validators.pattern("^\\d{5}$")]),
      'patientCondition' : new FormControl(null),
      'bloodType' : new FormControl(null),
      'choosenDoctor' : new FormControl(null, [Validators.required]),
      'photo' : new FormControl(null)
    });

    this.getSearchDoctors();
  }

  onSubmit() {
   this.service.registerPatient(this.createPatient()).subscribe(
      res => {
        this.taostr.success(res);
        this.formData.append('id', this.createForm.value.id);
        this.service.uploadImage(this.formData);
      },
      error => {
        this.taostr.error(error.error);
      }
    );
     
  }

  public uploadFile(files){
    if(files.length === 0)
      return;

    console.log("Usao")

    this.fileToUpload = <File>files[0];

    this.formData = new FormData();
    this.formData.append('file', this.fileToUpload, this.fileToUpload.name);
    this.selected = true;
    return this.formData;
  };

  createPatient() : PatientRegistration {
    this.name = this.createForm.value.name;
    this.surname = this.createForm.value.surname;
    this.id = this.createForm.value.id;
    this.dateOfBirth = new Date(this.createForm.value.dateOfBirth.getTime() - this.createForm.value.dateOfBirth.getTimezoneOffset() * 60000)
    this.phone = this.createForm.value.phone;
    this.email = this.createForm.value.email;
    this.username = this.createForm.value.username;
    this.password = this.createForm.value.password;
    this.confirmPassword = this.createForm.value.confirmPassword;
    this.profession = this.createForm.value.profession;
    this.cityOfBirth = this.createForm.value.cityOfBirth;
    this.postalCodeBirth = this.createForm.value.postalCodeBirth;
    this.stateOfBirth = this.createForm.value.stateBirth;
    this.street = this.createForm.value.street;
    this.number = this.createForm.value.number;
    this.apartment = this.createForm.value.apartment;
    this.floor = this.createForm.value.floor;
    this.postalCode = this.createForm.value.postalCode;
    this.state = this.createForm.value.state;
    this.policyNumber = this.createForm.value.insurancePolicyNumber;
    this.company = this.createForm.value.insurancePolicyCompany;
    
    this.policyStart = new Date(this.createForm.value.insurancePolicyStartDate.getTime() - this.createForm.value.insurancePolicyStartDate.getTimezoneOffset() * 60000);
    this.policyEnd = new Date(this.createForm.value.insurancePolicyEndDate.getTime() - this.createForm.value.insurancePolicyEndDate.getTimezoneOffset() * 60000);
    
    this.doctor = this.createForm.value.choosenDoctor;
    


    this.patient = new PatientRegistration
    (
      this.id, this.name,
      this.surname,
      this.dateOfBirth,
      this.phone,
      this.email,
      this.username,
      this.password,
      this.confirmPassword,
      this.educationLevel,
      this.profession,
      this.gender,
      this.postalCode,
      this.city,
      this.state,
      this.street,
      this.number,
      this.apartment,
      this.floor,
      this.policyNumber,
      this.company,
      this.policyStart,
      this.policyEnd,
      this.patientCondition,
      this.bloodType,
      this.doctor,
      this.cityOfBirth,
      this.postalCodeBirth,
      this.stateOfBirth
    );
    return this.patient;
  }

  
  getSearchDoctors() {
    this.doctorService.getAllDoctors().subscribe( data => {
      this.searchDoctors = data;
    });
  }
  passwordMatch() : boolean {
    if(this.createForm.value.password === this.createForm.value.confirmPassword)
    {
      return true;  
    }
    return false;
  }

  selectedGender(event){
    this.gender = event.value;
  }

  selectedEducationalLevel(event) {
    this.educationLevel = event.value;
  }

  selectedPatientCondition(event) {
    this.patientCondition = event.value;
    console.log("Kurcina");
  }

  selectedBloodType(event) {
    this.bloodType = event.value;
    console.log(this.bloodType);
  }

  getDoctor(event) {
    this.doctor = event.value;
    console.log(this.doctor);
  }

}
