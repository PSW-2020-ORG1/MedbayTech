/***********************************************************************
 * Module:  MedicalRecord.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.DoctorPatient.MedicalRecord
 ***********************************************************************/

using Backend.Medications.Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.General.Model;

using Backend.Records.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Records.Model
{
   public class MedicalRecord : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public PatientCondition CurrHealthState { get; set; }
        public BloodType BloodType { get; set; }
        public virtual List<Allergens> Allergies { get; set; }
        public virtual List<Vaccines> Vaccines { get; set; } 
        public virtual List<Diagnosis> IllnessHistory { get; set; }
        public virtual List<FamilyIllnessHistory> FamilyIllnessHistory { get; set; }
        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }
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

        public bool IsFamilyIllnessHistoryAdded(FamilyIllnessHistory diagnosis)
        {
            return FamilyIllnessHistory.Any(illness => illness.Id == diagnosis.Id);
        }

        public bool IsTherapyAdded(Therapy therapy)
        {
            return Therapies.Any(currTherapy => currTherapy.Medication.Id == therapy.Medication.Id);
        }

        public bool IsVaccineAdded(Vaccines vaccine)
        {
            return Vaccines.Any(currVaccines => currVaccines.Id == vaccine.Id);
        }

        public bool IsAllergyAdded(Allergens allergens)
        {
            return Allergies.Any(allergy => allergy.Id == allergens.Id);
        }
   }
}