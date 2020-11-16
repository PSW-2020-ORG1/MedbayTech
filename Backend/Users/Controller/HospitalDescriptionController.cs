// File:    HospitalDescriptionController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 3:03:34 AM
// Purpose: Definition of Class HospitalDescriptionController

using Model.Users;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.GeneralController
{
   public class HospitalController
   {
        public HospitalController(HospitalService hospitalService)
        {
            this.hospitalService = hospitalService; 
        }

        public Hospital GetHospital(int id) => hospitalService.GetHospital(id);
        public IEnumerable<Hospital> GetAllHospitals() => hospitalService.GetAllHospitals();

        public HospitalService hospitalService;
   
   }
}