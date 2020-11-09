// File:    Specialization.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:27:27 PM
// Purpose: Definition of Class Specialization

using System;

namespace Model.Users
{
   public class Specialization
   {
        public int Id { get; set; }
        public string SpecializationName { get; set; }

        public Specialization() {}
        public Specialization(string specialization)
        {
            this.SpecializationName = specialization;
        }

       
    }
}