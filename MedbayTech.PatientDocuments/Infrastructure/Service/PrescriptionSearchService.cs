﻿using MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Examinations;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Treatments;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Service.Treatments;
using MedbayTech.PatientDocuments.Application.DTO.Prescription;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.PatientDocuments.Infrastructure.Service
{
    public class PrescriptionSearchService : IPrescriptionSearchService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IUserGateway _userGateway;

        public PrescriptionSearchService(IPrescriptionRepository repository, IUserGateway userGateway)
        {
            _prescriptionRepository = repository;
            _userGateway = userGateway;
        }

        public PrescriptionSearchService(IPrescriptionRepository repository, IReportRepository reportRepository, IUserGateway userGateway)
        {
            _prescriptionRepository = repository;
            _reportRepository = reportRepository;
            _userGateway = userGateway;
        }

        public List<Prescription> GetSearchedPrescription(string medicationName, int hourlyIntake, DateTime startDate, DateTime endDate)
        {
            List<Prescription> prescriptions = GetAll();
            List<Prescription> iterationList = new List<Prescription>(prescriptions);

            foreach (Prescription prescription in iterationList)
            {
                if (prescription.Medication != null && !prescription.Medication.Trim().ToLower().Equals(medicationName.Trim().ToLower()) && !medicationName.Trim().Equals(""))
                {
                    prescriptions.Remove(prescription);
                }

                if (!(prescription.HourlyIntake == hourlyIntake))
                {
                    prescriptions.Remove(prescription);
                }

                if (prescription.Date <= startDate || prescription.Date >= endDate)
                {
                    prescriptions.Remove(prescription);
                }
            }

            return prescriptions;
        }

        /// <summary>
        /// Method for advanced search of prescriptions based on given parameters and logical operators
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>List of filtered prescriptions</returns>
        public List<Prescription> AdvancedSearchPrescriptions(PrescriptionAdvancedDTO dto)
        {
            return SearchByParameters(GetAllFor("2406978890046").ToList(), dto, SearchByFirstParameter(GetAllFor("2406978890046").ToList(), dto));
        }

        /// <summary>
        /// Method concatenates prescription search results, when one parameter is given and when multiple are, with logical operators
        /// </summary>
        /// <param name="prescriptions"></param>
        /// <param name="dto"></param>
        /// <param name="firstPrescriptions"></param>
        /// <returns>Concatenated list of filtered prescriptions</returns>
        public List<Prescription> SearchByParameters(List<Prescription> prescriptions, PrescriptionAdvancedDTO dto, List<Prescription> firstPrescriptions)
        {
            for (int i = 0; i < dto.OtherParameterTypes.Length; i++)
            {
                firstPrescriptions = SearchByLogicOperators(dto.LogicOperators[i], SearchByOtherParameters(dto.OtherParameterTypes[i], dto.OtherParameterValues[i], prescriptions), firstPrescriptions);
            }

            return firstPrescriptions;
        }

        /// <summary>
        /// Method concatenates prescription search results based on the given operator
        /// </summary>
        /// <param name="logicOperator"></param>
        /// <param name="otherPrescriptions"></param>
        /// <param name="finalPrescriptions"></param>
        /// <returns>Concatenated list of filtered prescriptions</returns>
        public List<Prescription> SearchByLogicOperators(string logicOperator, List<Prescription> otherPrescriptions, List<Prescription> finalPrescriptions)
        {
            return logicOperator.Equals("or") ? otherPrescriptions.Union(finalPrescriptions).ToList() : otherPrescriptions.Intersect(finalPrescriptions).ToList();
        }

        /// <summary>
        /// Method for searching prescriptions based on parameters other than first
        /// </summary>
        /// <param name="otherParameterType"></param>
        /// <param name="otherParameterValue"></param>
        /// <param name="prescriptions"></param>
        /// <returns>Filtered list of prescriptions</returns>
        public List<Prescription> SearchByOtherParameters(string otherParameterType, string otherParameterValue, List<Prescription> prescriptions)
        {
            return otherParameterType.Equals("medication") ? AdvancedSearch(otherParameterValue, prescriptions) :
                AdvancedSearch(int.Parse(otherParameterValue), prescriptions);
        }

        /// <summary>
        /// Method for searching prescriptions based on first parameter given
        /// </summary>
        /// <param name="prescriptions"></param>
        /// <param name="dto"></param>
        /// <returns>Filtered list of prescriptions</returns>
        public List<Prescription> SearchByFirstParameter(List<Prescription> prescriptions, PrescriptionAdvancedDTO dto)
        {
            return dto.FirstParameterType.Equals("medication") ? AdvancedSearch(dto.FirstParameterValue, prescriptions) :
                AdvancedSearch(int.Parse(dto.FirstParameterValue), prescriptions);

        }

        /// <summary>
        /// Method for searching prescription based on medication name
        /// </summary>
        /// <param name="medicine"></param>
        /// <param name="prescriptions"></param>
        /// <returns>List of prescriptions with a given medication name</returns>
        public List<Prescription> AdvancedSearch(string medication, List<Prescription> prescriptions)
        {

            if (!medication.Equals(""))
            {
                prescriptions = prescriptions.Where(prescription => prescription.Medication.ToLower().Contains(medication.ToLower())).ToList();
            }
            return prescriptions;
        }

        /// <summary>
        /// Method for searching prescription based on hourly intake
        /// </summary>
        /// <param name="hourlyIntake"></param>
        /// <param name="prescriptions"></param>
        /// <returns>List of prescriptions with given hourly intake</returns>
        public List<Prescription> AdvancedSearch(int hourlyIntake, List<Prescription> prescriptions)
        {

            if (!(hourlyIntake == 0))
            {
                prescriptions = prescriptions.Where(prescription => prescription.HourlyIntake == hourlyIntake).ToList();
            }
            return prescriptions;
        }

        public List<PrescriptionForSendingDTO> GetAllForSending()
        {
            List<Prescription> prescriptions = GetAll();
            List<PrescriptionForSendingDTO> prescriptionsDTO = new List<PrescriptionForSendingDTO>();
            foreach (Prescription prescription in prescriptions)
            {
                prescriptionsDTO.Add(new PrescriptionForSendingDTO(prescription));
            }
            return prescriptionsDTO;
        }

        public List<Prescription> GetAllFor(string patientId)
        {
            var prescriptions = _prescriptionRepository.GetPrescriptionsFor(patientId).ToList();
            foreach (Prescription prescription in prescriptions)
            {
                prescription.Report.MedicalRecord.Patient = _userGateway.GetPatientBy(prescription.Report.MedicalRecord.PatientId);
                prescription.Report.Doctor = _userGateway.GetDoctorBy(prescription.Report.DoctorId);
            }
            return prescriptions;

        }
        public List<Prescription> GetAll()
        {
            var prescriptions = _prescriptionRepository.GetAll().ToList();
            foreach (Prescription prescription in prescriptions)
            {
                prescription.Report.MedicalRecord.Patient = _userGateway.GetPatientBy(prescription.Report.MedicalRecord.PatientId);
                prescription.Report.Doctor = _userGateway.GetDoctorBy(prescription.Report.DoctorId);
            }
            return prescriptions;
        }

        public List<Prescription> GetPrescriptionsBy(string doctorId, string patientId, DateTime startDate)
        {
            Report report = _reportRepository.GetReportForAppointment(startDate, doctorId, patientId);
            return _prescriptionRepository.GetPrescriptionsForReport(report.Id);
        }
    }
}
