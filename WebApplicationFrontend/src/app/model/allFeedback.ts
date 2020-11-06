export class AllFeedback {

    public Id : number;
    public Date : Date;
    public AdditionalNotes : string;
    public Approved : Boolean;
    public Username : string;

    constructor(id : number, date : Date, additionalNotes : string,approved : Boolean, username : string) {
        this.Id = id;
        this.Date = date;
        this.AdditionalNotes = additionalNotes;
        this.Approved = approved;
        this.Username = username;
    }

}