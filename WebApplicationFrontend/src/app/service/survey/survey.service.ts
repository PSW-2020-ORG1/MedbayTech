import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SurveyQuestion } from 'src/app/model/surveyQuestion';
import { PostSurvey } from 'src/app/model/postSurvey';


@Injectable({
  providedIn: 'root'
})
export class SurveyService {

  

  constructor(private http : HttpClient) { 
    
  }

  getActiveQuestions() : Observable<SurveyQuestion[]> {
    
    return this.http.get<SurveyQuestion[]>(`${environment.baseUrl}/${environment.survey}/${environment.allQuestions}`)

  }

  createSurvey(survey:PostSurvey){
    return this.http.post(`${environment.baseUrl}/${environment.survey}/${environment.createSurvey}`, survey, {responseType:'text'})
  }


  
}
