using Backend.Examinations.Model;
using Backend.Utils.DTO;
using System;
using System.Collections.Generic;
using WebApplication.DTO;

namespace Backend.Examinations.Service.Interfaces
{
    public interface IPrescriptionSearchService
    {
        List<Prescription> GetSearchedPrescription(string medicationName, int hourlyIntake, DateTime startDate, DateTime endDate);
        List<Prescription> AdvancedSearchPrescriptions(PrescriptionAdvancedDTO dto);
        List<Prescription> SearchByParameters(List<Prescription> prescriptions, PrescriptionAdvancedDTO dto, List<Prescription> firstPrescriptions);
        List<Prescription> SearchByLogicOperators(string logicOperator, List<Prescription> otherPrescriptions, List<Prescription> finalPrescriptions);
        List<Prescription> SearchByOtherParameters(string otherParameterType, string otherParameterValue, List<Prescription> prescriptions);
        List<Prescription> SearchByFirstParameter(List<Prescription> prescriptions, PrescriptionAdvancedDTO dto);
        List<Prescription> AdvancedSearch(string medication, List<Prescription> prescriptions);
        List<Prescription> AdvancedSearch(int hourlyIntake, List<Prescription> prescriptions);
        List<PrescriptionForSendingDTO> GetAll();
        string GeneratePrescription(PrescriptionForSendingDTO prescription);
    }
}
