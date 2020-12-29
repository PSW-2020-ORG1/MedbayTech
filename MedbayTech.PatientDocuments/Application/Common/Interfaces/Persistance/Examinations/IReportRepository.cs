// File:    IExaminationSurgeryRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:08:24 AM
// Purpose: Definition of Interface IExaminationSurgeryRepository

using System.Collections.Generic;
using MedbayTech.Common.Repository;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;

namespace MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Examinations
{
    public interface IReportRepository : IRepository<Report, int>
    {
        List<Report> GetAllBy(string doctorId);
        List<Report> GetAllBy(MedicalRecord record);
        Report UpdateTreatment(Report examinationSurgery, Treatment treatment);
        List<Report> GetReportFor(string idPatient);
    }
}