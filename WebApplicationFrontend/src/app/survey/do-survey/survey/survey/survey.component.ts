import { Component, OnInit } from '@angular/core';
import { SurveyQuestion } from 'src/app/model/surveyQuestion';
import { SurveyService } from 'src/app/service/survey/survey.service';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {

  public allQuestions : SurveyQuestion[] = new Array();
  displayedColumns: string[] = ['question', 'excellent', 'very good', 'good', 'poor', 'very poor'];
  question: string;
  question1: string;
  question2: string;
  question3: string;
  question4: string;

  
  constructor(private surveyService : SurveyService) { }

  ngOnInit(): void {
    /*this.loadAllQuestions();*/
  }
  loadAllQuestions(){
      this.surveyService.getActiveQuestions().subscribe(data => 
      {
        this.allQuestions = data
      });
  }

}
