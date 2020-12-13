import { PatientRegistrationComponent } from './registration/patient-registration/patient-registration.component';
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
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatIconModule} from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import {MatTabsModule} from '@angular/material/tabs';
import {MatStepperModule} from '@angular/material/stepper';
import { ApprovedFeedbackComponent } from './feedback/approvedFeedback/approved-feedback/approved-feedback.component';
import { AllFeedbackComponent } from './feedback/all-feedback/all-feedback.component';
import { PostFeedbackComponent } from './feedback/post-feedback/post-feedback.component';
import { FeedbackService } from './service/feedback/feedback.service';
import { SurveyComponent } from './survey/do-survey/survey/survey/survey.component';
import { SurveyService } from './service/survey/survey.service';
import { PrescriptionSearchComponent } from './search/prescription-search/prescription-search.component';
import {MatSelectModule} from '@angular/material/select';
import { MatNativeDateModule } from '@angular/material/core';
import { ReportSearchComponent } from './search/report-search/report-search.component';
import {MedicalRecordComponent} from './medical-record/medical-record.component';
import {MedicalRecordService} from './service/medicalRecord/medicalRecord.service';
import { PrescriptionSimpleSearchComponent } from './search/prescription-simple-search/prescription-simple-search.component';
import { ReportSimpleSearchComponent } from './search/report-simple-search/report-simple-search.component';
import { BlockMaliciousUsersComponent } from './block-malicious-users/block-malicious-users/block-malicious-users.component';
import { ObserveAppointmentComponent } from './appointment/observe-appointment/observe-appointment.component';
import { AppointmentService } from './service/appointment/appointment.service';
import { SchedulingComponent } from './appointment/scheduling/scheduling.component';
import { RecommendationComponent } from './appointment/recommendation/recommendation.component';

@NgModule({
  declarations: [
    AppComponent,
    ApprovedFeedbackComponent,
    AllFeedbackComponent,
    PostFeedbackComponent,
    SurveyComponent,
    PatientRegistrationComponent,
    PrescriptionSearchComponent,
    ReportSearchComponent,
    PatientRegistrationComponent,
    MedicalRecordComponent,
    PrescriptionSimpleSearchComponent,
    ReportSimpleSearchComponent,
    BlockMaliciousUsersComponent,
    ObserveAppointmentComponent,
    SchedulingComponent,
    RecommendationComponent
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
    MatTableModule,
    RouterModule,
    FormsModule,
    MatDatepickerModule,
    MatRadioModule,
    MatInputModule,
    MatTabsModule,
    MatTableModule,
    RouterModule,
    MatSelectModule,
    MatStepperModule,
    MatNativeDateModule,
    FormsModule,
    MatIconModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatTooltipModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatAutocompleteModule,
    MatFormFieldModule,
    MatRadioModule,
    MatInputModule,
    MatSelectModule,
    MatStepperModule,
    ToastrModule.forRoot()
  ],
  providers: [
    FeedbackService,
    MatDatepickerModule,
    MatNativeDateModule,
    SurveyService,
    MedicalRecordService,
    AppointmentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
