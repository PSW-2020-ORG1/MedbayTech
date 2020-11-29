export class PostSurvey {

    public appointmentId : number;
    public surveyQuestions : number[];
    public surveyAnswers : number[];


    constructor(appointmentId : number, surveyAnswers : number[],surveyQuestions : number[]) {
        this.appointmentId = appointmentId;
        this.surveyAnswers = surveyAnswers;
        this.surveyQuestions = surveyQuestions;
    }

}