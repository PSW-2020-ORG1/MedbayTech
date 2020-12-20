// File:    IExaminationSurgeryRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:08:24 AM
// Purpose: Definition of Interface IExaminationSurgeryRepository

using Backend.Examinations.Model;
using Model.Users;
using System.Collections.Generic;
using Repository;
using Backend.Records.Model;

namespace Backend.Examinations.Repository
{
   public interface IExaminationSurgeryRepository : IRepository<ExaminationSurgery,int>
   {
          List<ExaminationSurgery> GetAllBy(Doctor doctor);

          List<ExaminationSurgery> GetAllBy(MedicalRecord record);
          ExaminationSurgery UpdateTreatment(ExaminationSurgery examinationSurgery, Treatment treatment);
          List<ExaminationSurgery> GetReportFor(string idPatient);
    }
}