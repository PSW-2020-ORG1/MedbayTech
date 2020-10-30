// File:    Vaccines.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 7:47:44 PM
// Purpose: Definition of Class Vaccines

using System;

namespace Model.MedicalRecord
{
   public class Vaccines
   {
        private string name;

        public Vaccines(string name)
        {
            Name = name;
        }
        public string Name { get => name; set => name = value; }
    }
}