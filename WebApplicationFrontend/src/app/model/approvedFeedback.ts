export class ApprovedFeedback {

    public Date : Date;
    public AdditionalNotes : string;
    public Username : string;

    constructor(date : Date, additionalNotes : string, username : string) {
        this.Date = date;
        this.AdditionalNotes = additionalNotes;
        this.Username = username;
    }

}