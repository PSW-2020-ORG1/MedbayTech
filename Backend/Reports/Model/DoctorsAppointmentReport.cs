// File:    DoctorsAppointmentReport.cs
// Author:  Vlajkov
// Created: Thursday, May 28, 2020 9:18:28 PM
// Purpose: Definition of Class DoctorsAppointmentReport

using System;
using Model.ExaminationSurgery;

namespace Model.Reports
{
   public class DoctorsAppointmentReport : Report
   {
        public int ExaminationSurgeryId { get; set; }
        public virtual ExaminationSurgery.ExaminationSurgery ExaminationSurgery { get; set; }

        public DoctorsAppointmentReport(ExaminationSurgery.ExaminationSurgery examinationSurgery, DateTime date) : base(date, "")
        {
            ExaminationSurgery = examinationSurgery;
        }

       
    }
}