/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Doctor.Doctor
 ***********************************************************************/

using MedbayTech.Common.Domain.Entities;

namespace MedbayTech.Appointment.Domain.Entities
{
   public class Doctor 
   {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenseNumber { get;  set; }
        public int SpecializationId { get; set; }
        public int ExaminationRoomId { get; set; }

        public Doctor() {}

        public Doctor(string id, string name, string surname, int specializationId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            SpecializationId = specializationId;
        }

    }
}