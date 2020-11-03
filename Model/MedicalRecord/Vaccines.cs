// File:    Vaccines.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 7:47:44 PM
// Purpose: Definition of Class Vaccines

using System;

namespace Model.MedicalRecord
{
   public class Vaccines
   {
        private int id;
        private string name;

        public Vaccines() {}
        public Vaccines(string name)
        {
            Name = name;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}