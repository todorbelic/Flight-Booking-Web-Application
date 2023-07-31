import { Address } from "./address"

export class User {
    firstName : string = ''
    lastName : string = ''
    email : string = ''
    password : string = ''
    address : Address = new Address()
    role : string = ''

    public constructor(obj?: User) {
        if (obj) {
          this.firstName = obj.firstName
          this.lastName = obj.lastName
          this.email = obj.email
          this.password =obj.password
          this.address = obj.address
          this.role = obj.role
        }
      }
} 