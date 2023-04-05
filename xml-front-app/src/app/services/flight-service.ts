import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Flight } from 'app/model/flight';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlightService {

  apiHost: string = 'https://localhost:44329/'
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })

  constructor(private http: HttpClient) { }

  getFlights(){
    return this.http.get<Flight[]>(this.apiHost+'api/Flight/available', { headers: this.headers });
  }

  getCities(){
    return this.http.get<string[]>(this.apiHost + 'api/Flight/cities', { headers: this.headers });
  }

  findFlights(flight:Flight){
    return this.http.post<any>(this.apiHost + 'api/Flight/find', flight, { headers: this.headers });

  }

  deleteFlight(id: string){
    return this.http.delete<any>(this.apiHost + 'api/Flight/'+ id, { headers: this.headers });
  }

  buyTicket(flight:Flight){
    return this.http.post<any>(this.apiHost + 'api/Flight/buy', flight, { headers: this.headers });

  }

  test(){
    return this.http.get<string[]>(this.apiHost + 'api/Flight/test', { headers: this.headers });
  }

  

  

}
