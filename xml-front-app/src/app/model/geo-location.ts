export class GeoLocation {
    latitude: number = 0
    longitude: number = 0
    city: string = ''
    country: string = ''

    public constructor(obj?: GeoLocation){
        if(obj){
            this.latitude = obj.latitude
            this.longitude = obj.longitude
            this.city = obj.city
            this.country = obj.country
        }
    }
}
