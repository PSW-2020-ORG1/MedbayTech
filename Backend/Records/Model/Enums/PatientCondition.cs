/***********************************************************************
 * Module:  PatientCondition.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.MutualClasses.PatientCondition
 ***********************************************************************/

using Model.Users;
using System;

namespace Backend.Records.Model.Enums
{
   public enum PatientCondition
   {
      Stable,
      Urgent,
      HospitalTreatment,
      HomeTreatment
   }
}