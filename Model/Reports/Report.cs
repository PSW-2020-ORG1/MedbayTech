// File:    Report.cs
// Author:  Vlajkov
// Created: Thursday, May 28, 2020 8:35:09 PM
// Purpose: Definition of Class Report

using System;
using SimsProjekat.Repository;

namespace Model.Reports
{
   public abstract class Report : IIdentifiable<int>
   {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int Id { get; set; }

        public Report() { }

        public Report(int id)
        {
            Id = id;
        }

        public Report(DateTime date, string content)
        {
            Date = date;
            Content = content;
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