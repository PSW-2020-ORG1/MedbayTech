import { HttpClient } from '@angular/common/http';

import { Component, OnInit } from '@angular/core';

import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {

  constructor(private http : HttpClient) { 
    http.get(`${environment.baseUrl}/${environment.fedback}`)
      .subscribe(response => {
        console.log(response);
      });
  }

  ngOnInit(): void {
  }

}
