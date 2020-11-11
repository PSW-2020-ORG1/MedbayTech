// File:    Diagnosis.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:52:17 PM
// Purpose: Definition of Class Diagnosis

using System;
using System.Collections.Generic;
using SimsProjekat.Repository;

namespace Model.MedicalRecord
{
    public class Diagnosis : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Symptoms> Symptoms { get; set; }

        public int FamilyIllnessHistoryId { get; set; }
        public virtual FamilyIllnessHistory FamilyIllnessHistory  { get; set; }
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
       
        public int ExaminationSurgeryId { get; set; }
        public virtual Examinations.ExaminationSurgery ExaminationSurgery { get; set; }
        public Diagnosis() 
        {
            
        }

        public Diagnosis(int code) 
        {
            Id = code;
        }

        public Diagnosis(string name, int code, List<Symptoms> symptoms)
        {
            Name = name;
            Id = code;
            Symptoms = symptoms;
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