import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Flight } from 'app/model/flight';
import { ToastrService } from 'ngx-toastr';
import { FlightService } from 'app/services/flight-service';
import { TicketService } from 'app/services/ticket-service';
@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent {
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

}
