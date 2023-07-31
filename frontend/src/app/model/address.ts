export class Address {
    country: string = ''
    city: string = ''
    street: string = ''
    streetNumber : string = ''

    public constructor(obj?: Address) {
        if (obj) {
          this.country = obj.country
          this.city = obj.city
          this.street = obj.street
          this.streetNumber = obj.streetNumber
        }
      }
}