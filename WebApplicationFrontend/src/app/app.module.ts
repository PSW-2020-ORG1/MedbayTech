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
import {MatTableModule} from '@angular/material/table'; 

import { ApprovedFeedbackComponent } from './feedback/approvedFeedback/approved-feedback/approved-feedback.component';
import { AllFeedbackComponent } from './feedback/all-feedback/all-feedback.component';

import { PostFeedbackComponent } from './feedback/post-feedback/post-feedback.component';
import { FeedbackService } from './service/feedback/feedback.service';
import { SurveyComponent } from './survey/do-survey/survey/survey/survey.component';
import { SurveyService } from './service/survey/survey.service';

@NgModule({
  declarations: [
    AppComponent,
    ApprovedFeedbackComponent,
    AllFeedbackComponent,
    PostFeedbackComponent,
    SurveyComponent
   
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
    MatTableModule,
    RouterModule,
    FormsModule,
    MatRadioModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),

    
  ],
  providers: [FeedbackService,SurveyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
