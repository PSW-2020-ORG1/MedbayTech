/***********************************************************************
 * Module:  MedicalRecord.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.DoctorPatient.MedicalRecord
 ***********************************************************************/

using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Entities;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords.Enums;

namespace MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords
{
    public class MedicalRecord : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public PatientCondition CurrHealthState { get; set; }
        public BloodType BloodType { get; set; }
        public virtual List<Allergens> Allergens { get; set; }
        public virtual List<Vaccines> Vaccines { get; set; }
        public virtual List<Diagnosis> IllnessHistory { get; set; }
        public virtual List<Therapy> Therapies { get; set; }
        public virtual List<FamilyIllnessHistory> FamilyIllnessHistory { get; set; }
        public string PatientId { get; set; }
        [NotMapped]
        public virtual Patient.Patient Patient { get; set; }

        public MedicalRecord() { }

        public MedicalRecord(int id)
        {
            Id = id;
        }

        public MedicalRecord(PatientCondition currHealthState, BloodType bloodType, string patientId)
        {
            CurrHealthState = currHealthState;
            BloodType = bloodType;
            Allergens = new List<Allergens>();
            Vaccines = new List<Vaccines>();
            IllnessHistory = new List<Diagnosis>();
            Therapies = new List<Therapy>();
            FamilyIllnessHistory = new List<FamilyIllnessHistory>();
            PatientId = patientId;
        }

        public MedicalRecord(MedicalRecord medicalRecord)
        {
            CurrHealthState = medicalRecord.CurrHealthState;
            BloodType = medicalRecord.BloodType;
            Allergens = medicalRecord.Allergens;
            Vaccines = medicalRecord.Vaccines;
            IllnessHistory = medicalRecord.IllnessHistory;
            Therapies = medicalRecord.Therapies;
            FamilyIllnessHistory = medicalRecord.FamilyIllnessHistory;
            PatientId = medicalRecord.PatientId;
        }

        public MedicalRecord SetPatient(Patient.Patient patient)
        {
            var record = new MedicalRecord(this);
            record.Patient = patient;
            return record; 
        }

        public bool IsFamilyIllnessHistoryAdded(FamilyIllnessHistory diagnosis)
        {
            return FamilyIllnessHistory.Any(illness => illness.Id == diagnosis.Id);
        }

        public int GetId()
        {
            return Id;
        }

    }
}