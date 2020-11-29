import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PostSurvey } from 'src/app/model/postSurvey';
import { SurveyQuestion } from 'src/app/model/surveyQuestion';
import { SurveyService } from 'src/app/service/survey/survey.service';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {

  postSurvey : PostSurvey;
  public allQuestions : SurveyQuestion[] = new Array();
  questionList : number[] = new Array();
  appointmentId : number = 4;
  answers : number[] = new Array;
  questions : number[] = new Array;

  constructor(private surveyService : SurveyService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.loadAllQuestions();
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
          this.questions.push(question.id);
          this.answers.push(this.questionList[question.id]);
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
