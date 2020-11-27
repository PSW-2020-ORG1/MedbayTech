import { runInThisContext } from 'vm';

export class Report {
    public Doctor : string;
    public Date : Date;
    public Treatment : string;

    constructor(doctor : string, date : Date, treatment : string) {
        this.Doctor = doctor;
        this.Date = date;
        this.Treatment = treatment;
    }
}