// File:    Specialization.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:27:27 PM
// Purpose: Definition of Class Specialization

using System;

namespace Model.Users
{
   public class Specialization
   {
        public int Id { get; protected set; }
        public string SpecializationName { get; protected set; }

        public Specialization() {}
        public Specialization(int id, string specialization)
        {
            Id = id;
            this.SpecializationName = specialization;
        }

       
    }
}