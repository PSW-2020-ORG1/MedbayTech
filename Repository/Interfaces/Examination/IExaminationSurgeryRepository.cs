// File:    IExaminationSurgeryRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:08:24 AM
// Purpose: Definition of Interface IExaminationSurgeryRepository

using Model.ExaminationSurgery;
using Model.MedicalRecord;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository.ExaminationRepository
{
   public interface IExaminationSurgeryRepository : IRepository<ExaminationSurgery,int>
   {
      IEnumerable<ExaminationSurgery> GetAllByDoctor(Doctor doctor);
      
      IEnumerable<ExaminationSurgery> GetAllByRecord(MedicalRecord record);
   
   }
}