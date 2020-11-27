import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from './../../../environments/environment';
import { ReportSimpleSearchComponent } from 'src/app/search/report-simple-search/report-simple-search.component'
import { Report } from 'src/app/model/report';

@Injectable({
    providedIn:'root'
})

export class ReportService {
    constructor(private http : HttpClient) {}

    getSimpleSearchResults(doctor : string, startDate : Date, endDate : Date, treatment : string) : Observable<Report[]> {
        return this.http.get<Report[]>(`${environment.baseUrl}/${environment.reportSimpleSearch}`)
    }
}