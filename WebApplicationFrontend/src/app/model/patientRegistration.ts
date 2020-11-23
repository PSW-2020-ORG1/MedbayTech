export class PatientRegistration {
    public Name : string;
    public Surname : string;
    public Id : string;
    public DateOfBirth : Date;
    public Phone : string;
    public Email : string;
    public Username : string;
    public Password : string;
    public ConfirmPassword : string;
    public EducationLevel : string;
    public Profession : string;
    public Gender : string;
    public PostalCode : number;
    public City : string;
    public State : string;
    public Street : string;
    public Number : number;
    public Apartment : number;
    public Floor : number;
    public PolicyNumber : string;
    public Company : string;
    public PolicyStart : Date;
    public PolicyEnd : Date;
    public PatientCondition : string;
    public BloodType : string;
    public Doctor : string;
    public CityOfBirth : string;
    public PostalCodeBirth : string;
    public StateOfBirth : string;

    constructor(id : string, name : string, surname : string, dateOfBirth : Date, phone : string, email : string, username: string,
                password : string, confirmPassword : string, educationalLevel : string, profession : string,
                gender : string, postalCode : number, city : string, state : string, street : string, number : number, apartment : number,
                floor : number, policyNumber : string, company : string, policyStart : Date, policyEnd : Date, patientCondition : string, 
                bloodType : string, doctor : string, cityOfBirth : string, postalCodeBirth : string, stateOfBirth : string) {
                    this.Id = id;
                    this.Name = name;
                    this.Surname = surname;
                    this.DateOfBirth = dateOfBirth;
                    this.Phone = phone;
                    this.Email = email;
                    this.Username = username;
                    this.Password = password;
                    this.ConfirmPassword = confirmPassword;
                    this.EducationLevel = educationalLevel;
                    this.Profession = profession;
                    this.Gender = gender;
                    this.PostalCode = postalCode;
                    this.City = city;
                    this.State = state;
                    this.Street = street;
                    this.Number = number;
                    this.Apartment = apartment;
                    this.Floor = floor;
                    this.PolicyNumber = policyNumber;
                    this.Company = company;
                    this.PolicyStart = policyStart;
                    this.PolicyEnd = policyEnd;
                    this.PatientCondition = patientCondition;
                    this.BloodType = bloodType;
                    this.Doctor = doctor;
                    this.CityOfBirth = cityOfBirth;
                    this.PostalCodeBirth = postalCodeBirth;
                    this.CityOfBirth = cityOfBirth;
                }


}