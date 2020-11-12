// File:    Vaccines.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 7:47:44 PM
// Purpose: Definition of Class Vaccines

using System;

namespace Backend.Records.Model.Enums
{
   public class Vaccines
   {
        public  int Id { get; set; }
        public string Name { get; set; }

        public Vaccines() {}
        public Vaccines(string name)
        {
            Name = name;
        }
     
    }
}