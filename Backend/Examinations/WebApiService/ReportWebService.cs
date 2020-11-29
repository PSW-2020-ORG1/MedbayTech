using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication.DTO;

namespace Backend.Examinations.WebApiService
{
    public class ReportWebService
    {
        private IExaminationSurgeryRepository reportRepository;

        public ReportWebService(IExaminationSurgeryRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public List<ExaminationSurgery> AdvancedSearchReports(ReportAdvancedDTO dto)
        {

            return SearchByParameters(reportRepository.GetReportFor("2406978890046").ToList(), dto, SearchFByFirstParameter(reportRepository.GetReportFor("2406978890046").ToList(), dto));

        }

        private List<ExaminationSurgery> SearchByParameters(List<ExaminationSurgery> reports, ReportAdvancedDTO dto, List<ExaminationSurgery> firstReports)
        {
            for (int i = 0; i < dto.OtherParameterTypes.Length; i++)
            {
                firstReports = SearchByLogicOperators(dto.LogicOperators[i], SearchByOtherParameters(dto.OtherParameterTypes[i], dto.OtherParameterValues[i], reports), firstReports);
            }
            return firstReports;
        }

        private List<ExaminationSurgery> SearchByLogicOperators(string logicOperator, List<ExaminationSurgery> otherReports, List<ExaminationSurgery> finalReports)
        {
            return logicOperator.Equals("or") ? otherReports.Union(finalReports).ToList() : otherReports.Intersect(finalReports).ToList();
        }

        private List<ExaminationSurgery> SearchByOtherParameters(string otherParameterType, string otherParameterValue, List<ExaminationSurgery> reports)
        {
            return otherParameterType.Equals("docName") ? AdvancedSearchDoctorName(otherParameterValue, reports) :
               otherParameterType.Equals("docSurname") ? AdvancedSearchDoctorSurname(otherParameterValue, reports) :
               AdvancedSearchDate(otherParameterValue, reports);
        }

        private List<ExaminationSurgery> SearchFByFirstParameter(List<ExaminationSurgery> reports, ReportAdvancedDTO dto)
        {
            return dto.FirstParameterType.Equals("docName") ? AdvancedSearchDoctorName(dto.FirstParameterValue, reports) :
                dto.FirstParameterType.Equals("docSurname") ? AdvancedSearchDoctorSurname(dto.FirstParameterValue, reports) :
                AdvancedSearchDate(dto.FirstParameterValue, reports);
                
        }

        public List<ExaminationSurgery> AdvancedSearchDoctorName(string docName, List<ExaminationSurgery> reports)
        {

            if (!docName.Equals(""))
            {
                reports = reports.Where(report => report.Doctor.Name.ToLower().Contains(docName.ToLower())).ToList();
            }
            return reports;
        }

        public List<ExaminationSurgery> AdvancedSearchDoctorSurname(string docSurname, List<ExaminationSurgery> reports)
        {

            if (!docSurname.Equals(""))
            {
                reports = reports.Where(report => report.Doctor.Name.ToLower().Contains(docSurname.ToLower())).ToList();
            }
            return reports;
        }

        public List<ExaminationSurgery> AdvancedSearchDate(string date, List<ExaminationSurgery> reports)
        {

            if (!date.Equals(""))
            {
                reports = reports.Where(report => report.StartTime == DateTime.Parse(date)).ToList();
            }
            return reports;
        }
    }
}
