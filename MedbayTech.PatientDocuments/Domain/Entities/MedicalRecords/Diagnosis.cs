// File:    Diagnosis.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:52:17 PM
// Purpose: Definition of Class Diagnosis

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MedbayTech.Common.Domain.Entities;
using MedbayTech.Common.Domain.Entities.Generalities;

namespace MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords
{
    public class Diagnosis : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Symptoms> Symptoms { get; set; }
        public int FamilyIllnessHistoryId { get; set; }
        public int ReportId { get; set; }
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