using Backend.Examinations.Service.Interfaces;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using System;
using System.Collections.Generic;

namespace MedbayTech.PatientDocuments.Infrastructure.Service
{
    public class PrescriptionSearchService : IPrescriptionSearchService
    {
        public List<Prescription> AdvancedSearch(string medication, List<Prescription> prescriptions)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> AdvancedSearch(int hourlyIntake, List<Prescription> prescriptions)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> GetSearchedPrescription(string medicationName, int hourlyIntake, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> SearchByLogicOperators(string logicOperator, List<Prescription> otherPrescriptions, List<Prescription> finalPrescriptions)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> SearchByOtherParameters(string otherParameterType, string otherParameterValue, List<Prescription> prescriptions)
        {
            throw new NotImplementedException();
        }
    }
}
