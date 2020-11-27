export class Prescription{
    public Id: number;
    public FirstOperand: string;
    public AndOr: string;
    public SecondOperand: string;


    constructor(id:number, first:string, second: string, operators:string) {
        this.Id = id;
        this.FirstOperand = first;
        this.SecondOperand = second;
        this.AndOr = operators;
    }

}
