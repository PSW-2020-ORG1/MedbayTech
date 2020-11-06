import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FeedbackService } from 'src/app/service/feedback/feedback.service';

@Component({
  selector: 'app-post-feedback',
  templateUrl: './post-feedback.component.html',
  styleUrls: ['./post-feedback.component.css']
})
export class PostFeedbackComponent implements OnInit {

  constructor(public service : FeedbackService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form!=null)
      form.resetForm();
    this.service.formData = {
      AdditionalNotes : '',
      Date : 0,
      Anonymous : true,
      Approved : false,
      Username : ''
    }
  }
}
