// File:    ISymptomsRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:37 AM
// Purpose: Definition of Interface ISymptomsRepository

using Backend.Records.Model;
using System;
using Repository;

namespace Backend.Medications.Repository.FileRepository
{
   public interface ISymptomsRepository : ICreate<Symptoms>, IGetAll<Symptoms>
   {
   }
}