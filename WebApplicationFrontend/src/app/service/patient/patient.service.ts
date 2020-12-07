import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UpdatePatientBlockedStatus } from 'src/app/model/updatePatientBlockedStatus';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private http: HttpClient) { }

  updatePatientStatus(data: UpdatePatientBlockedStatus) : Observable<UpdatePatientBlockedStatus>{
    return this.http.post<UpdatePatientBlockedStatus>(`${environment.baseUrl}/${environment.patient}/${environment.updatePatientStatus}`, data)
  }
}
