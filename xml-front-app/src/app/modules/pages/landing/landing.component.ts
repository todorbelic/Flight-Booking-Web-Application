import { Component, OnInit } from '@angular/core';
import { MatLegacyTableDataSource as MatTableDataSource } from '@angular/material/legacy-table';
import { Flight } from 'app/model/flight';
import { FlightService } from 'app/services/flight-service';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {

  public dataSource = new MatTableDataSource<Flight>();
  public displayedColumns = ['takeoffLoc','landingLoc','takeoffTime','landingTime'];
  public cities: string[]=[];
  public flights:Flight[]=[];

  constructor(private flightService:FlightService) { }

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

  test(){
    this.flightService.test().subscribe(res=>{
        console.log(res)

    })
  }

}
