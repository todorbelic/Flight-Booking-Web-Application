import { Component } from '@angular/core';
import { PurchasedTicket } from 'app/model/purchasedTicket';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-customer-tickets',
  templateUrl: './customer-tickets.component.html',
  styleUrls: ['./customer-tickets.component.css']
})
export class CustomerTicketsComponent {
  
    public dataSource = new MatTableDataSource<PurchasedTicket>();
    public displayedColumns = ['takeoffCity','landingCity','takeoffDate','landingDate','ticketPricePerPassenger','ticketNumber'];
}
