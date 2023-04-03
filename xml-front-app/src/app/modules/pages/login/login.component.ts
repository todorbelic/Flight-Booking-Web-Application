import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRequestData } from 'app/model/loginRequestData';
import { AuthenticationService } from 'app/services/authentication-service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  credentials : LoginRequestData = new LoginRequestData()
  constructor(private authService : AuthenticationService, private toast : ToastrService, private router: Router) { }

  ngOnInit(): void {
  }

  logInUser(){
    if(this.validityChecked()) {
      this.authService.logInUser(this.credentials).subscribe(res => {
        this.authService.setSession(res);
        let role=this.authService.getRole();
        if(role==='CUSTOMER') this.router.navigate(['/customer-home']);
        else if (role==='ADMIN') this.router.navigate(['/admin-home']);
        else console.log('ERROR: no such user type');

        console.log(role);
          
      }, error=>{
        this.toast.error('Login unsuccessful!');
      })
    }
  }

  validityChecked(){
    if(this.credentials.email !=='' && this.credentials.password !== '') return true
    this.toast.error('you have to fill up all fields!')
    return false
  }
}
