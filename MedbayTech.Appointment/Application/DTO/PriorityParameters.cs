// File:    PriorityParameters.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 1:09:09 AM
// Purpose: Definition of Class PriorityParameters

using Domain.Enums;
using System;

namespace Application.DTO
{
   public class PriorityParameters
   {
        public string DoctorId { get; set; }
        public DateTime ChosenStartDate { get; set; }
        public DateTime ChosenEndDate { get; set; }
        public PriorityType Priority { get; set; }
        public int SpecializationId { get; set; }

        public PriorityParameters() { }
        public PriorityParameters(string doctorId, DateTime chosenStartDate, DateTime chosenEndDate, PriorityType type, int specializationId)
        {
            DoctorId = doctorId;
            ChosenStartDate = chosenStartDate;
            ChosenEndDate = chosenEndDate;
            Priority = type;
            SpecializationId = specializationId;
        }
   }
}