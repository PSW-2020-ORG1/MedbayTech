// File:    Symptoms.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 7:46:02 PM
// Purpose: Definition of Class Symptoms

using MedbayTech.Common.Domain.Common;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.Records.Model
{
   public class Symptoms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }

        public Symptoms() {
            
        }
        public Symptoms(string name)
        {
            this.Name = name;
        }

    }
}