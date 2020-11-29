export class SurveyQuestion {

    public id : number;
    public question : string;
    public questionType : number;
    public excellent : number;
    public veryGood : number;
    public good : number;
    public poor : number;
    public veryPoor : number;
    public averageGrade : number;

    constructor(id : number, question : string, questionType : number, excellent : number, veryGood : number, good : number, poor : number, veryPoor : number, averageGrade : number)
    {
        this.id = id;
        this.question = question;
        this.questionType = questionType;
        this.excellent = excellent;
        this.veryGood = veryGood;
        this.good = good;
        this.poor = poor;
        this.veryPoor = veryPoor;
        this.averageGrade = averageGrade;
    }

}