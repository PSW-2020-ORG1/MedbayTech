import { PatientRegistrationComponent } from './registration/patient-registration/patient-registration.component';
import { PostFeedbackComponent } from './feedback/post-feedback/post-feedback.component';
import { ApprovedFeedbackComponent } from './feedback/approvedFeedback/approved-feedback/approved-feedback.component';
import { AppComponent } from './app.component';

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllFeedbackComponent } from './feedback/all-feedback/all-feedback.component';
import { SurveyComponent } from './survey/do-survey/survey/survey/survey.component';
import { PrescriptionSearchComponent } from './search/prescription-search/prescription-search.component';
import { ReportSearchComponent } from './search/report-search/report-search.component';
import { MedicalRecordComponent } from './medical-record/medical-record.component';
import { PrescriptionSimpleSearchComponent } from './search/prescription-simple-search/prescription-simple-search.component';
import { ReportSimpleSearchComponent } from './search/report-simple-search/report-simple-search.component';
import { BlockMaliciousUsersComponent } from './block-malicious-users/block-malicious-users/block-malicious-users.component';
import { ObserveAppointmentComponent } from './appointment/observe-appointment/observe-appointment.component';
import { SchedulingComponent } from './appointment/scheduling/scheduling.component';
import { RecommendationComponent } from './appointment/recommendation/recommendation.component';



const routes: Routes = [

  {
    path : 'feedback',
    component : ApprovedFeedbackComponent
  },
  {
    path : 'allFeedback',
    component : AllFeedbackComponent
  },
  {
    path : 'prescriptionSearch',
    component : PrescriptionSearchComponent
  },
  {
    path : 'reportSearch',
    component : ReportSearchComponent
  },
  {
    path : 'createFeedback',
    component : PostFeedbackComponent
  },
  {
    path : 'survey',
    component : SurveyComponent
  },
  {
    path : 'patientRegistration',
    component : PatientRegistrationComponent
  },
  {
    path : 'medicalRecord',
    component : MedicalRecordComponent
  },
  {
    path : 'prescriptionSimpleSearch',
    component : PrescriptionSimpleSearchComponent
  },
  {
    path : 'reportSimpleSearch',
    component : ReportSimpleSearchComponent
  },
  {
    path : 'blockMaliciousUsers',
    component : BlockMaliciousUsersComponent
  },
  {
    path : 'observeAppointment',
    component : ObserveAppointmentComponent
  },
  {
    path : 'scheduleAppointment',
    component : SchedulingComponent
  },
  {
    path : 'appointmentRecommendation',
    component : RecommendationComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
