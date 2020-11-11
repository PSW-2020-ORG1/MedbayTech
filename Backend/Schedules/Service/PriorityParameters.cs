// File:    PriorityParameters.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 1:09:09 AM
// Purpose: Definition of Class PriorityParameters

using Model.Users;
using System;

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

        public Doctor ChosenDoctor { get => chosenDoctor; set => chosenDoctor = value; }
        public DateTime ChosenStartDate { get => chosenStartDate; set => chosenStartDate = value; }
        public DateTime ChosenEndDate { get => chosenEndDate; set => chosenEndDate = value; }
        public PriorityType Priority { get => priority; set => priority = value; }
    }
}