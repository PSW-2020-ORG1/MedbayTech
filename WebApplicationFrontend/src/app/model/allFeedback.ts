export class AllFeedback {

    public id : number;
    public date : Date;
    public additionalNotes : string;
    public approved : Boolean;
    public name : string;
    public surname : string;
    public anonymous : Boolean;
    public allowedForPublishing : Boolean;

    constructor(id : number, date : Date, additionalNotes : string,approved : Boolean, name : string, surname : string, anonymous : Boolean, allowedForPublishing : Boolean) {
        this.id = id;
        this.date = date;
        this.additionalNotes = additionalNotes;
        this.approved = approved;
        this.name = name;
        this.surname = surname;
        this.anonymous = anonymous;
        this.allowedForPublishing = allowedForPublishing;
    }

}