// File:    Shift.cs
// Author:  Vlajkov
// Created: Sunday, April 12, 2020 12:29:12 AM
// Purpose: Definition of Class Shift

using System;

namespace Model.Users
{
   public class Shift
   {
        private int startHour;
        private int endHour;

        public Shift(int startHour, int endHour)
        {
            StartHour = startHour;
            EndHour = endHour;
        }

        public int StartHour { get => startHour; set => startHour = value; }
        public int EndHour { get => endHour; set => endHour = value; }
    }
}