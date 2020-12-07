import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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

  cancelAppointment(data: number) : Observable<number>{

    return this.http.post<number>(`${environment.baseUrl}/${environment.appointment}/${environment.cancelAppointment}`, data)
  }   
}
