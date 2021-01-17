export class AppointmentPrescription {
    public medication: string;
    public hourlyIntake: number;
    public validFrom: Date;
    public validTo: Date;
    public appointmentPrescription: AppointmentPrescription[];

    constructor(medication:string, hour: number, from:Date, to: Date){
        this.medication = medication;
        this.hourlyIntake = hour;
        this.validFrom = from;
        this.validTo = to;
    }
}