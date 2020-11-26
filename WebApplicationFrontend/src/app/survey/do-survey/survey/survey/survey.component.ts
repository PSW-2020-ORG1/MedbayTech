import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AppointmentSurvey } from 'src/app/model/appointmentSurvey';
import { PostSurvey } from 'src/app/model/postSurvey';
import { SurveyQuestion } from 'src/app/model/surveyQuestion';
import { SurveyService } from 'src/app/service/survey/survey.service';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {

  //postForm: FormGroup;
  postSurvey : PostSurvey;
  public allQuestions : SurveyQuestion[] = new Array();
  questionList : number[] = new Array();
  appointmentId : number = 1;
  answers : number[] = new Array;
  questions : number[] = new Array;

  constructor(private surveyService : SurveyService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.loadAllQuestions();
    /*this.postForm = new FormGroup({
        'questionList[1]' : new FormControl(null, [Validators.required])
    });*/
  }
  loadAllQuestions(){
      this.surveyService.getActiveQuestions().subscribe(data => 
      {
        this.allQuestions = data
      });
  }
  onSubmit(){
      for(var question of this.allQuestions)
      {
          this.questions.push(question.Id);
          this.answers.push(this.questionList[question.Id]);
      }
      this.postSurvey = new PostSurvey(this.appointmentId, this.answers, this.questions);
      this.surveyService.createSurvey(this.postSurvey).subscribe(
        res => {
          this.toastr.success(res);
        },
        error => {
          this.toastr.error("error");
        }     
      );

  }

}
