import { FeedbackService } from './../../../service/feedback/feedback.service';
import { Component, OnInit } from '@angular/core';
import { ApprovedFeedback } from 'src/app/model/approvedFeedback';

@Component({
  selector: 'app-approved-feedback',
  templateUrl: './approved-feedback.component.html',
  styleUrls: ['./approved-feedback.component.css']
})
export class ApprovedFeedbackComponent implements OnInit {

  public approvedFeedback : ApprovedFeedback[] = new Array();

  constructor(private feedbackService : FeedbackService) { }

  ngOnInit(): void {
    this.loadApprovedFeedback();
  }

  loadApprovedFeedback() {
    this.feedbackService.getApprovedFeedback().subscribe(data => 
      {
        this.approvedFeedback = data
      });
  }
}
