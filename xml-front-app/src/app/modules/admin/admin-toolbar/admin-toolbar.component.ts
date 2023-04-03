import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'app/services/authentication-service';

@Component({
  selector: 'admin-toolbar',
  templateUrl: './admin-toolbar.component.html',
  styleUrls: ['./admin-toolbar.component.css']
})
export class AdminToolbarComponent {
  constructor(private router:Router, private authService: AuthenticationService) { }

  ngOnInit(): void {
  }

  HomeClick(){
    this.router.navigate(['admin-home']);
  }

  LogoutClick(){
    this.authService.logout();
    this.router.navigate(['']);
  }

}
