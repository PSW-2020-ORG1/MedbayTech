// File:    Specialization.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:27:27 PM
// Purpose: Definition of Class Specialization

using Backend.General.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Users
{
   public class Specialization : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public string SpecializationName { get; set; }

        public Specialization() {}
        public Specialization(int id, string specialization)
        {
            Id = id;
            this.SpecializationName = specialization;
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