export class Diagnosis {
    public Name : string;
    public Symptoms : Array<string>;

    constructor(name : string, symptoms : Array<string>) {
        this.Name = name;
        this.Symptoms = symptoms;
    }
}