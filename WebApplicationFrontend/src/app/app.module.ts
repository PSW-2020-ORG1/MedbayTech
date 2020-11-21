import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule} from 'ngx-toastr';


import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {MatButtonModule} from '@angular/material/button'; 
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatList, MatListModule} from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatRadioModule} from '@angular/material/radio';

import { ApprovedFeedbackComponent } from './feedback/approvedFeedback/approved-feedback/approved-feedback.component';
import { AllFeedbackComponent } from './feedback/all-feedback/all-feedback.component';

import { PostFeedbackComponent } from './feedback/post-feedback/post-feedback.component';
import { FeedbackService } from './service/feedback/feedback.service';
import { PrescriptionSearchComponent } from './search/prescription-search/prescription-search.component';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatTableModule} from '@angular/material/table';
import { ReportSearchComponent } from './search/report-search/report-search.component';





@NgModule({
  declarations: [
    AppComponent,
    ApprovedFeedbackComponent,
    AllFeedbackComponent,
    PostFeedbackComponent,
    PrescriptionSearchComponent,
    ReportSearchComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatDividerModule,
    MatButtonModule,
    MatDatepickerModule,
    MatRadioModule,
    MatTableModule,
    RouterModule,
    MatSelectModule,
    MatNativeDateModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),

    
  ],
  providers: [
    FeedbackService,
    MatDatepickerModule
  ],
  bootstrap: [AppComponent],
  
})
export class AppModule { }
