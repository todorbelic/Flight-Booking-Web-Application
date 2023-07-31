import { Component } from '@angular/core';
import { PurchasedTicket } from 'app/model/purchasedTicket';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { FlightService } from 'app/services/flight-service';
import { TicketService } from 'app/services/ticket-service';
import { AuthenticationService } from 'app/services/authentication-service';
@Component({
  selector: 'app-customer-tickets',
  templateUrl: './customer-tickets.component.html',
  styleUrls: ['./customer-tickets.component.css']
})
export class CustomerTicketsComponent {
  
    public dataSource = new MatTableDataSource<PurchasedTicket>();
    public tickets:PurchasedTicket[]=[];
    public displayedColumns = ['takeOffCity','landingCity','takeOffDate','landingDate','ticketFullPrice','ticketQuantity'];
    private id:string='';


    constructor(private toast : ToastrService,private ticketService:TicketService,private authService:AuthenticationService) { }

  ngOnInit(): void {
    this.loadTickets();
  }

  loadTickets(){
    this.id=this.authService.getUserId()!;
    console.log(this.id)
    this.ticketService.getAllForUser(this.id).subscribe(res=>{
      this.tickets=res;
      this.dataSource.data=this.tickets
    })

  }
}
