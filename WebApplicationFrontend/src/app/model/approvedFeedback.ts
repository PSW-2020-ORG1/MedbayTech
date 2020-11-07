export class ApprovedFeedback {

    public Date : Date;
    public AdditionalNotes : string;
    public Name : string;
    public Surname : string;
    public AllowedForPublishing : boolean
    public Anonymous : boolean;
    constructor(date : Date, additionalNotes : string, name : string, surname : string , allowedForPublishing : boolean, anonymous : boolean) {
        this.Date = date;
        this.AdditionalNotes = additionalNotes;
        this.Name = name;
        this.Surname = surname;
        this.AllowedForPublishing = allowedForPublishing;
        this.Anonymous = anonymous;
    }

}