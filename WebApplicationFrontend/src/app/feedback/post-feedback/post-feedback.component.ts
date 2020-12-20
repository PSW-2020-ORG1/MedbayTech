import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PostFeedback } from 'src/app/model/postFeedback';
import { FeedbackService } from 'src/app/service/feedback/feedback.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-post-feedback',
  templateUrl: './post-feedback.component.html',
  styleUrls: ['./post-feedback.component.css']
})
export class PostFeedbackComponent implements OnInit {

  postFeedback: PostFeedback;
  postForm: FormGroup;
  allowed:boolean;
  anonymous:boolean;
  additionalNotes:string;
  userId:string;

  constructor(private service : FeedbackService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.postForm = new FormGroup({
      'additionalNotes' : new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(500)]),
      'anonymous' : new FormControl('yes', [Validators.required]),
      'allowed' : new FormControl('no', [Validators.required])
      

    });
    
  }

  public onSubmit(){
    this.allowed = this.isAllowed();
    this.anonymous = this.isAnonymous();
    this.additionalNotes = this.postForm.value.additionalNotes;
    this.userId = "2406978890045"; //this should be registered user id
    this.postFeedback = new PostFeedback(this.additionalNotes, this.anonymous, this.allowed, this.userId);
    this.service.createFeedback(this.postFeedback).subscribe(
      res => {
        this.postForm.reset();
        alert("success");
      },
      error => {
        alert("error");
      }
    
    
    );


    
  }

  private isAnonymous () : boolean {
    const radios = this.postForm.value.anonymous;
    if(radios == "yes"){
      return true;
    }
    return false;
  }

  private isAllowed () : boolean {
    const radios = this.postForm.value.allowed;
    if(radios == "yes"){
      return true;
    }
    return false;
  }
}
