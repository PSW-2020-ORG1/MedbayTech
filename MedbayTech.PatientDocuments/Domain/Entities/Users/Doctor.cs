using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Domain.Entities.Users
{
    public class Doctor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Doctor() {}

        public Doctor(string id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}
