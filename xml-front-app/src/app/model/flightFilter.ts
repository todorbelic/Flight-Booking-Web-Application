export class FlightFilter {

    takeOffCity: string = ''
    landingCity: string = ''
    
    date : string = ''
    passengersCount:number=0

    public constructor(obj?: FlightFilter) {
        if (obj) {
          this.takeOffCity = obj.takeOffCity
          this.landingCity = obj.landingCity
          this.date = obj.date
          this.passengersCount=obj.passengersCount
          }
      }
}