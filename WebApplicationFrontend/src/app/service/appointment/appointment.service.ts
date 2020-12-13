import { CancelAppointment } from 'src/app/model/cancelAppointment';
import { GetAppointment } from 'src/app/model/getAppointment';
import { ScheduleAppointment } from './../../model/scheduleAppointment';
import { AvailableAppointments } from './../../model/availableAppointments';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppointmentRecommendation } from 'src/app/model/appointmentRecommendation';
import { environment } from 'src/environments/environment';
import { AppointmentScheduling } from 'src/app/model/appointmentScheduling';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(private http : HttpClient) { }
  
  getSurveyableAppointments() : Observable<GetAppointment[]>{
    return this.http.get<GetAppointment[]>(`${environment.baseUrl}/${environment.appointments}/${environment.allSurveyableAppointments}`)
  }

  getAllOtherAppointments() : Observable<GetAppointment[]>{
    return this.http.get<GetAppointment[]>(`${environment.baseUrl}/${environment.appointments}/${environment.allOtherAppointments}`)
  }

  getAllCancelableAppointments() : Observable<GetAppointment[]>{
    return this.http.get<GetAppointment[]>(`${environment.baseUrl}/${environment.appointments}/${environment.allCancelableAppointments}`)
  }

  cancelAppointment(data: CancelAppointment) : Observable<CancelAppointment>{
    return this.http.post<CancelAppointment>(`${environment.baseUrl}/${environment.appointments}/${environment.cancelAppointment}`, data);
  }   

  getAvailableByDateRange(data : AppointmentRecommendation) : Observable<AvailableAppointments[]> {
    return this.http.post<AvailableAppointments[]>(`${environment.baseUrl}/${environment.appointments}/${environment.availableStrategy}`, data);
  }

  getAvailableByDate(data : AppointmentScheduling) : Observable<AvailableAppointments[]> {
    return this.http.post<AvailableAppointments[]>(`${environment.baseUrl}/${environment.appointments}/${environment.availableStandard}`, data);
  }

  scheduleAppointment(data : ScheduleAppointment) {
    return this.http.post(`${environment.baseUrl}/${environment.appointments}/${environment.scheduleAppointment}`, data, {responseType : 'text'});
  }
}
