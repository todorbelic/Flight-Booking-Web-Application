import { GeoLocation } from "./geo-location"

export interface NewFlightDTO {
    takeOffLocation: GeoLocation 
    landingLocation: GeoLocation
    takeOffDate: Date 
    landingDate: Date 
    quantity: number 
    price: number
}
