import { Component, OnInit } from '@angular/core';
import { GeoLocation } from 'src/app/model/geo-location';
import { NewFlightDTO } from 'src/app/model/new-flight-dto';
import { NewFlightService } from 'src/app/services/new-flight.service';

@Component({
  selector: 'app-new-flight-form',
  templateUrl: './new-flight-form.component.html',
  styleUrls: ['./new-flight-form.component.css']
})
export class NewFlightFormComponent implements OnInit {
  landingLocation: GeoLocation = {
    latitude: 0,
    longitude: 0,
    city: '',
    country: ''
  }
  takeOffLocation: GeoLocation  = {
    latitude: 0,
    longitude: 0,
    city: '',
    country: ''
  };
  landingDate: Date = new Date()
  takeOffDate: Date = new Date()
  quantity: number =0;
  price: number = 0;

  takeOffLatitude: number = 0;
  takeOffLongitude: number = 0;

  landingLatitude: number = 0;
  landingLongitude: number = 0;

  dto: NewFlightDTO = {
    takeOffLocation: this.takeOffLocation,
    landingLocation: this.landingLocation,
    takeOffDate: this.takeOffDate,
    landingDate: this.landingDate,
    quantity: 0,
    price: 0
  }

  constructor(private newFlightService: NewFlightService){}

  ngOnInit(): void {}
  addFlight(){
    this.takeOffLocation.latitude = this.takeOffLatitude
    this.takeOffLocation.longitude = this.takeOffLongitude
    
    this.landingLocation.latitude = this.landingLatitude
    this.landingLocation.longitude = this.landingLongitude

    this.dto.takeOffLocation = this.takeOffLocation
    this.dto.landingLocation = this.landingLocation
    this.dto.takeOffDate = this.takeOffDate
    this.dto.landingDate= this.landingDate
    this.dto.price = this.price
    this.dto.quantity = this.quantity

    this.newFlightService.addNewFlight(this.dto).subscribe(res => {console.log(res)})
  }


}
