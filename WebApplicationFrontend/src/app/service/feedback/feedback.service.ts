import { ApprovedFeedback } from './../../model/approvedFeedback';
import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AllFeedback } from 'src/app/model/allFeedback';
import { UpdateFeedbackStatus } from 'src/app/model/updateFeedbackStatus';
import { PostFeedback } from 'src/app/model/postFeedback';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  

  constructor(private http : HttpClient) { 
    
  }

  getApprovedFeedback() : Observable<ApprovedFeedback[]> {
    
    return this.http.get<ApprovedFeedback[]>(`${environment.baseUrl}/${environment.fedback}`)

  }

  getAllFeedback(): Observable<AllFeedback[]>{

    return this.http.get<AllFeedback[]>(`${environment.baseUrl}/${environment.fedback}/${environment.allFeedback}`)

  }

  updateFeedbackStatus(data: UpdateFeedbackStatus) : Observable<UpdateFeedbackStatus>{
    return this.http.post<UpdateFeedbackStatus>(`${environment.baseUrl}/${environment.fedback}/${environment.updateFeedbackStatus}`, data)
  }
  createFeedback(feedback:PostFeedback){
    return this.http.post(`${environment.baseUrl}/${environment.fedback}/${environment.createFeedback}`, feedback, {responseType:'text'})
  }

 
  
}
