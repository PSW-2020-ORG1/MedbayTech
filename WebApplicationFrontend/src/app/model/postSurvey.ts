



export class PostSurvey {

    public AppointmentId : number;
    public SurveyQuestions : number[];
    public SurveyAnswers : number[];


    constructor(appointmentId : number, surveyAnswers : number[],surveyQuestions : number[]) {
        this.AppointmentId = appointmentId;
        this.SurveyAnswers = surveyAnswers;
        this.SurveyQuestions = surveyQuestions;
    }

}