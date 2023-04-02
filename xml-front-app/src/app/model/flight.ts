export class Flight {
    takeOffCity: string = ''
    landingCity: string = ''
    takeOffTime: string=''
    landingTime : string = ''
    ticketNum:number=0
    id:string=''

    public constructor(obj?: Flight) {
        if (obj) {
          this.takeOffCity = obj.takeOffCity
          this.landingCity = obj.landingCity
          this.takeOffTime = obj.takeOffTime
          this.landingTime = obj.landingTime
        }
      }
}