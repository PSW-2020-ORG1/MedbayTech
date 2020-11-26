export class SurveyAnswer {

    public Id : number;
    public SurveyId: number
    public Grade : number;
    public SurveyQuestionId : number;

    constructor(grade : number, surveyQuestionId : number) {
        this.Grade = grade;
        this.SurveyQuestionId = surveyQuestionId;
    }

}