import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PrescriptionSearch } from 'src/app/model/prescriptionSearch';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrescriptionService {

  constructor(private http : HttpClient) { }

  getAllPrescriptions(): Observable<PrescriptionSearch[]>{

    return this.http.get<PrescriptionSearch[]>(`${environment.baseUrl}/${environment.prescription}/${environment.allPrescriptions}`)

  }
}
