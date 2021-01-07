import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Authentication } from 'src/app/model/authentication';
import { environment } from 'src/environments/environment';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  login(credentials: Authentication){
    return this.http.post(`${environment.baseUrl}/${environment.authenticate}`, credentials, {responseType : 'text'})
    .pipe(tap(response => {
        let result = JSON.stringify(response);
        //console.log(response)
        localStorage.setItem('token', result)
    }));
  }

  logout(){
    localStorage.removeItem('token');
  }
}
