import { ThrowStmt } from '@angular/compiler';

export class AppointmentRecommendation {
    public startInterval : Date;
    public endInterval : Date;
    public doctorId : string;
    public priority : number;

    constructor(startInterval : Date, endInterval : Date, doctorId : string, priority : number) {
        this.startInterval = startInterval;
        this.endInterval = endInterval;
        this.doctorId = doctorId;
        this.priority = priority;
    }
}