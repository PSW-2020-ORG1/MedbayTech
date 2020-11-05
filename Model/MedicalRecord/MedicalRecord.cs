/***********************************************************************
 * Module:  MedicalRecord.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.DoctorPatient.MedicalRecord
 ***********************************************************************/

using Model.Medications;
using Model.Users;
using System;
using System.Collections.Generic;
using SimsProjekat.Repository;

namespace Model.MedicalRecord
{
   public class MedicalRecord : IIdentifiable<int>
   {

        public int Id { get; set; }
        public PatientCondition CurrHealthState { get; set; }
        public BloodType BloodType { get; set; }
        public virtual List<Allergens> Allergies { get; set; }
        public virtual List<Vaccines> Vaccines { get; set; }
        public virtual List<Diagnosis> IllnessHistory { get; set; }
        public virtual List<FamilyIllnessHistory> FamilyIllnessHistory { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual List<ListOfResults> ListOfResults { get; set; }
        public virtual List<Therapy> Therapies { get; set; }

        public MedicalRecord() { }

        public MedicalRecord(int id)
        {
            Id = id;
        }

        public MedicalRecord(BloodType bloodType, Patient patient, PatientCondition patientCondition)
        {
            BloodType = bloodType;
            Patient = patient;
            CurrHealthState = patientCondition;
            Allergies = new List<Allergens>();
            IllnessHistory = new List<Diagnosis>();
            FamilyIllnessHistory = new List<FamilyIllnessHistory>();
            Therapies = new List<Therapy>();
            ListOfResults = new List<ListOfResults>();
            Vaccines = new List<Vaccines>();
        }

       

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}