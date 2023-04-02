import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  apiHost: string = 'https://localhost:44329/'
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })

  constructor(private http: HttpClient) { }

  registerUser(user: User): Observable<any> {
    return this.http.post<any>(this.apiHost + 'api/User/Register', user, { headers: this.headers })
  }

  logInUser(): Observable<string> {
    return this.http.post<string>(this.apiHost + 'api/User/Login', { headers: this.headers })
  }


}
