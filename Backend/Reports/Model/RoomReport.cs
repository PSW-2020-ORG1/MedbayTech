// File:    RoomReport.cs
// Author:  Vlajkov
// Created: Monday, May 18, 2020 10:01:57 PM
// Purpose: Definition of Class RoomReport

using Model.Rooms;
using System;

namespace Model.Reports
{
   public class RoomReport : Report
   {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Floor { get; set; }
        public RoomType RoomType { get; set; }

        public RoomReport() { 
        }
        public RoomReport(DateTime date, DateTime startDate, DateTime endDate, 
            int floor, RoomType type, string content) : base(date, content)
        {
            StartDate = startDate;
            EndDate = endDate;
            Floor = floor;
            RoomType = type;
        }

    }
}