export class AllFeedback {

    public Id : number;
    public Date : Date;
    public AdditionalNotes : string;
    public Approved : Boolean;
    public Username : string;
    public Anonymous : Boolean;

    constructor(id : number, date : Date, additionalNotes : string,approved : Boolean, username : string, anonymous : Boolean) {
        this.Id = id;
        this.Date = date;
        this.AdditionalNotes = additionalNotes;
        this.Approved = approved;
        this.Username = username;
        this.Anonymous = anonymous;
    }

}