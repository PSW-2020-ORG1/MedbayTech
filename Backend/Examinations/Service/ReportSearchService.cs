using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using Backend.Examinations.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DTO;

namespace Backend.Examinations.WebApiService
{
    public class ReportSearchService : IReportSearchService
    {
        private IExaminationSurgeryRepository repository;

        public ReportSearchService(IExaminationSurgeryRepository repository)
        {
            this.repository = repository;
        }

        public List<ExaminationSurgery> GetSearchedReports(string name, DateTime startDate, DateTime endDate, string type)
        {
            List<ExaminationSurgery> reports = repository.GetAll().ToList();
            List<ExaminationSurgery> iterationList = new List<ExaminationSurgery>(reports);

            foreach (ExaminationSurgery report in iterationList)
            {
                if (!report.Doctor.Name.ToLower().Equals(name.ToLower()) && !name.Equals(""))
                {
                    reports.Remove(report);
                }

                if (!report.Type.ToString().ToLower().Equals(type.ToLower()) && !type.Equals(""))
                {
                    reports.Remove(report);
                }

                if (report.StartTime <= startDate || report.StartTime >= endDate) 
                {
                    reports.Remove(report);
                }  
                
            }

            return reports;
        }

        /// <summary>
        /// Method for advanced search of reports based on given parameters and logical operators
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>List of filtered reports</returns>
        public List<ExaminationSurgery> AdvancedSearchReports(ReportAdvancedDTO dto)
        {
            return SearchByParameters(repository.GetReportFor("2406978890046"), dto, SearchFByFirstParameter(repository.GetReportFor("2406978890046"), dto));
        }

        /// <summary>
        /// Method concatenates report search results, when one parameter is given and when multiple are, with logical operators
        /// </summary>
        /// <param name="reports"></param>
        /// <param name="dto"></param>
        /// <param name="firstReports"></param>
        /// <returns>Concatenated list of filtered reports</returns>
        public List<ExaminationSurgery> SearchByParameters(List<ExaminationSurgery> reports, ReportAdvancedDTO dto, List<ExaminationSurgery> firstReports)
        {
            for (int i = 0; i < dto.OtherParameterTypes.Length; i++)
            {
                firstReports = SearchByLogicOperators(dto.LogicOperators[i], SearchByOtherParameters(dto.OtherParameterTypes[i], dto.OtherParameterValues[i], reports), firstReports);
            }
            return firstReports;
        }

        /// <summary>
        /// Method concatenates report search results based on the given operator
        /// </summary>
        /// <param name="logicOperator"></param>
        /// <param name="otherReports"></param>
        /// <param name="finalReports"></param>
        /// <returns>Concatenated list of filtered reports</returns>
        public List<ExaminationSurgery> SearchByLogicOperators(string logicOperator, List<ExaminationSurgery> otherReports, List<ExaminationSurgery> finalReports)
        {
            return logicOperator.Equals("or") ? otherReports.Union(finalReports).ToList() : otherReports.Intersect(finalReports).ToList();
        }

        /// <summary>
        /// Method for searching reports based on parameters other than first
        /// </summary>
        /// <param name="otherParameterType"></param>
        /// <param name="otherParameterValue"></param>
        /// <param name="reports"></param>
        /// <returns>Filtered list of reports</returns>
        public List<ExaminationSurgery> SearchByOtherParameters(string otherParameterType, string otherParameterValue, List<ExaminationSurgery> reports)
        {
            return otherParameterType.Equals("docName") ? AdvancedSearchDoctorName(otherParameterValue, reports) :
               otherParameterType.Equals("docSurname") ? AdvancedSearchDoctorSurname(otherParameterValue, reports) :
               AdvancedSearchDate(otherParameterValue, reports);
        }

        /// <summary>
        /// Method for searching reports based on first parameter given
        /// </summary>
        /// <param name="reports"></param>
        /// <param name="dto"></param>
        /// <returns>Filtered list of reports</returns>
        public List<ExaminationSurgery> SearchFByFirstParameter(List<ExaminationSurgery> reports, ReportAdvancedDTO dto)
        {
            return dto.FirstParameterType.Equals("docName") ? AdvancedSearchDoctorName(dto.FirstParameterValue, reports) :
                dto.FirstParameterType.Equals("docSurname") ? AdvancedSearchDoctorSurname(dto.FirstParameterValue, reports) :
                AdvancedSearchDate(dto.FirstParameterValue, reports);
        }

        /// <summary>
        /// Method for searching reports based on doctor name
        /// </summary>
        /// <param name="docName"></param>
        /// <param name="reports"></param>
        /// <returns>List of reports with a given doctor name</returns>
        public List<ExaminationSurgery> AdvancedSearchDoctorName(string docName, List<ExaminationSurgery> reports)
        {
            if (!docName.Equals(""))
            {
                reports = reports.Where(report => report.Doctor.Name.ToLower().Contains(docName.ToLower())).ToList();
            }
            return reports;
        }

        /// <summary>
        /// Method for searching reports based on doctor surname
        /// </summary>
        /// <param name="docSurname"></param>
        /// <param name="reports"></param>
        /// <returns>List of reports with a given doctor surname</returns>
        public List<ExaminationSurgery> AdvancedSearchDoctorSurname(string docSurname, List<ExaminationSurgery> reports)
        {
            if (!docSurname.Equals(""))
            {
                reports = reports.Where(report => report.Doctor.Surname.ToLower().Contains(docSurname.ToLower())).ToList();
            }
            return reports;
        }

        /// <summary>
        /// Method for searching reports based on a date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="reports"></param>
        /// <returns>List of reports with a given date</returns>
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
