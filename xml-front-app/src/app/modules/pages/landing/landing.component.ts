import { Component, OnInit } from '@angular/core';
import { MatLegacyTableDataSource as MatTableDataSource } from '@angular/material/legacy-table';
import { Flight } from 'app/model/flight';
import { FlightService } from 'app/services/flight-service';
import { ToastrService } from 'ngx-toastr';
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
  public selectedFlight:Flight=new Flight();

  public takeoffCountry:string='';
  public takeoffCity:string='';

  public landingCountry:string='';
  public landingCity:string='';
  public ticketNum:string='';
  public date:string='';


  constructor(private toast : ToastrService,private flightService:FlightService) { }

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
      this.selectedFlight.ticketNum=parseInt(this.ticketNum);
      this.flightService.buyTicket(this.selectedFlight).subscribe(res=>{
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
