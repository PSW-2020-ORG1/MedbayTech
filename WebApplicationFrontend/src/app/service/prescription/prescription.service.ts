import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Appointment } from 'src/app/model/appointment';
import { AppointmentPrescription } from 'src/app/model/appointmentPrescription';
import { Prescription } from 'src/app/model/prescription';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrescriptionService {

  constructor(private http : HttpClient) { }

  getAllPrescriptions(data: Prescription): Observable<Prescription[]>{
      return this.http.post<Prescription[]>(`${environment.baseUrl}/${environment.prescription}/${environment.allPrescriptions}`,data)
  }

  getSimpleSearchResults(data : {medicine : string, hourlyIntake : number, startDate : Date, endDate : Date }) : Observable<Prescription[]> {
      return this.http.post<Prescription[]>(`${environment.baseUrl}/${environment.prescriptionSimpleSearch}`, data)
  }

  getAppointmentPrescription(data : Appointment) : Observable<AppointmentPrescription[]>
  {
      return this.http.post<AppointmentPrescription[]>(`${environment.baseUrl}/${environment.appointmentPrescription}`, data)
  }
}
