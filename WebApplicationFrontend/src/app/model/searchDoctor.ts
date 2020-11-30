import { ThrowStmt } from '@angular/compiler';

export class SearchDoctor {

    public id : string;
    public FullName : string

    constructor(id : string, fullName : string) {
        this.FullName = fullName;
        this.id = id;
    }
}