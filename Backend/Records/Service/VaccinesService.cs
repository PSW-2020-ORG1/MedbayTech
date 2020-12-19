// File:    VaccinesService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 10:48:36 PM
// Purpose: Definition of Class VaccinesService

using Backend.Records.Model;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;

namespace Service.MedicalRecordService
{
   public class VaccinesService
   {
        public VaccinesService(IVaccinesRepository vaccinesRepository)
        {
            this.vaccinesRepository = vaccinesRepository;
        }

        public List<Vaccines> GetAllVaccines() => 
            vaccinesRepository.GetAll();

        public Vaccines CreateVaccine(Vaccines vaccine) => 
            vaccinesRepository.Create(vaccine);
      
        public IVaccinesRepository vaccinesRepository;
   
   }
}