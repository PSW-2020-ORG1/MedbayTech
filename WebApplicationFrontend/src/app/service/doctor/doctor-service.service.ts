import { SpecializationId } from './../../model/specializationId';
import { Observable } from 'rxjs';
import { SearchDoctor } from './../../model/searchDoctor';
import { Injectable } from '@angular/core';
import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';
import { env } from 'process';

@Injectable({
  providedIn: 'root'
})
export class DoctorServiceService {

  constructor(private http : HttpClient) { }

  getAllDoctors() : Observable<SearchDoctor[]> {
    return this.http.get<SearchDoctor[]>(`${environment.baseUrl}/${environment.doctor}/${environment.searchDoctor}`);
  }

  getDoctorsBySpecialization(specializationId : number) : Observable<SearchDoctor[]> {
    return this.http.get<SearchDoctor[]>(`${environment.baseUrl}/${environment.doctor}/${environment.doctorsBySpecialization}/${specializationId}`);
  }
}
