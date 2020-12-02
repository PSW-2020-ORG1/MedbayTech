export class Report{
    
    public doctorName: string;
    public doctorSurname: string;
    public andOr: string;
    public diagnosis: string;
    public dateOfExamination: string;
    public allergens: string;


    constructor(doctorName:string, doctorSurname: string, diagnosis: string, date: string, allergens:string) {
        this.doctorName = doctorName;
        this.doctorSurname = doctorSurname;
        this.diagnosis = diagnosis;
        this.dateOfExamination = date;
        this.allergens = allergens;
    }

}
