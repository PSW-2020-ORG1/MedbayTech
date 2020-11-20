// File:    PriorityParameters.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 1:09:09 AM
// Purpose: Definition of Class PriorityParameters

using Model.Users;
using System;
using Backend.Utils;

namespace Service.ScheduleService
{
   public class PriorityParameters
   {
        private Doctor chosenDoctor;
        private DateTime chosenStartDate;
        private DateTime chosenEndDate;
        private PriorityType priority;

        public PriorityParameters() { }
        public PriorityParameters(Doctor chosenDoctor, DateTime chosenStartDate, DateTime chosenEndDate, PriorityType type)
        {
            ChosenDoctor = chosenDoctor;
            ChosenStartDate = chosenStartDate;
            ChosenEndDate = chosenEndDate;
            Priority = type;
        }

        public Period SetStartTime(int startWorkingHours, int endWorkingHours)
        {
            Period retVal = new Period();
            
            if (ChosenStartDate.Date.CompareTo(DateTime.Today.Date) <= 0)
                 retVal.StartTime = new DateTime(DateTime.Today.AddDays(1).Year, DateTime.Today.AddDays(1).Month, DateTime.Today.AddDays(1).Day, startWorkingHours, 0, 0);
            else
                retVal.StartTime = new DateTime(ChosenStartDate.Year, ChosenStartDate.Month, ChosenStartDate.Day, startWorkingHours, 0, 0);
            retVal.EndTime = new DateTime(ChosenEndDate.Year, ChosenEndDate.Month, ChosenEndDate.Day, endWorkingHours, 0, 0);
            return retVal;
        }

        public Doctor ChosenDoctor { get => chosenDoctor; set => chosenDoctor = value; }
        public DateTime ChosenStartDate { get => chosenStartDate; set => chosenStartDate = value; }
        public DateTime ChosenEndDate { get => chosenEndDate; set => chosenEndDate = value; }
        public PriorityType Priority { get => priority; set => priority = value; }
    }
}