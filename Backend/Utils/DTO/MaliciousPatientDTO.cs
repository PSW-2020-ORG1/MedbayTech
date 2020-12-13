using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    public class MaliciousPatientDTO
    {
        public string Id { get; set; } 
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public MaliciousPatientDTO() { }
        public MaliciousPatientDTO(string id, string username, string name, string surname)
        {
            Id = id;
            Username = username;
            Name = name;
            Surname = surname;
        }
    }
}
