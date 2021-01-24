import { Diagnosis } from "./diagnosis";

export class AppointmentReport {
    public startTime : Date;
    public type : string;
    public diagnosis : Diagnosis[];
    public doctorName : string;
    public doctorSurname : string;
  reportAppointment: AppointmentReport;

    constructor(startTime : Date, type : string, diagnosis : Diagnosis[],doctorName : string, doctorSurname : string) {
        this.startTime = startTime;
        this.type = type;
        this.diagnosis = diagnosis;
        this.doctorName = doctorName;
        this.doctorSurname = doctorSurname;
    }
}