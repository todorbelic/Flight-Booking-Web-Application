import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../model/user';
import { LoginRequestData } from 'app/model/loginRequestData';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  apiHost: string = 'https://localhost:44329/'
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })

  constructor(private http: HttpClient) { }

  registerUser(user: User): Observable<any> {
    return this.http.post(this.apiHost + 'api/User/Register', user, { headers: this.headers, responseType: 'text'})
  }

  logInUser(credentials:LoginRequestData): Observable<string> {
    return this.http.post(this.apiHost + 'api/User/Login', credentials, { headers: this.headers, responseType: 'text' })
  }

  public setSession(token:any) {
     const decoded: any = jwt_decode(token);
     localStorage.setItem('currentUser', token);
     localStorage.setItem('role', decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']);
     localStorage.setItem('userId', decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid']);
     localStorage.setItem('email', decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress']);
     localStorage.setItem("expires_at", decoded['exp']);
     console.log(this.getExpiration());
   }
 
   logout() {
    localStorage.clear();
   }
 
   public isLoggedIn() {
      var currentDateTime = new Date().toISOString();
      return currentDateTime < this.getExpiration().toISOString();
   }
 
     isLoggedOut() {
         return !this.isLoggedIn();
     }
 
   getExpiration() {
     const timeStamp: number = Number(localStorage.getItem("expires_at"));
     const date: Date = new Date(timeStamp * 1000);
     return date;
     }
 
     getRole() {
     return localStorage.getItem("role");
     }
     getUserId() {
       return localStorage.getItem("userId");
     }
 
     getEmail() {
       return localStorage.getItem("email");
     }

}
