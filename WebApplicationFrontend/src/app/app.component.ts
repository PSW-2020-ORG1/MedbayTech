import { AuthenticatedUser } from './model/authenticatedUser';
import { AuthenticationService } from 'src/app/service/authentication/authentication.service';
import { Component } from '@angular/core';
import { Role } from './model/role';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'WebApplicationFrontend';
  user : AuthenticatedUser;

  constructor(private authService : AuthenticationService) {}

  public isAdmin() {
    return this.authService.getUserValue() && this.authService.getUserValue().role === Role.Admin;
  }
  public isPatient() {
    return this.authService.getUserValue() && this.authService.getUserValue().role === Role.Patient;
  }
  public isNotLogged() {
    return !this.authService.getUserValue();
  }
  logout(){
    this.authService.logout();  
  }
}
