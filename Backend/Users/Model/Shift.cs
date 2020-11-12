// File:    Shift.cs
// Author:  Vlajkov
// Created: Sunday, April 12, 2020 12:29:12 AM
// Purpose: Definition of Class Shift

using System;

namespace Model.Users
{
   public class Shift
   {
        public int StartHour { get; protected set; }
        public int EndHour { get; protected set; }

        public Shift() { }
        public Shift(int startHour, int endHour)
        {
            StartHour = startHour;
            EndHour = endHour;
        }

    }
}