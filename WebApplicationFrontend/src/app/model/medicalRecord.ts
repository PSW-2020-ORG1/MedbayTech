
export class MedicalRecord {
    public PatientId : string;
    public Name : string;
    public Surname : string;
    public Gender : string;
    public DateOfBirth : Date;
    public BloodType : string;
    public City : string;
    public State : string;
    public Street : string;
    public Number : number;
    public Apartment : number;
    public Phone : string;
    public Email : string;
    public InsurancePolicyCompany : string;
    public InsurancePolicyFrom : Date;
    public InsurancePolicyTo : Date;
    public PatientCondition : string;
    public Allergies : string[];
    public Vaccines : string[];
    public IllnessHistoryName : string[];
    public IllnessHistorySymptoms : string[];
    public FamilyIllnessHistoryRelatives : string[];
    public FamilyIllnessHistoryDiagnosis : string[];
    public TherapiesHourConsumption : number[];
    public TherapiesMedication : string[];

    constructor(patientId : string, name : string, surname : string, gender : string, 
        dateOfBirth : Date, bloodType : string, city : string, state : string, street : string,
        number : number, apartment : number, phone : string, email : string,
        insurancePolicyCompany : string, insurancePolicyFrom : Date, insurancePolicyTo : Date,
        patientCondition : string, allergies : string[], vaccines : string[],
        illnessHistoryName : string[], illnessHistorySymptoms : string[], 
        familyIllnessHistoryRelatives : string[], familyIllnessHistoryDiagnosis : string[],
        therapiesHourConsumption : number[], therapiesMedication : string[]) 
        {
            this.PatientId = patientId;
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.BloodType = bloodType;
            this.City = city;
            this.State = state;
            this.Street = street;
            this.Number = number;
            this.Apartment = apartment;
            this.Phone = phone;
            this.Email = email;
            this.InsurancePolicyCompany = insurancePolicyCompany;
            this.InsurancePolicyFrom = insurancePolicyFrom;
            this.InsurancePolicyTo = insurancePolicyTo;
            this.PatientCondition = patientCondition;
            this.Allergies= allergies;
            this.Vaccines = vaccines ;
            this.IllnessHistoryName = illnessHistoryName;
            this.IllnessHistorySymptoms = illnessHistorySymptoms;
            this.FamilyIllnessHistoryRelatives = familyIllnessHistoryRelatives;
            this.FamilyIllnessHistoryDiagnosis = familyIllnessHistoryDiagnosis;
            this.TherapiesHourConsumption = therapiesHourConsumption;
            this.TherapiesMedication = therapiesMedication;
        }   
}