export class Prescription{
    public Medicine: string;
    public HourlyIntake: string;
    public Date : Date;

    constructor(medicine:string, hour: string, date : Date) {
        this.Medicine = medicine;
        this.HourlyIntake = hour;
        this.Date = date;
    }

}