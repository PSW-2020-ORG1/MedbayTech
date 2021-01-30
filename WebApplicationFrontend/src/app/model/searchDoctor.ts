import { ThrowStmt } from '@angular/compiler';

export class SearchDoctor {

    public id : string;
    public fullName : string

    constructor(id : string, fullName : string) {
        this.fullName = fullName;
        this.id = id;
    }
}