export class PostFeedback {

    public AdditionalNotes : string;
    public Anonymous : boolean;
    public AllowedForPublishing : boolean;
    public UserId : string;

    constructor(additionalNotes : string,  anonymous : boolean, allowed : boolean, userid:string) {
        this.AdditionalNotes = additionalNotes;
        this.Anonymous = anonymous;
        this.AllowedForPublishing = allowed;
        this.UserId = userid;
    }

}