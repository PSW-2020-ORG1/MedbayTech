
export class AppointmentRecommendation {
    public startInterval : Date;
    public endInterval : Date;
    public doctorId : string;
    public priority : number;
    public specializationId : string;

    constructor(startInterval : Date, endInterval : Date, doctorId : string, priority : number, specializationId : string) {
        this.startInterval = startInterval;
        this.endInterval = endInterval;
        this.doctorId = doctorId;
        this.priority = priority;
        this.specializationId = specializationId;
    }
}