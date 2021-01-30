import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/service/authentication/authentication.service';

@Component({
  selector: 'app-navigation-bar-admin',
  templateUrl: './navigation-bar-admin.component.html',
  styleUrls: ['./navigation-bar-admin.component.css']
})
export class NavigationBarAdminComponent implements OnInit {

  constructor(private authService : AuthenticationService) { }

  ngOnInit(): void {
  }

  logout(){
    this.authService.logout();
  }

}
