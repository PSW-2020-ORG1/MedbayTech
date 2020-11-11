// File:    DoctorsAppointmentReport.cs
// Author:  Vlajkov
// Created: Thursday, May 28, 2020 9:18:28 PM
// Purpose: Definition of Class DoctorsAppointmentReport

using System;
using Examinations;

namespace Model.Reports
{
   public class DoctorsAppointmentReport : Report
   {
        public int ExaminationSurgeryId { get; set; }
        public virtual Examinations.ExaminationSurgery ExaminationSurgery { get; set; }

        public DoctorsAppointmentReport(Examinations.ExaminationSurgery examinationSurgery, DateTime date) : base(date, "")
        {
            ExaminationSurgery = examinationSurgery;
        }

       
    }
}