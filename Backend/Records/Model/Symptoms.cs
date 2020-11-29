// File:    Symptoms.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 7:46:02 PM
// Purpose: Definition of Class Symptoms

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.General.Model;

namespace Backend.Records.Model
{
   public class Symptoms : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Diagnosis")]
        public int DiagnosisId { get; set; }
        public virtual Diagnosis Diagnosis {get; set; }

        public Symptoms() {
            
        }
        public Symptoms(string name)
        {
            this.Name = name;
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