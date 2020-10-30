// File:    SpecializationService.cs
// Author:  Vlajkov
// Created: Thursday, May 14, 2020 2:57:05 AM
// Purpose: Definition of Class SpecializationService

using Model.Users;
using Repository.UserRepository;
using System;
using System.Collections.Generic;

namespace Service.UserService
{
   public class SpecializationService
   {
        public SpecializationService(ISpecializationRepository specializationRepository)
        {
            this.specializationRepository = specializationRepository;
        }

        public Specialization AddSpecialization(Specialization specialization) => specializationRepository.Create(specialization);

        public Specialization GetGeneralSpecialization() => specializationRepository.GetGeneralSpecialization();

        public bool DeleteSpecialization(Specialization specialization) => specializationRepository.Delete(specialization);
        public IEnumerable<Specialization> GetAllSpecializations() => specializationRepository.GetAll();
      
        public ISpecializationRepository specializationRepository;
     
   }
}