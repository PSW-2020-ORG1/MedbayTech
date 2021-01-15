export class Appointment {
    public startTime : Date;
    public doctorId : String;

    constructor(startTime : Date, doctorId : String) {
        this.startTime = startTime;
        this.doctorId = doctorId;
    }
}