// File:    Diagnosis.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:52:17 PM
// Purpose: Definition of Class Diagnosis

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Backend.Examinations.Model;
using Backend.General.Model;

namespace Backend.Records.Model
{
    public class Diagnosis : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Symptoms> Symptoms { get; set; }
        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        public virtual ExaminationSurgery ExaminationSurgery { get; set; }

        [ForeignKey("ExaminationSurgery")]
        public int ExaminationSurgeryId { get; set; }

        public Diagnosis() 
        {
            
        }

        public Diagnosis(int code) 
        {
            Id = code;
        }

        public Diagnosis(string name, int code) 
        {
            Name = name;
            Id = code;
            Symptoms = new List<Symptoms>();
        }

      
        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
      
        public bool IsMySymptom(IEnumerable<Symptoms> symptoms)
        {
            foreach (Symptoms symptom in symptoms)
            {
                if (Symptoms.Any(entity => entity.Name.Equals(symptom.Name)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}