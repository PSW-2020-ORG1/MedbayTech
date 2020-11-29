// File:    IExaminationSurgeryRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:08:24 AM
// Purpose: Definition of Interface IExaminationSurgeryRepository

using Backend.Examinations.Model;
using Backend.Records.Model.Enums;
using Model.Users;
using System;
using System.Collections.Generic;
using Repository;
using Backend.Records.Model;

namespace Backend.Examinations.Repository
{
   public interface IExaminationSurgeryRepository : IRepository<ExaminationSurgery,int>
   {
          IEnumerable<ExaminationSurgery> GetAllBy(Doctor doctor);
      
          IEnumerable<ExaminationSurgery> GetAllBy(MedicalRecord record);
          ExaminationSurgery UpdateTreatment(ExaminationSurgery examinationSurgery, Treatment treatment);
          IEnumerable<ExaminationSurgery> GetReportFor(string idPatient);
    }
}