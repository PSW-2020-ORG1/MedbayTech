import { Component, OnInit } from '@angular/core';
import { AllFeedback } from 'src/app/model/allFeedBack';
import { FeedbackService } from 'src/app/service/feedback/feedback.service';

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
  }

  loadAllFeedback() {
    this.feedbackService.getAllFeedback().subscribe(data => 
      {
        this.allFeedback = data
      });
  }

  updateStatus(feedbackId, feedbackStatus) {
    console.log(feedbackId);
  }

}
