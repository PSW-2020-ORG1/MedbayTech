import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from './../../../environments/environment';
import { ReportSimpleSearchComponent } from 'src/app/search/report-simple-search/report-simple-search.component'

@Injectable({
    providedIn:'root'
})

export class ReportService {
    constructor(private http : HttpClient) {}
}