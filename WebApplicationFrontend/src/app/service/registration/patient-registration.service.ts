import { FormGroup, FormControl, Validators } from '@angular/forms';
import { PatientRegistration } from './../../model/patientRegistration';
import { Injectable } from '@angular/core';
import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientRegistrationService {

  constructor(private http : HttpClient) { }

  registerPatient(patient : PatientRegistration) {
    return this.http.post(`${environment.baseUrl}/${environment.registration}/${environment.patientRegistration}`, patient, {responseType : 'text'})
  }

  uploadImage(formData : FormData) {
    return this.http.post("http://localhost:8080/api/registration/image", formData).subscribe();
  }
 
}
