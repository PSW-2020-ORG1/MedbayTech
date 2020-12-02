export class ApprovedFeedback {

    public date : Date;
    public additionalNotes : string;
    public name : string;
    public surname : string;
    public allowedForPublishing : boolean
    public anonymous : boolean;
    constructor(date : Date, additionalNotes : string, name : string, surname : string , allowedForPublishing : boolean, anonymous : boolean) {
        this.date = date;
        this.additionalNotes = additionalNotes;
        this.name = name;
        this.surname = surname;
        this.allowedForPublishing = allowedForPublishing;
        this.anonymous = anonymous;
    }

}