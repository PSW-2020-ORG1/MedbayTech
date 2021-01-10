using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Domain.Entites.Enums;

namespace MedbayTech.Users.Domain.Entites
{
    public class MedicalRecord
    {
        public PatientCondition CurrHealthState { get; set; }
        public BloodType BloodType { get; set; }

        public string PatientId { get; set; }
        public MedicalRecord() {}
        public MedicalRecord(PatientCondition patientCondition, BloodType bloodType, string patientId)
        {
            CurrHealthState = patientCondition;
            BloodType = bloodType;
            PatientId = patientId;
        }
    }
}
