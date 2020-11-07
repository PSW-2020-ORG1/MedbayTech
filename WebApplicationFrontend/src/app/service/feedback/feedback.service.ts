import { ApprovedFeedback } from './../../model/approvedFeedback';
import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
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

  createFeedback(feedback:PostFeedback){
    return this.http.post(`${environment.baseUrl}/${environment.fedback}/${environment.createFeedback}`, feedback, {responseType:'text'})
  }

 
  
}
