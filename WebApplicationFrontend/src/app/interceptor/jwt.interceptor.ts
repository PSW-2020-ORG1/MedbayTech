import { AuthenticatedUser } from './../model/authenticatedUser';
import { AuthenticationService } from './../service/authentication/authentication.service';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        const user = this.authenticationService.getUserValue();
        const isLoggedIn = user && user.token;
        const isApiUrl = req.url.startsWith(environment.baseUrl);
        if(isLoggedIn && isApiUrl) {
            req = req.clone({
                setHeaders : {
                    Authorization : `Bearer ${user.token}`
                }
            })
        }
        return next.handle(req);
    }
}