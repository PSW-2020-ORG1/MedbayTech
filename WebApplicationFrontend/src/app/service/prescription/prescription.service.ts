import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Prescription } from 'src/app/model/prescriptionSearch';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrescriptionService {

  constructor(private http : HttpClient) { }

  getAllPrescriptions(data: Prescription): Observable<Prescription[]>{

    return this.http.post<Prescription[]>(`${environment.baseUrl}/${environment.prescription}/${environment.allPrescriptions}`,data)

  }
}
