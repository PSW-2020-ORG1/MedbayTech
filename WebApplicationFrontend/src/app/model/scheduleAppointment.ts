export class ScheduleAppointment {
    public startTime : Date;
    public endTime : Date;
    public patientId : string;
    public doctorId : string;

    constructor(startTime : Date, endTime : Date, patientId : string, doctorId : string) {
        this.startTime = startTime;
        this.endTime = endTime;
        this.patientId = patientId;
        this.doctorId = doctorId;
    }
}