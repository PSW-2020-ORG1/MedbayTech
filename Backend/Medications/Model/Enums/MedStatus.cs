// File:    MedStatus.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:29:18 PM
// Purpose: Definition of Class MedStatus

using Model.Users;
using System;

namespace Backend.Medications.Model
{
   public enum MedStatus
   {
      Approved,
      Validation,
      Rejected
   }
}