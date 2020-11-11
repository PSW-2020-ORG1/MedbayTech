// File:    SpecializationController.cs
// Author:  ThinkPad
// Created: Wednesday, May 20, 2020 2:59:53 AM
// Purpose: Definition of Class SpecializationController

using Model.Users;
using Service.UserService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.UserController
{
   public class SpecializationController
   {
        public SpecializationController(SpecializationService specializationService)
        {
            this.specializationService = specializationService;
        }

        public Specialization GetGeneralSpecialization() => specializationService.GetGeneralSpecialization(); 
        public Specialization AddSpecialization(Specialization specialization) => specializationService.AddSpecialization(specialization);
        public bool DeleteSpecialization(Specialization specialization) => specializationService.DeleteSpecialization(specialization);
        public IEnumerable<Specialization> GetAllSpecializations() => specializationService.GetAllSpecializations();
      
        public SpecializationService specializationService;
     
   }
}