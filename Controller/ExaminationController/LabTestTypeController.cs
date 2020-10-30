/***********************************************************************
 * Module:  LabTestTypeRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.ExaminationRepository.LabTestTypeRepository
 ***********************************************************************/

using Model.ExaminationSurgery;
using Service.ExaminationService;
using System;
using System.Collections.Generic;

namespace Controller.ExaminationController
{
   public class LabTestTypeController
   {
        public LabTestTypeController(LabTestTypeService labTestTypeService)
        {
            this.labTestTypeService = labTestTypeService;
        }

        public IEnumerable<LabTestType> GetAllTestTypes() => labTestTypeService.GetAllTestTypes();
        public LabTestType CreateLabTestType(LabTestType type) => labTestTypeService.CreateLabTestType(type);
      
        public LabTestTypeService labTestTypeService;
   
   }
}