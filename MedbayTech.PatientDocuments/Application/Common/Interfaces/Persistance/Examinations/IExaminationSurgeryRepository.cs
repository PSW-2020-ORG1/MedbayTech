// File:    IExaminationSurgeryRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:08:24 AM
// Purpose: Definition of Interface IExaminationSurgeryRepository

using System.Collections.Generic;
using Repository;
using MedbayTech.Common.Repository;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;

namespace Backend.Examinations.Repository
{
    public interface IExaminationSurgeryRepository : IRepository<ExaminationSurgery,int>
   {
          List<ExaminationSurgery> GetAllBy(string doctorId);

          List<ExaminationSurgery> GetAllBy(MedicalRecord record);
          ExaminationSurgery UpdateTreatment(ExaminationSurgery examinationSurgery, Treatment treatment);
          List<ExaminationSurgery> GetReportFor(string idPatient);
    }
}