import { Component, OnInit } from '@angular/core';
import { User } from 'app/model/user';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from 'app/services/authentication-service';
import { Address } from 'app/model/address';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registrationUser : User = new User()
  registrationAddress : Address = new Address()
  testPassword : string = ''
  constructor(private toast : ToastrService, private authService : AuthenticationService) { }

  ngOnInit(): void {
  }

  signUp() {
    if(this.validityChecked()) {
      this.registrationUser.address = this.registrationAddress
      this.authService.registerUser(this.registrationUser).subscribe(res => {
        console.log(res)
      })
    }
  }

  validityChecked(){
    if (this.registrationUser.password !== this.testPassword) {
      this.toast.error('Password fields need to be matching!')
      return false;
    }
    else if(this.fieldsAreEmpty(this.registrationAddress) || this.fieldsAreEmpty(this.registrationUser)) {
      this.toast.error('All fields need to be filled!')
      return false
    }
    return true
  }


fieldsAreEmpty(object: Object) { 
  return Object.values(object).some(
      value => {
      if (value === null || value === '')  return true
      return false
    })
}

}

