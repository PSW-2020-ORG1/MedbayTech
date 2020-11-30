
export class MedicalRecord {
    public patientId : string;
    public name : string;
    public surname : string;
    public gender : string;
    public dateOfBirth : Date;
    public bloodType : string;
    public city : string;
    public state : string;
    public street : string;
    public number : number;
    public apartment : number;
    public phone : string;
    public email : string;
    public insurancePolicyCompany : string;
    public insurancePolicyFrom : Date;
    public insurancePolicyTo : Date;
    public patientCondition : string;
    public allergies : string[];
    public vaccines : string[];
    public illnessHistoryName : string[];
    public illnessHistorySymptoms : string[];
    public familyIllnessHistoryRelatives : string[];
    public familyIllnessHistoryDiagnosis : string[];
    public therapiesHourConsumption : number[];
    public therapiesMedication : string[];
    public img : string;

    constructor(patientId : string, name : string, surname : string, gender : string, 
        dateOfBirth : Date, bloodType : string, city : string, state : string, street : string,
        number : number, apartment : number, phone : string, email : string,
        insurancePolicyCompany : string, insurancePolicyFrom : Date, insurancePolicyTo : Date,
        patientCondition : string, allergies : string[], vaccines : string[],
        illnessHistoryName : string[], illnessHistorySymptoms : string[], 
        familyIllnessHistoryRelatives : string[], familyIllnessHistoryDiagnosis : string[],
        therapiesHourConsumption : number[], therapiesMedication : string[], img : string) 
        {
            this.patientId = patientId;
            this.name = name;
            this.surname = surname;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.bloodType = bloodType;
            this.city = city;
            this.state = state;
            this.street = street;
            this.number = number;
            this.apartment = apartment;
            this.phone = phone;
            this.email = email;
            this.insurancePolicyCompany = insurancePolicyCompany;
            this.insurancePolicyFrom = insurancePolicyFrom;
            this.insurancePolicyTo = insurancePolicyTo;
            this.patientCondition = patientCondition;
            this.allergies= allergies;
            this.vaccines = vaccines ;
            this.illnessHistoryName = illnessHistoryName;
            this.illnessHistorySymptoms = illnessHistorySymptoms;
            this.familyIllnessHistoryRelatives = familyIllnessHistoryRelatives;
            this.familyIllnessHistoryDiagnosis = familyIllnessHistoryDiagnosis;
            this.therapiesHourConsumption = therapiesHourConsumption;
            this.therapiesMedication = therapiesMedication;
            this.img = img;
        }   
}