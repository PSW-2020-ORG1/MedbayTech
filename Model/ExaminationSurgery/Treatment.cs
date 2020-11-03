// File:    Treatment.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 10:32:27 PM
// Purpose: Definition of Class Treatment

using System;
using SimsProjekat.Repository;

namespace Model.ExaminationSurgery
{
   public class Treatment : IIdentifiable<int>
   {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string AdditionalNotes { get; set; }
        public TreatmentType Type { get; set; }

        public Treatment() { }

        public Treatment(int id)
        {
            Id = id;
        }

        public Treatment(DateTime date, String additionalNotes, TreatmentType type)
        {
            Date = date.Date;
            AdditionalNotes = additionalNotes;
            Type = type;
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