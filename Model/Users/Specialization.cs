// File:    Specialization.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:27:27 PM
// Purpose: Definition of Class Specialization

using System;

namespace Model.Users
{
   public class Specialization
   {
        private string specialization;
        
        public Specialization(string specialization)
        {
            this.SpecializationName = specialization;
        }

        public string SpecializationName { get => specialization; set => specialization = value; }
    }
}