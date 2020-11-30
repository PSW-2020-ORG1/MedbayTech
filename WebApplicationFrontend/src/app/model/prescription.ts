export class Prescription{
    public medicine: string;
    public hourlyIntake: number;
    public date : Date;

    constructor(medicine:string, hour: number, date : Date) {
        this.medicine = medicine;
        this.hourlyIntake = hour;
        this.date = date;
    }

}

export class PrescriptionSearch {
    public medicine : string;
    public hourlyIntake : number;
    public startDate : Date;
    public endDate : Date;

    constructor (medicine : string, hourlyIntake : number, startDate : Date, endDate : Date) {
        this.medicine = medicine;
        this.hourlyIntake = hourlyIntake;
        this.startDate = startDate;
        this.endDate = endDate;
    }
}