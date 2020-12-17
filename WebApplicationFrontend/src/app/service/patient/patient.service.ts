import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MaliciousPatient } from 'src/app/model/maliciousPatient';
import { UpdatePatientBlockedStatus } from 'src/app/model/updatePatientBlockedStatus';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private http: HttpClient) { }

  updatePatientStatus(data: UpdatePatientBlockedStatus){
    return this.http.post(`${environment.baseUrl}/${environment.patient}/${environment.updatePatientStatus}`, data, {responseType:'text'});
  }

  getAllMaliciousPatients(): Observable<MaliciousPatient[]>{
    return this.http.get<MaliciousPatient[]>(`${environment.baseUrl}/${environment.patient}/${environment.maliciousPatients}`);
  }
}
