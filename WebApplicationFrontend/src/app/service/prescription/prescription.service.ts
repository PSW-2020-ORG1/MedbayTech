import {PrescriptionSimpleSearchComponent} from 'src/app/search/prescription-simple-search/prescription-simple-search.component'
import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Prescription } from 'src/app/model/prescription';

@Injectable({
    providedIn:'root'
})
export class PrescriptionService {

    constructor(private http : HttpClient) {}

    getSimpleSearchResults(data : {medicine : string, hourlyIntake : number, startDate : Date, endDate : Date }) : Observable<Prescription[]> {
        return this.http.post<Prescription[]>(`${environment.baseUrl}/${environment.prescriptionSimpleSearch}`, data)
    }
}