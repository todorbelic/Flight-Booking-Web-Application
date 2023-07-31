import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Flight } from 'app/model/flight';
import { ToastrService } from 'ngx-toastr';
import { FlightService } from 'app/services/flight-service';
import { TicketService } from 'app/services/ticket-service';
import { FlightFilter } from 'app/model/flightFilter';
import * as moment from 'moment';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent {
  public dataSource = new MatTableDataSource<Flight>();
  public displayedColumns = ['takeOffCity','landingCity','takeOffDate','landingDate','ticketPricePerPassenger','ticketNumber', 'delete-flight-buttons'];
  public cities: string[]=[];
  public flights:Flight[]=[];
  public selectedFlight:Flight=new Flight();

  public flightToFind:FlightFilter=new FlightFilter();




  constructor(private toast : ToastrService,private flightService:FlightService,private ticketService:TicketService) { }

  ngOnInit(): void {
    //this.loadCities();
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
    })
  }

  deleteFlight(flight: Flight){
    this.flightService.deleteFlight(flight.flightId).subscribe(res=>{
     this.toast.success('Flight deleted successfully!')
     this.dataSource.data = this.flights.filter(f=> f.flightId!==flight.flightId)
    })
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
