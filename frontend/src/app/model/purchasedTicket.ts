export class PurchasedTicket {
    flightId:string='';
    ticketQuantity:number=0;
  ticketPrice:number=0;
  ticketFullPrice:number=0
  takeOffCity:string=''
  takeOffDate:string=''
  landingCity:string=''
  landingDate:string=''

    public constructor(obj?: PurchasedTicket) {
        if (obj) {
          this.flightId = obj.flightId
          this.ticketQuantity = obj.ticketQuantity
          this.ticketPrice=obj.ticketPrice
          this.ticketFullPrice=obj.ticketFullPrice
          this.takeOffCity=obj.takeOffCity
          this.takeOffDate=obj.takeOffDate
          this.landingCity=obj.landingCity
          this.landingDate=obj.landingDate
        }
      }
}