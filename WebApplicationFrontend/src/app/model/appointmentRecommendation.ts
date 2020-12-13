
export class AppointmentRecommendation {
    public startInterval : Date;
    public endInterval : Date;
    public doctorId : string;
    public priority : number;
    public specializationId : number;

    constructor(startInterval : Date, endInterval : Date, doctorId : string, priority : number, specializationId : number) {
        this.startInterval = startInterval;
        this.endInterval = endInterval;
        this.doctorId = doctorId;
        this.priority = priority;
        this.specializationId = specializationId;
    }
}