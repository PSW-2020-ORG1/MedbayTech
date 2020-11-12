// File:    Vaccines.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 7:47:44 PM
// Purpose: Definition of Class Vaccines

using System;
using System.ComponentModel.DataAnnotations;
using SimsProjekat.Repository;

namespace Backend.Records.Model
{
   public class Vaccines : IIdentifiable<int>
   {
        [Key]
        public  int Id { get; set; }
        public string Name { get; set; }

        public Vaccines() {}
        public Vaccines(string name)
        {
            Name = name;
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