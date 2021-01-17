import { Role } from './model/role';
import { AuthGuard } from './guard/auth.guard';
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
import { LoginComponent } from './login/login/login.component';
import { HomePageComponent } from './home-page/home-page.component';
import { ObservePrescriptionComponent } from './prescription/observe-prescription/observe-prescription.component';
import { LandingPageComponent } from './landing-page/landing-page.component';



const routes: Routes = [

  {
    path : 'feedback',
    component : ApprovedFeedbackComponent
  },
  {
    path : 'allFeedback',
    component : AllFeedbackComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Admin]}
  },
  {
    path : 'prescriptionSearch',
    component : PrescriptionSearchComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Patient]}
  },
  {
    path : 'reportSearch',
    component : ReportSearchComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Patient]}
  },
  {
    path : 'createFeedback',
    component : PostFeedbackComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Patient]}
  },
  {
    path : 'survey',
    component : SurveyComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Patient]}
  },
  {
    path : 'patientRegistration',
    component : PatientRegistrationComponent
  },
  {
    path : 'medicalRecord',
    component : MedicalRecordComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Patient]}
  },
  {
    path : 'prescriptionSimpleSearch',
    component : PrescriptionSimpleSearchComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Patient]}
  },
  {
    path : 'reportSimpleSearch',
    component : ReportSimpleSearchComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Patient]}
  },
  {
    path : 'blockMaliciousUsers',
    component : BlockMaliciousUsersComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Admin]}
  },
  {
    path : 'observeAppointment',
    component : ObserveAppointmentComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Patient]}
  },
  {
    path : 'scheduleAppointment',
    component : SchedulingComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Patient]}
  },
  {
    path : 'appointmentRecommendation',
    component : RecommendationComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Patient]}
  },
  {
    path : 'login',
    component : LoginComponent
  },
  {
    path : 'home',
    component : HomePageComponent
  },
  {
    path : 'prescriptionDialog',
    component : ObservePrescriptionComponent,
    canActivate : [AuthGuard],
    data : {roles : [Role.Patient]}
  },
  {
    path: '',
    component: LandingPageComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }