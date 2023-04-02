export class NewFlightDTO {
    takeOffLocation: Geolocation = new Geolocation()
    landingLocation: Geolocation = new Geolocation()
    takeOffDate: Date = new Date()
    landingDate: Date = new Date()
    quantity: number = 0
    price: number = 0

    public constructor(obj?: NewFlightDTO){
        if(obj){
            this.takeOffLocation = obj.takeOffLocation
            this.landingLocation = obj.landingLocation
            this.landingDate = obj.landingDate
            this.takeOffDate = obj.takeOffDate
            this.quantity = obj.quantity
            this.price = obj.price
        }
    }
}
