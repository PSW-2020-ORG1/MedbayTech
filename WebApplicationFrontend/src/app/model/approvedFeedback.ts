export class ApprovedFeedback {

    public Date : Date;
    public AdditionalNotes : string;
    public Username : string;
    public Anonymous : boolean;
    constructor(date : Date, additionalNotes : string, username : string, anonymous : boolean) {
        this.Date = date;
        this.AdditionalNotes = additionalNotes;
        this.Username = username;
        this.Anonymous = anonymous;
    }

}