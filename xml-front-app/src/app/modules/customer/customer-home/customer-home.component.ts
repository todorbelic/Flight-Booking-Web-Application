import { Component } from '@angular/core'
import {  MatTableDataSource } from '@angular/material/table'
import { Flight } from 'app/model/flight'
import { PurchasedTicket } from 'app/model/purchasedTicket'
import { FlightService } from 'app/services/flight-service'
import { ToastrService } from 'ngx-toastr'
import { TicketService } from 'app/services/ticket-service'

@Component({
  selector: 'customer-home',
  templateUrl: './customer-home.component.html',
  styleUrls: ['./customer-home.component.css']
})
export class CustomerHomeComponent {
  public dataSource = new MatTableDataSource<Flight>();
  public displayedColumns = ['takeoffLoc','landingLoc','takeoffTime','landingTime'];
  public cities: string[]=[];
  public flights:Flight[]=[];
  public selectedFlight:Flight=new Flight();

  public takeoffCountry:string='';
  public takeoffCity:string='';

  public landingCountry:string='';
  public landingCity:string='';
  public ticketNum:string='';
  public date:string='';
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
    console.log("ajcnsdkjcnalio");
    this.selectedFlight=flight;
    if (!this.checkFields()){
      this.toast.error('All fields need to be filled!')
      return;
    }

    if(confirm("Do you want to purchase selected tickets?")) {
      this.purchasedTicket.numOfPassengers=parseInt(this.ticketNum);
      this.purchasedTicket.flightId=this.selectedFlight.id;
      this.ticketService.buyTicket(this.purchasedTicket).subscribe(res=>{
        this.toast.success('Ticket bought!');
      })
    }

  }

  checkFields(){
    if(this.takeoffCountry==='' || this.takeoffCity==='' || this.landingCity==="" || this.landingCountry==='' || this.ticketNum==='' || this.date===''){
      return false;
    }
    return true;
  }

  test(){
    this.flightService.test().subscribe(res=>{
        console.log(res)

    })
  }

}
