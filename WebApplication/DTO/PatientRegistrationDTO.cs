using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PatientRegistrationDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string EducationalLevel { get; set; }
        public string Profession { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int Apartment { get; set; }
        public int Floor { get; set; }
        public string PolicyNumber { get; set; }
        public string Company { get; set; }
        public DateTime PolicyStart { get; set; }
        public DateTime PolicyEnd { get; set; }
        public string PatientCondition { get; set; }
        public string BloodType { get; set; }
        public string Doctor { get; set; }

        public PatientRegistrationDTO() { }


    }
}
