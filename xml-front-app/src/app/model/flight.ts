export class Flight {

    takeOffCity: string = ''
    landingCity: string = ''
    takeOffDate: string=''
    landingDate : string = ''
    ticketNumber:number=0
    ticketPricePerPassenger:number=9
    ticketPriceTotal:number=0
    flightId:string=''

    public constructor(obj?: Flight) {
        if (obj) {
          this.takeOffCity = obj.takeOffCity
          this.landingCity = obj.landingCity
          this.takeOffDate = obj.takeOffDate
          this.landingDate = obj.landingDate
          this.ticketNumber=obj.ticketNumber
          this.ticketPricePerPassenger=obj.ticketPricePerPassenger
          this.flightId=obj.flightId
        }
      }
}