// File:    Symptoms.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 7:46:02 PM
// Purpose: Definition of Class Symptoms

using System;

namespace Model.MedicalRecord
{
   public class Symptoms
   {
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