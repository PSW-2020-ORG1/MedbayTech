/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Doctor.Doctor
 ***********************************************************************/

using MedbayTech.Common.Domain.Entities;

namespace MedbayTech.Rooms.Domain
{
   public class Doctor : IIdentifiable<string>
   {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenseNumber { get;  set; }
        public bool OnCall { get;  set; }
        public Doctor() {}

        public Doctor(string id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
            OnCall = false;
        }

        public string GetId()
        {
            return Id;
        }
    }
}