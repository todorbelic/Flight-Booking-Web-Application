import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Flight } from 'app/model/flight';
import { Observable } from 'rxjs';
import { NewFlightDTO } from 'app/model/new-flight-dto';
import { FlightFilter } from 'app/model/flightFilter';

@Injectable({
  providedIn: 'root'
})
export class FlightService {

  apiHost: string = 'https://localhost:44329/'
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })

  constructor(private http: HttpClient) { }

  getFlights():Observable<Flight[]>{
    return this.http.get<Flight[]>(this.apiHost+'api/Flight/available', { headers: this.headers});
  }

  getCities(){
    return this.http.get<string[]>(this.apiHost + 'api/Flight/cities', { headers: this.headers });
  }

  findFlights(flight:FlightFilter){
    return this.http.post<any>(this.apiHost + 'api/Flight/getFiltered', flight, { headers: this.headers });

  }

  deleteFlight(id: string) : Observable<any>{
    return this.http.delete(this.apiHost + 'api/Flight/'+ id, { headers: this.headers, responseType: 'text' });
  }

  buyTicket(flight:Flight){
    return this.http.post<any>(this.apiHost + 'api/Flight/buy', flight, { headers: this.headers });

  }

  addNewFlight(dto: NewFlightDTO): Observable<any>{
    return this.http.post<any>(this.apiHost + "api/Flight/",dto ,{headers: this.headers})
  }

  

}
