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
        private int id;
        private DateTime date;
        private string additionalNotes;
        private TreatmentType type;

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

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string AdditionalNotes { get => additionalNotes; set => additionalNotes = value; }
        public TreatmentType Type { get => type; set => type = value; }

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