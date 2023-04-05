import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Flight } from 'app/model/flight';
import { PurchasedTicket } from 'app/model/purchasedTicket';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  apiHost: string = 'http://localhost:44329/'
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })

  constructor(private http: HttpClient) { }


  buyTicket(ticket:PurchasedTicket){
    return this.http.post<any>(this.apiHost + 'api/Ticket/purchaseTicket', ticket, { headers: this.headers });

  }

  getAllForUser(id:string){
    return this.http.get<PurchasedTicket[]>(this.apiHost + 'api/Ticket/customer/' + id, { headers: this.headers });
  }

  

}
