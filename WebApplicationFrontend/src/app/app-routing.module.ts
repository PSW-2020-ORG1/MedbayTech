import { PatientRegistrationComponent } from './registration/patient-registration/patient-registration.component';
import { PostFeedbackComponent } from './feedback/post-feedback/post-feedback.component';
import { ApprovedFeedbackComponent } from './feedback/approvedFeedback/approved-feedback/approved-feedback.component';
import { AppComponent } from './app.component';

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllFeedbackComponent } from './feedback/all-feedback/all-feedback.component';
import { SurveyComponent } from './survey/do-survey/survey/survey/survey.component';


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
    path : "**",
    component : AppComponent
  }

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
