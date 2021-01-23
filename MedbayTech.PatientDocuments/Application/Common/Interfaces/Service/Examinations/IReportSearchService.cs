using MedbayTech.PatientDocuments.Application.DTO.Report;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Service.Interfaces
{
    public interface IReportSearchService
    {
        List<Report> GetSearchedReports(string name, DateTime startDate, DateTime endDate, string type);
        List<Report> AdvancedSearchReports(ReportAdvancedDTO dto);
        List<Report> SearchByParameters(List<Report> reports, ReportAdvancedDTO dto, List<Report> firstReports);
        List<Report> SearchByLogicOperators(string logicOperator, List<Report> otherReports, List<Report> finalReports);
        List<Report> SearchByOtherParameters(string otherParameterType, string otherParameterValue, List<Report> reports);
        List<Report> SearchFByFirstParameter(List<Report> reports, ReportAdvancedDTO dto);
        List<Report> AdvancedSearchDoctorName(string docName, List<Report> reports);
        List<Report> AdvancedSearchDoctorSurname(string docSurname, List<Report> reports);
        List<Report> AdvancedSearchDate(string date, List<Report> reports);
        List<Report> GetAll();
        List<Report> GetReportsFor(string id);
        Report GetReportForAppointment(DateTime startTime, string doctorId, string patientId);
    }
}
