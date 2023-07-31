import { Component, OnInit } from '@angular/core';
import { MatLegacyTableDataSource as MatTableDataSource } from '@angular/material/legacy-table';
import { Flight } from 'app/model/flight';
import { PurchasedTicket } from 'app/model/purchasedTicket';
import { FlightService } from 'app/services/flight-service';
import { ToastrService } from 'ngx-toastr';
import { TicketService } from 'app/services/ticket-service';
import { FlightFilter } from 'app/model/flightFilter';
import * as moment from 'moment';
@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {

  public dataSource = new MatTableDataSource<Flight>();
  public displayedColumns = ['takeOffCity','landingCity','takeOffDate','landingDate','ticketPricePerPassenger','ticketNumber'];
  public cities: string[]=[];
  public flights:Flight[]=[];
  public selectedFlight:Flight=new Flight();
  public flightToFind:FlightFilter=new FlightFilter();

  public purchasedTicket:PurchasedTicket=new PurchasedTicket();


  constructor(private toast : ToastrService,private flightService:FlightService,private ticketService:TicketService) { }

  ngOnInit(): void {
    this.loadCities();
    this.loadFlights();
  }

  loadCities(){
    this.flightService.getCities().subscribe(res=>{
      this.cities=res;
    })

  }

  loadFlights(){
    
    this.flightService.getFlights().subscribe(res=>{
      this.flights=res;
      this.dataSource.data = this.flights;
      console.log(this.flights);

    })
    
    
  }

  clickTicket(flight:any){
    this.selectedFlight=flight;
    if (!this.checkFields()){
      this.toast.error('All fields need to be filled!')
      return;
    }

    if(confirm("Do you want to purchase selected tickets?")) {
      this.purchasedTicket.ticketQuantity=this.flightToFind.passengersCount;
      this.purchasedTicket.flightId=this.selectedFlight.flightId;
      this.ticketService.buyTicket(this.purchasedTicket).subscribe(res=>{
        this.toast.success('Ticket bought!');
      })
    }

  }

  checkFields(){
    if(this.flightToFind.takeOffCity===''  || this.flightToFind.landingCity===""|| this.flightToFind.passengersCount===0 ){
      return false;
    }
    return true;
  }

  findFlights(){
    if (this.flightToFind.landingCity==='' || this.flightToFind.passengersCount===0 || this.flightToFind.takeOffCity===''){
      this.toast.error('All fields need to be filled!');
       return;
    }
   this.flightToFind.date = moment(this.flightToFind.date).format('yyyy-MM-DD')
    console.log(this.flightToFind.date)
    this.flightService.findFlights(this.flightToFind).subscribe(res=>{
      this.flights=res;
      this.dataSource.data = this.flights;
      console.log(this.flights);
    })
  }

}
