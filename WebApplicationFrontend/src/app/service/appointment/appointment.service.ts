import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CancelAppointment } from 'src/app/model/cancelAppointment';
import { GetAppointment } from 'src/app/model/getAppointment';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  getCancelableAppointments() {
    throw new Error('Method not implemented.');
  }

  constructor(private http : HttpClient) { 
    
  }
  getSurveyableAppointments() : Observable<GetAppointment[]>{

    return this.http.get<GetAppointment[]>(`${environment.baseUrl}/${environment.appointment}/${environment.allSurveyableAppointments}`)

  }

  getAllOtherAppointments() : Observable<GetAppointment[]>{

    return this.http.get<GetAppointment[]>(`${environment.baseUrl}/${environment.appointment}/${environment.allOtherAppointments}`)

  }

  getAllCancelableAppointments() : Observable<GetAppointment[]>{

    return this.http.get<GetAppointment[]>(`${environment.baseUrl}/${environment.appointment}/${environment.allCancelableAppointments}`)

  }

  cancelAppointment(data: CancelAppointment) : Observable<CancelAppointment>{

    return this.http.post<CancelAppointment>(`${environment.baseUrl}/${environment.appointment}/${environment.cancelAppointment}`, data)
  }   
}
