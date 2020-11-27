export class Prescription{
    public Id: number;
    public Medicine: string;
    public AndOr: boolean;
    public HourlyIntake: number;


    constructor(id:number, medicine:string, hour: number) {
        this.Id = id;
        this.Medicine = medicine;
        this.HourlyIntake = hour;
    }

}
