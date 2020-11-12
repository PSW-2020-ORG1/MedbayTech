// File:    ILabTestTypeRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:27:36 AM
// Purpose: Definition of Interface ILabTestTypeRepository

using System;
using Backend.Examinations.Model;
using Repository;

namespace Backend.Examinations.Repository
{
   public interface ILabTestTypeRepository : IGetAll<LabTestType>, ICreate<LabTestType>
   {
   }
}