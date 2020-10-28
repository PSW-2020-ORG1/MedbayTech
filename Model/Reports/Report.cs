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
        private DateTime date;
        private string content;
        private int id;

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

        public DateTime Date { get => date; set => date = value; }
        public string Content { get => content; set => content = value; }
        public int Id { get => id; set => id = value; }

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