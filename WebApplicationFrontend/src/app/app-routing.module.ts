import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PostFeedbackComponent } from './feedback/post-feedback/post-feedback.component';

const routes: Routes = [
  {
    path: 'postFeedback',
    component : PostFeedbackComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
