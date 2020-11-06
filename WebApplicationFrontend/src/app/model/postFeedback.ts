export class PostFeedback {

    public Date : number;
    public AdditionalNotes : string;
    public Username : string;
    public Anonymous : boolean;
    public Approved : boolean;

    constructor(date : number, additionalNotes : string, username : string, anonymous : boolean, approved : boolean) {
        this.Date = date;
        this.AdditionalNotes = additionalNotes;
        this.Username = username;
        this.Anonymous = anonymous;
        this.Approved = approved;
    }

}