export class LoginRequestData {
    email: string  = ''
    password: string = ''

    public constructor(obj? : LoginRequestData){
        if(obj){
            this.email = obj?.email
            this.password = obj?.password
        }
    }
}