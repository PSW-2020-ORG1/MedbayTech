import {MedicalRecordComponent} from 'src/app/medical-record/medical-record.component'
import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MedicalRecord } from 'src/app/model/medicalRecord';

@Injectable({
    providedIn:'root'
})
export class MedicalRecordService {

    constructor(private http : HttpClient) {}

    getMedicalRecordByPatientId() : Observable<MedicalRecord> {
        return this.http.get<MedicalRecord>(`${environment.baseUrl}/${environment.medicalRecord}`)
    }
}