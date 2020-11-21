import { PostFeedbackComponent } from './feedback/post-feedback/post-feedback.component';
import { ApprovedFeedbackComponent } from './feedback/approvedFeedback/approved-feedback/approved-feedback.component';
import { AppComponent } from './app.component';

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllFeedbackComponent } from './feedback/all-feedback/all-feedback.component';
import { PrescriptionSearchComponent } from './search/prescription-search/prescription-search.component';
import { ReportSearchComponent } from './search/report-search/report-search.component';

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
    path : "**",
    component : AppComponent
  }

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
