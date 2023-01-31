export class User{
    username: string;
    password: string;


    constructor(usuario: string, password: string){
        this.username = usuario;
        this.password = password;
    }
}