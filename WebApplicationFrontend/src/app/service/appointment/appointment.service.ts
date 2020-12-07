import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetAppointment } from 'src/app/model/getAppointment';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(private http : HttpClient) { 
    
  }
  getSurveyableAppointments() : Observable<GetAppointment[]>{

    return this.http.get<GetAppointment[]>(`${environment.baseUrl}/${environment.appointment}/${environment.allSurveyableAppointments}`)

  }

  getAllOtherAppointments() : Observable<GetAppointment[]>{

    return this.http.get<GetAppointment[]>(`${environment.baseUrl}/${environment.appointment}/${environment.allOtherAppointments}`)

  }
}
