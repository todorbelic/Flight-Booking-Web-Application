export class PurchasedTicket {
    flightId:string='';
    numOfPassengers:number=0;

    public constructor(obj?: PurchasedTicket) {
        if (obj) {
          this.flightId = obj.flightId
          this.numOfPassengers = obj.numOfPassengers
        }
      }
}