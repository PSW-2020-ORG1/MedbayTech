import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from './../../../environments/environment';
import { ReportSimpleSearchComponent } from 'src/app/search/report-simple-search/report-simple-search.component'
import { Report, ReportSearch } from 'src/app/model/report';
import { start } from 'repl';
import { Appointment } from 'src/app/model/appointment';
import { AppointmentReport } from 'src/app/model/appointmentReport';

@Injectable({
    providedIn:'root'
})

export class ReportService {
    constructor(private http : HttpClient) {}

    getSimpleSearchResults(data : ReportSearch) : Observable<Report[]> {
        return this.http.post<Report[]>(`${environment.baseUrl}/${environment.reportSimpleSearch}`, data)
    }
    getAppointmentReport(data : Appointment) : Observable<AppointmentReport>
    {
        return this.http.post<AppointmentReport>(`${environment.baseUrl}/${environment.appointmentReport}`, data)
    }
}