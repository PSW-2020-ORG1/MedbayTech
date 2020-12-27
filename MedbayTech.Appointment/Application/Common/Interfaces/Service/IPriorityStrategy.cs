// File:    IPriorityStrategy.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 1:09:09 AM
// Purpose: Definition of Interface IPriorityStrategy

using Application.DTO;
using Domain.Entities;
using MedbayTech.Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
namespace Application.Common.Interfaces
{
   public interface IPriorityStrategy
   {
      List<Appointment> Recommend(PriorityParameters parameters);
   
   }
}