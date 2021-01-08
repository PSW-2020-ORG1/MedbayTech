using MedbayTech.GraphicEditor.ViewModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.ViewModel
{
    public class Patient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ChosenDoctorId { get; set; }
        public virtual Doctor ChosenDoctor { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string Profession { get; set; }
        public string ProfileImage { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }



        public Patient(string id, string name, string surname, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            ChosenDoctor = null;
            DateOfBirth = dateOfBirth;
        }

        public Patient() { }
    }
}
