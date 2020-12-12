export class AppointmentScheduling {
    public doctorId : string;
    public date : Date;

    constructor(doctorId : string, date : Date) {
        this.doctorId = doctorId;
        this.date = date;
    }
}