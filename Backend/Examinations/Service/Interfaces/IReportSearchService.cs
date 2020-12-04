using Backend.Examinations.Model;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.DTO;

namespace Backend.Examinations.Service.Interfaces
{
    public interface IReportSearchService
    {
        List<ExaminationSurgery> GetSearchedReports(string name, DateTime startDate, DateTime endDate, string type);
        List<ExaminationSurgery> AdvancedSearchReports(ReportAdvancedDTO dto);
        List<ExaminationSurgery> SearchByParameters(List<ExaminationSurgery> reports, ReportAdvancedDTO dto, List<ExaminationSurgery> firstReports);
        List<ExaminationSurgery> SearchByLogicOperators(string logicOperator, List<ExaminationSurgery> otherReports, List<ExaminationSurgery> finalReports);
        List<ExaminationSurgery> SearchByOtherParameters(string otherParameterType, string otherParameterValue, List<ExaminationSurgery> reports);
        List<ExaminationSurgery> SearchFByFirstParameter(List<ExaminationSurgery> reports, ReportAdvancedDTO dto);
        List<ExaminationSurgery> AdvancedSearchDoctorName(string docName, List<ExaminationSurgery> reports);
        List<ExaminationSurgery> AdvancedSearchDoctorSurname(string docSurname, List<ExaminationSurgery> reports);
        List<ExaminationSurgery> AdvancedSearchDate(string date, List<ExaminationSurgery> reports);
    }
}
