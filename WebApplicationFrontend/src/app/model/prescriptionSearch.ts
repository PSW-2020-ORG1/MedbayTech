export class PrescriptionSearch{
    public Id: number;
    public Medicine: string;
    public HourlyIntake: string;
    public ReservationPeriod: Period;

    constructor(id:number, medicine:string, hour: string, period: Period) {
        this.Id = id;
        this.Medicine = medicine;
        this.HourlyIntake = hour;
        this.ReservationPeriod = period;
    }

}

export class Period{
    public StartTime: Date;
    public EndTime: Date;

    constructor(startTime: Date, endTime: Date){
        this.StartTime = startTime;
        this.EndTime = endTime;
    }
}