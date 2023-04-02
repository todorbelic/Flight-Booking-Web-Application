export class Flight {
    TakeOffLocation: string = ''
    LandingLocation: string = ''
    TakeOffDate: string=''
    LandingDate : string = ''

    public constructor(obj?: Flight) {
        if (obj) {
          this.TakeOffLocation = obj.TakeOffLocation
          this.LandingLocation = obj.LandingLocation
          this.TakeOffDate = obj.TakeOffDate
          this.LandingDate = obj.LandingDate
        }
      }
}