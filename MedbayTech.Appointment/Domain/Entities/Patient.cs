// File:    Patient.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:25:23 PM
// Purpose: Definition of Class Patient

using Domain.Enums;
using Domain.ValueObject;
using MedbayTech.Repository.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
   public class Patient : IIdentifiable<string>
   {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [ForeignKey("ChosenDoctor")]
        public string ChosenDoctorId { get;  set; }
        public virtual Doctor ChosenDoctor { get; set; }
        public bool Blocked { get; set; }
        public bool ShouldBeBlocked { get; set; }

        public Patient(string id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
            ChosenDoctor = null;
            Blocked = false;
            ShouldBeBlocked = false;
        }

        public Patient() { }

        public string GetId() => Id;
    }
}