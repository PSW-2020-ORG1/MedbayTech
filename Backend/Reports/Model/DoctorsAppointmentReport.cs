// File:    DoctorsAppointmentReport.cs
// Author:  Vlajkov
// Created: Thursday, May 28, 2020 9:18:28 PM
// Purpose: Definition of Class DoctorsAppointmentReport

using System;
using Backend.Examinations.Model;

namespace Model.Reports
{
   public class DoctorsAppointmentReport : Report
   {
        public int ExaminationSurgeryId { get; set; }
        public virtual Backend.Examinations.Model.ExaminationSurgery ExaminationSurgery { get; set; }

        public DoctorsAppointmentReport(Backend.Examinations.Model.ExaminationSurgery examinationSurgery, DateTime date) : base(date, "")
        {
            ExaminationSurgery = examinationSurgery;
        }

       
    }
}