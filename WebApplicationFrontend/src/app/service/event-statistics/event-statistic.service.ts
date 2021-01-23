import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EventStatisticService {

  constructor(private http : HttpClient) { }

  getCreatedCount() : Observable<number> {
    return this.http.get<number>(`${environment.baseUrl}/${environment.createdCount}`);
  }

  getBackStepCount() : Observable<number> {
    return this.http.get<number>(`${environment.baseUrl}/${environment.backStepCount}`);
  }

  getQuitCount() : Observable<number> {
    return this.http.get<number>(`${environment.baseUrl}/${environment.quitCount}`);
  }

  getSucceedQuitRatio() : Observable<number[]> {
    return this.http.get<number[]>(`${environment.baseUrl}/${environment.succeedQuitRatio}`);
  }

  getAverageNumberOfStepsForSuccessful() : Observable<number> {
    return this.http.get<number>(`${environment.baseUrl}/${environment.averageNumberOfStepsForSuccessful}`);
  }
  getAverageSchedulingTime() : Observable<number> {
    return this.http.get<number>(`${environment.baseUrl}/${environment.averageSchedulingTime}`);
  }

  getAverageTimeFromStartedToSpecialization() : Observable<number> {
    return this.http.get<number>(`${environment.baseUrl}/${environment.getAverageTimeFromStartedToSpecialization}`);
  }

  getAverageTimeFromSpecializationToDoctor() : Observable<number> {
    return this.http.get<number>(`${environment.baseUrl}/${environment.getAverageTimeFromSpecializationToDoctor}`);
  }

  getAverageTimeFromDoctorToAppointment() : Observable<number> {
    return this.http.get<number>(`${environment.baseUrl}/${environment.getAverageTimeFromDoctorToSelectAppointment}`);
  }
}
