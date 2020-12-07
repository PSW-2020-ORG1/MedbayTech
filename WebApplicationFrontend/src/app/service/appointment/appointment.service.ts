import { ScheduleAppointment } from './../../model/scheduleAppointment';
import { AvailableAppointments } from './../../model/availableAppointments';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppointmentRecommendation } from 'src/app/model/appointmentRecommendation';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(private http : HttpClient) { }

  getAvailableByDateRange(data : AppointmentRecommendation) : Observable<AvailableAppointments[]> {
    return this.http.post<AvailableAppointments[]>(`${environment.baseUrl}/${environment.appointments}/${environment.availableStrategy}`, data);
  }

  scheduleAppointment(data : ScheduleAppointment) {
    return this.http.post(`${environment.baseUrl}/${environment.appointments}/${environment.scheduleAppointment}`, data, {responseType : 'text'});
  }
}
