using MedbayTech.PatientDocuments.Application.DTO.Report;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Application.Mapper.Report
{
    public class ReportMapper
    {
        public static List<ReportDTO> ListExaminationSurgeryToReport(List<Domain.Entities.Examinations.Report> examinationSurgeries)
        {
            List<ReportDTO> reports = new List<ReportDTO>();

            foreach (Domain.Entities.Examinations.Report es in examinationSurgeries)
            {
                String name = es.Doctor.Name + " " + es.Doctor.Surname;
                DateTime date = es.StartTime;
                String type = es.Type.ToString();

                reports.Add(new ReportDTO(name, date, type));
            }

            return reports;
        }
        public static AppointmentReportDTO ReportToAppointmentReportDTO(Domain.Entities.Examinations.Report report)
        {
            DateTime startTime = report.StartTime;
            String type = report.Type.ToString();
            List<DiagnosisDTO> diagnoses = new List<DiagnosisDTO>();
            foreach (Diagnosis diagnosis in report.Diagnoses) 
            {
                DiagnosisDTO diagnos = DiagnosisMapper.DiagnosisToDiagnosisDTO(diagnosis);
                diagnoses.Add(diagnos);
            }
            String doctorName = report.Doctor.Name;
            String doctorSurname = report.Doctor.Surname;
            return new AppointmentReportDTO(startTime, type, diagnoses, doctorName, doctorSurname);

        }
    }
}
