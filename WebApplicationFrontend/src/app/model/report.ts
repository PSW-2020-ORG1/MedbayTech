
export class ReportSearch {
    public doctor : string;
    public startDate : Date;
    public endDate : Date;
    public type : string;

    constructor(doctor : string, startDate : Date, endDate : Date, type : string) {
        this.doctor = doctor;
        this.startDate = startDate;
        this.endDate = endDate;
        this.type = type;
    }
}

export class Report {
    public doctor : string;
    public date : Date;
    public type : string;

    constructor(doctor : string, date : Date, type : string) {
        this.doctor = doctor;
        this.date = date;
        this.type = type;
    }
}