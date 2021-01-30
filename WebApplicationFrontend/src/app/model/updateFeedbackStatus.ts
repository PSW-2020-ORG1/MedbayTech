export class UpdateFeedbackStatus {

    public Id : number;
    public Approved : Boolean;

    constructor(id : number, approved : Boolean) {
        this.Id = id;
        this.Approved = approved;
    }

}