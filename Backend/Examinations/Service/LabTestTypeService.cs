/***********************************************************************
 * Module:  LabTestTypeRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.ExaminationRepository.LabTestTypeRepository
 ***********************************************************************/

using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Service
{
   public class LabTestTypeService
   {
        public LabTestTypeService(ILabTestTypeRepository labTestTypeRepository)
        {
            this.labTestTypeRepository = labTestTypeRepository;
        }
        public IEnumerable<LabTestType> GetAllTestTypes() => labTestTypeRepository.GetAll();
        public LabTestType CreateLabTestType(LabTestType type) => labTestTypeRepository.Create(type);

        public ILabTestTypeRepository labTestTypeRepository;
   
   }
}