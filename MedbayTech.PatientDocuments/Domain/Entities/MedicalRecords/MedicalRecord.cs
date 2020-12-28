/***********************************************************************
 * Module:  MedicalRecord.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.DoctorPatient.MedicalRecord
 ***********************************************************************/

using System.Collections.Generic;
using System.Linq;

using Backend.Records.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Medications.Model;
using MedbayTech.Common.Domain.Entities;

namespace Backend.Records.Model
{
   public class MedicalRecord : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public PatientCondition CurrHealthState { get; set; }
        public BloodType BloodType { get; set; }
        [NotMapped]
        public virtual List<Allergens> Allergies { get; set; }
        [NotMapped]
        public virtual List<Vaccines> Vaccines { get; set; }
        [NotMapped]
        public virtual List<Diagnosis> IllnessHistory { get; set; }
        [NotMapped]
        public virtual List<Therapy> Therapies { get; set; }
        [NotMapped]
        public virtual List<FamilyIllnessHistory> FamilyIllnessHistory { get; set; }
        public string PatientId { get; set; }

        public MedicalRecord() { }

        public MedicalRecord(int id)
        {
            Id = id;
        }

        public MedicalRecord(BloodType bloodType, string patientId, PatientCondition patientCondition)
        {
            BloodType = bloodType;
            PatientId = patientId;
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

        public bool IsFamilyIllnessHistoryAdded(FamilyIllnessHistory diagnosis)
        {
            return FamilyIllnessHistory.Any(illness => illness.Id == diagnosis.Id);
        }

   }
}