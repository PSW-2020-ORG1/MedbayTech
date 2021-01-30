export class MaliciousPatient{
    id: string;
    username: string;
    name: string;
    surname: string;

    constructor(id:string, username: string, name: string, surname: string){
        this.id = id;
        this.username = username;
        this.name = name;
        this.surname = surname;
    }
}