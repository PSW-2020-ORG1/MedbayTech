import { Diagnosis } from "./diagnosis";

export class AppointmentReport {
    public startTime : Date;
    public type : String;
    public diagnosis : Diagnosis[];
    public doctorName : String;
    public doctorSurname : String;
  reportAppointment: AppointmentReport;

    constructor(startTime : Date, type : String, diagnosis : Diagnosis[],doctorName : String, doctorSurname : String) {
        this.startTime = startTime;
        this.type = type;
        this.diagnosis = diagnosis;
        this.doctorName = doctorName;
        this.doctorSurname = doctorSurname;
    }
}