// File:    ILabTestTypeRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:27:36 AM
// Purpose: Definition of Interface ILabTestTypeRepository

using System;
using Examinations;

namespace Repository.ExaminationRepository
{
   public interface ILabTestTypeRepository : IGetAll<LabTestType>, ICreate<LabTestType>
   {
   }
}