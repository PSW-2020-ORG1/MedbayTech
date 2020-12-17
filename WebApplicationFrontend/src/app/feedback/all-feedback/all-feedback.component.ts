import { Component, OnInit } from '@angular/core';
import { AllFeedback } from 'src/app/model/allFeedback';
import { FeedbackService } from 'src/app/service/feedback/feedback.service';
import { UpdateFeedbackStatus } from 'src/app/model/updateFeedbackStatus'
import { Button } from 'protractor';

@Component({
  selector: 'app-all-feedback',
  templateUrl: './all-feedback.component.html',
  styleUrls: ['./all-feedback.component.css']
})
export class AllFeedbackComponent implements OnInit {

  public allFeedback : AllFeedback[] = new Array();

  constructor(private feedbackService : FeedbackService) { }

  ngOnInit(): void {
    this.loadAllFeedback();
    console.log(this.allFeedback[0]);
  }

  loadAllFeedback() {
    this.feedbackService.getAllFeedback().subscribe(data => 
      {
        this.allFeedback = data
      });
  }

  updateStatus(feedbackId, feedbackStatus, element) { 
      this.feedbackService.updateFeedbackStatus(new UpdateFeedbackStatus(feedbackId, feedbackStatus)).subscribe();
      location.reload();
  }

}
