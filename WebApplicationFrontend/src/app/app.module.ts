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
import {MatTabsModule} from '@angular/material/tabs';

import { ApprovedFeedbackComponent } from './feedback/approvedFeedback/approved-feedback/approved-feedback.component';
import { AllFeedbackComponent } from './feedback/all-feedback/all-feedback.component';

import { PostFeedbackComponent } from './feedback/post-feedback/post-feedback.component';
import { FeedbackService } from './service/feedback/feedback.service';

import {MedicalRecordComponent} from './medical-record/medical-record.component';
import {MedicalRecordService} from './service/medicalRecord/medicalRecord.service';

@NgModule({
  declarations: [
    AppComponent,
    ApprovedFeedbackComponent,
    AllFeedbackComponent,
    PostFeedbackComponent,
    MedicalRecordComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatListModule,
    MatCardModule,
    MatDividerModule,
    MatButtonModule,
    MatTabsModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),

    
  ],
  providers: [FeedbackService, MedicalRecordService],
  bootstrap: [AppComponent]
})
export class AppModule { }
