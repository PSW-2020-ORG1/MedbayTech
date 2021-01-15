using Backend.Examinations.Service.Interfaces;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Examinations;
using MedbayTech.PatientDocuments.Application.DTO.Report;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.PatientDocuments.Infrastructure.Service
{
    public class ReportSearchService : IReportSearchService
    {
        private readonly IReportRepository _repository;
        private readonly IUserGateway _userGateway;
        public ReportSearchService(IReportRepository repository, IUserGateway userGateway)
        {
            _repository = repository;
            _userGateway = userGateway;
        }

        public List<Report> GetSearchedReports(string name, DateTime startDate, DateTime endDate, string type)
        {
            List<Report> reports = GetAll();
            List<Report> iterationList = new List<Report>(reports);

            foreach (Report report in iterationList)
            {
                if (!(report.Doctor.Name.Trim().ToLower().Equals(name.Trim().ToLower())) && !name.Trim().Equals(""))
                {
                    reports.Remove(report);
                }
                if (!report.Type.ToString().ToLower().Trim().Equals(type.ToLower().Trim()) && !type.Trim().Equals(""))
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
        public List<Report> AdvancedSearchReports(ReportAdvancedDTO dto)
        {
            return SearchByParameters(GetReportsFor("2406978890046"), dto, SearchFByFirstParameter(GetReportsFor("2406978890046"), dto));
        }

        /// <summary>
        /// Method concatenates report search results, when one parameter is given and when multiple are, with logical operators
        /// </summary>
        /// <param name="reports"></param>
        /// <param name="dto"></param>
        /// <param name="firstReports"></param>
        /// <returns>Concatenated list of filtered reports</returns>
        public List<Report> SearchByParameters(List<Report> reports, ReportAdvancedDTO dto, List<Report> firstReports)
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
        public List<Report> SearchByLogicOperators(string logicOperator, List<Report> otherReports, List<Report> finalReports)
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
        public List<Report> SearchByOtherParameters(string otherParameterType, string otherParameterValue, List<Report> reports)
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
        public List<Report> SearchFByFirstParameter(List<Report> reports, ReportAdvancedDTO dto)
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
        public List<Report> AdvancedSearchDoctorName(string docName, List<Report> reports)
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
        public List<Report> AdvancedSearchDoctorSurname(string docSurname, List<Report> reports)
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
        public List<Report> AdvancedSearchDate(string date, List<Report> reports)
        {
            if (!date.Equals(""))
            {
                reports = reports.Where(report => report.StartTime == DateTime.Parse(date)).ToList();
            }
            return reports;
        }

        public List<Report> GetReportsFor(string id)
        {
            var reports = _repository.GetReportFor(id);
            foreach (Report report in reports)
            {
                report.MedicalRecord.Patient = _userGateway.GetPatientBy(report.MedicalRecord.PatientId);
                report.Doctor = _userGateway.GetDoctorBy(report.DoctorId);
            }
            return reports;
        } 

        public List<Report> GetAll()
        {
            var reports = _repository.GetAll().ToList();
            foreach (Report report in reports)
            {
                report.MedicalRecord.Patient = _userGateway.GetPatientBy(report.MedicalRecord.PatientId);
                report.Doctor = _userGateway.GetDoctorBy(report.DoctorId);
            }
            return reports;
        }

        public Report GetReportForAppointment(DateTime startTime, string doctorId, string patientId) 
        {
            return _repository.GetReportForAppointment(startTime,doctorId,patientId);
        }
    }
}
