import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'app/services/authentication-service';

@Component({
  selector: 'customer-toolbar',
  templateUrl: './customer-toolbar.component.html',
  styleUrls: ['./customer-toolbar.component.css']
})
export class CustomerToolbarComponent {

  constructor(private router:Router, private authService: AuthenticationService) { }

  ngOnInit(): void {
  }

  HomeClick(){
    this.router.navigate(['/customer-home']);
  }
  TicketsClick(){
    this.router.navigate(['/customer-tickets']);
  }


  LogoutClick(){
    this.authService.logout();
    this.router.navigate(['']);

  }
}
