export class AllFeedback {

    public Id : number;
    public Date : Date;
    public AdditionalNotes : string;
    public Approved : Boolean;
    public Name : string;
    public Surname : string;
    public Anonymous : Boolean;
    public AllowedForPublishing : Boolean;

    constructor(id : number, date : Date, additionalNotes : string,approved : Boolean, name : string, surname : string, anonymous : Boolean, allowedForPublishing : Boolean) {
        this.Id = id;
        this.Date = date;
        this.AdditionalNotes = additionalNotes;
        this.Approved = approved;
        this.Name = name;
        this.Surname = surname;
        this.Anonymous = anonymous;
        this.AllowedForPublishing = allowedForPublishing;
    }

}