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
        private ExaminationSurgery.ExaminationSurgery examinationSurgery;

        public DoctorsAppointmentReport(ExaminationSurgery.ExaminationSurgery examinationSurgery, DateTime date) : base(date, "")
        {
            ExaminationSurgery = examinationSurgery;
        }

        public ExaminationSurgery.ExaminationSurgery ExaminationSurgery { get => examinationSurgery; set => examinationSurgery = value; }
    }
}