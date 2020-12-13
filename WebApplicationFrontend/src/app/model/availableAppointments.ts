export class AvailableAppointments {
    public start : Date;
    public end : Date;
    public doctorId : string;
    public doctorFullName : string;

    constructor(start : Date, end : Date, doctorId : string, doctorFullName : string) {
        this.start = start;
        this.end = end;
        this.doctorId = doctorId;
        this.doctorFullName = doctorFullName;
    }
}