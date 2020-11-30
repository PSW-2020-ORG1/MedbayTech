export class Prescription{
    
    public medication: string;
    public andOr: string;
    public hourlyIntake: string;


    constructor(id:number, medication:string, hour: string, operators:string) {
        
        this.medication = medication;
        this.hourlyIntake = hour;
        this.andOr = operators;
    }

}
