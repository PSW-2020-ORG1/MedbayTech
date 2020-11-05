// File:    Vaccines.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 7:47:44 PM
// Purpose: Definition of Class Vaccines

using System;

namespace Model.MedicalRecord
{
   public class Vaccines
   {
        public  int Id { get; set; }
        public string Name { get; set; }

        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        public Vaccines() {}
        public Vaccines(string name)
        {
            Name = name;
        }
     
    }
}