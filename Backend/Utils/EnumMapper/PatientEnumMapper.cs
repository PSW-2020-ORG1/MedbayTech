using Backend.Records.Model;
using Backend.Records.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.EnumMapper
{
    public class PatientEnumMapper
    {
        public static PatientCondition StringToCondition(string patientCondition)
        {
            if (patientCondition.ToLower().Equals("Stable"))
                return PatientCondition.Stable;
            else if (patientCondition.ToLower().Equals("Urgent"))
                return PatientCondition.Urgent;
            else if (patientCondition.ToLower().Equals("HospitalTreatment"))
                return PatientCondition.HospitalTreatment;
            else
                return PatientCondition.HomeTreatment;
        }

        public static BloodType StringToBloodType(string bloodType)
        {
            if (bloodType.ToLower().Equals("ONeg"))
                return BloodType.ONeg;
            else if (bloodType.ToLower().Equals("OPlus"))
                return BloodType.OPlus;
            else if (bloodType.ToLower().Equals("ANeg"))
                return BloodType.AbNeg;
            else if (bloodType.ToLower().Equals("APlus"))
                return BloodType.APlus;
            else if (bloodType.ToLower().Equals("BNeg"))
                return BloodType.BNeg;
            else if (bloodType.ToLower().Equals("BPlus"))
                return BloodType.BPlus;
            else if (bloodType.ToLower().Equals("AbNeg"))
                return BloodType.AbNeg;
            else
                return BloodType.AbPlus;
        }
    }
}
