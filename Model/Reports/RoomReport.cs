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
        private DateTime startDate;
        private DateTime endDate;
        private int floor;
        private RoomType roomType;

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

        public RoomType RoomType { get => roomType; set => roomType = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public int Floor { get => floor; set => floor = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
    }
}