/***********************************************************************
 * Module:  PatientCondition.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.MutualClasses.PatientCondition
 ***********************************************************************/

using System;

namespace MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords.Enums
{
    public enum PatientCondition
    {
        Stable,
        Urgent,
        HospitalTreatment,
        HomeTreatment
    }
}