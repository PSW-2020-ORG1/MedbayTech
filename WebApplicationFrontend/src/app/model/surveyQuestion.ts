import { QuestionType } from './questionType';

export class SurveyQuestion {

    public Id : number;
    public Question : string;
    public Status : QuestionType;

    constructor(id : number, status : QuestionType, question : string) {
        this.Id = id;
        this.Question = question;
        this.Status = status;
    }

}