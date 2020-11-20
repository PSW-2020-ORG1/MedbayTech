import { Diagnosis } from './diagnosis';
import { FamilyIllnessHistory } from './familyIllnessHistory';
import { Therapy } from './therapy';

export class MedicalRecord {
    public PatientId : string;
    public Name : string;
    public Surname : string;
    public Gender : string;
    public DateOfBirth : Date;
    public BloodType : string;
    public Address : string;
    public Phone : string;
    public Email : string;
    public InsurancePolicyCompany : string;
    public InsurancePolicyFrom : Date;
    public InsurancePolicyTo : Date;
    public PatientCondition : string;
    public Allergies : Array<string>;
    public Vaccines : Array<string>;
    public IllnesHistory: Array<Diagnosis>;
    public FamilyIllnessHistory: Array<FamilyIllnessHistory>;
    public Therapies : Array<Therapy>;

    constructor(patientId : string, name : string, surname : string, gender : string, 
        dateOfBirth : Date, bloodType : string, address : string, phone : string, email : string,
        insurancePolicyCompany : string, insurancePolicyFrom : Date, insurancePolicyTo : Date,
        patientCondition : string, allergies : Array<string>, vaccines : Array<string>,
        illnesHistory: Array<Diagnosis>, familyIllnesHistory: Array<FamilyIllnessHistory>,
         therapies: Array<Therapy>) {

            this.PatientId = patientId;
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.BloodType = bloodType;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.InsurancePolicyCompany = insurancePolicyCompany;
            this.InsurancePolicyFrom = insurancePolicyFrom;
            this.InsurancePolicyTo = insurancePolicyTo;
            this.PatientCondition = patientCondition;
            this.Allergies= allergies;
            this.Vaccines = vaccines ;
            this.IllnesHistory = illnesHistory;
            this.FamilyIllnessHistory = familyIllnesHistory ;
            this.Therapies = therapies;
        }   
}