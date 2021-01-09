import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/service/authentication/authentication.service';

@Component({
  selector: 'app-navigation-bar-patient',
  templateUrl: './navigation-bar-patient.component.html',
  styleUrls: ['./navigation-bar-patient.component.css']
})
export class NavigationBarPatientComponent implements OnInit {

  constructor(private authService : AuthenticationService) { }

  ngOnInit(): void {
  }

  logout(){
    this.authService.logout();
  }
  

}
