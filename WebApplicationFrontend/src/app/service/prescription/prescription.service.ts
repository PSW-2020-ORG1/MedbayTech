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

  getAllPrescriptions(): Observable<Prescription[]>{

    return this.http.get<Prescription[]>(`${environment.baseUrl}/${environment.prescription}/${environment.allPrescriptions}`)

  }
}
