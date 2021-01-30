import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Specialization } from 'src/app/model/specialization';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SpecializationService {

  constructor(private http : HttpClient) { }

  getAll() : Observable<Specialization[]> {
    return this.http.get<Specialization[]>(`${environment.baseUrl}/${environment.allSpecializations}`);
  }
}
