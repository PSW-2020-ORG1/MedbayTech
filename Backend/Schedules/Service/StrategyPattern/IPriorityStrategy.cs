// File:    IPriorityStrategy.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 1:09:09 AM
// Purpose: Definition of Interface IPriorityStrategy

using System;
using System.Collections.Generic;
using Model.Schedule;

namespace Service.ScheduleService
{
   public interface IPriorityStrategy
   {
      List<Appointment> Recommend(PriorityParameters parameters);
   
   }
}