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
        public virtual Doctor ChosenDoctor { get; set; }
        public MedicalRecord MedicalRecord { get; set; }



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
