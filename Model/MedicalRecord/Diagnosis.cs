// File:    Diagnosis.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:52:17 PM
// Purpose: Definition of Class Diagnosis

using System;
using System.Collections.Generic;
using SimsProjekat.Repository;

namespace Model.MedicalRecord
{
   public class Diagnosis : IIdentifiable<int>
   {
        private string name;
        private int code;
        private List<Symptoms> symptoms;

        public Diagnosis() 
        {
            Symptoms = new List<Symptoms>();
        }

        public Diagnosis(int code) 
        {
            Code = code;
        }

        public Diagnosis(string name, int code, List<Symptoms> symptoms)
        {
            Name = name;
            Code = code;
            Symptoms = symptoms;
        }

        public string Name { get => name; set => name = value; }
        public int Code { get => code; set => code = value; }
        public List<Symptoms> Symptoms { get => symptoms; set => symptoms = value; }

        public int GetId()
        {
            return Code;
        }

        public void SetId(int id)
        {
            Code = id;
        }
    }
}