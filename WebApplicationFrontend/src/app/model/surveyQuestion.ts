
export class SurveyQuestion {

    public Id : number;
    public Question : string;
    public QuestionType : number;

    constructor(id : number, question : string, questionType : number )
    {
        this.Id = id;
        this.Question = question;
        this.QuestionType = questionType;
    }

}