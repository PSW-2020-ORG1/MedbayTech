import { AppointmentEvent } from './../../model/event/appointmentEvent';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private http : HttpClient) { }

  public postEvent(data : AppointmentEvent) {
    return this.http.post(`${environment.baseUrl}/${environment.event}`, data, {responseType : 'text'});
  }
}
