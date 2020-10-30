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
        private int idRecord;
        private PatientCondition currHealthState;
        private BloodType bloodType;

        private List<Allergens> allergies;
        private List<Vaccines> vaccines;
        private List<Diagnosis> illnessHistory;
        private List<FamilyIllnessHistory> familyIllnessHistory;
        private Patient patient;
        private List<ListOfResults> listOfResults;
        private List<Therapy> therapies;

        public MedicalRecord() { }

        public MedicalRecord(int id)
        {
            IdRecord = id;
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

        public int IdRecord { get => idRecord; set => idRecord = value; }
        public PatientCondition CurrHealthState { get => currHealthState; set => currHealthState = value; }
        public BloodType BloodType { get => bloodType; set => bloodType = value; }
        public List<Allergens> Allergies { get => allergies; set => allergies = value; }
        public List<Vaccines> Vaccines { get => vaccines; set => vaccines = value; }
        public List<Diagnosis> IllnessHistory { get => illnessHistory; set => illnessHistory = value; }
        public List<FamilyIllnessHistory> FamilyIllnessHistory { get => familyIllnessHistory; set => familyIllnessHistory = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public List<ListOfResults> ListOfResults { get => listOfResults; set => listOfResults = value; }
        public List<Therapy> Therapies { get => therapies; set => therapies = value; }

        public int GetId()
        {
            return IdRecord;
        }

        public void SetId(int id)
        {
            IdRecord = id;
        }
    }
}