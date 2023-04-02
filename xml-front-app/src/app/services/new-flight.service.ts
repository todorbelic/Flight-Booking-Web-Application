import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewFlightDTO } from '../model/new-flight-dto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NewFlightService {

  apiHost: string = 'https://localhost:44329/'
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })
  
  constructor(private http: HttpClient) { }

  addNewFlight(dto: NewFlightDTO): Observable<any>{
    return this.http.post<any>(this.apiHost + "api/Flight/",dto ,{headers: this.headers})
  }
}
