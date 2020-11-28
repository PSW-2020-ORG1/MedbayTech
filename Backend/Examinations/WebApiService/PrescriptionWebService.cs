using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using System;
using System.Collections.Generic;
using WebApplication.DTO;
using System.Linq;
using System.Text;

namespace Backend.Examinations.WebApiService
{
    public class PrescriptionWebService
    {
        private IPrescriptionRepository prescriptionRepository;

        public PrescriptionWebService(IPrescriptionRepository prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
        }

        
        public List<Prescription> AdvancedSearchPrescriptions(PrescriptionAdvancedDTO dto)
        {
            return SearchByParameters(prescriptionRepository.GetPrescriptionsFor("2406978890046").ToList(), dto, SearchByFirstParameter(prescriptionRepository.GetPrescriptionsFor("2406978890046").ToList(), dto));
        }

        public List<Prescription> SearchByParameters(List<Prescription> prescriptions, PrescriptionAdvancedDTO dto, List<Prescription> firstPrescriptions)
        {
            for (int i = 0; i < dto.OtherParameterTypes.Length; i++)
            {
                List<Prescription> otherPrescriptions = SearchByOtherParameters(dto.OtherParameterTypes[i], dto.OtherParameterValues[i], prescriptions);

                firstPrescriptions = SearchByLogicOperators(dto.LogicOperators[i], otherPrescriptions, firstPrescriptions);
            }

            return firstPrescriptions;
        }

        public List<Prescription> SearchByLogicOperators(string logicOperator, List<Prescription> otherPrescriptions, List<Prescription> finalPrescriptions)
        {
            return logicOperator.Equals("or") ? otherPrescriptions.Union(finalPrescriptions).ToList() : otherPrescriptions.Intersect(finalPrescriptions).ToList();
        }

        public List<Prescription> SearchByOtherParameters(string otherParameterType, string otherParameterValue, List<Prescription> prescriptions)
        {
            return otherParameterType.Equals("medicines") ? AdvancedSearch(otherParameterValue, prescriptions) :
                AdvancedSearch(int.Parse(otherParameterValue), prescriptions);
        }       

        public List<Prescription> SearchByFirstParameter(List<Prescription> prescriptions, PrescriptionAdvancedDTO dto)
        {
            return dto.FirstParameterType.Equals("medication") ? AdvancedSearch(dto.FirstParameterValue, prescriptions) :
                AdvancedSearch(int.Parse(dto.FirstParameterValue), prescriptions);
                
        }


        public List<Prescription> AdvancedSearch(string medicine, List<Prescription> prescriptions)
        {

            if (!medicine.Equals(""))
            {
                prescriptions = prescriptions.Where(prescription => prescription.Medication.Med.ToLower().Contains(medicine.ToLower())).ToList();
            }
            return prescriptions;
        }

        public List<Prescription> AdvancedSearch(int hourlyIntake, List<Prescription> prescriptions)
        {

            if (!(hourlyIntake == 0))
            {
                prescriptions = prescriptions.Where(prescription => prescription.HourlyIntake == hourlyIntake).ToList();
            }
            return prescriptions;
        }
    }
}
