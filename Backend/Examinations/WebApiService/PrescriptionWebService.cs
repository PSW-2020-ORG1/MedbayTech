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

        /// <summary>
        /// Method for advanced search of prescriptions based on given parameters and logical operators
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>List of filtered prescriptions</returns>
        public List<Prescription> AdvancedSearchPrescriptions(PrescriptionAdvancedDTO dto)
        {
            return SearchByParameters(prescriptionRepository.GetPrescriptionsFor("2406978890046").ToList(), dto, SearchByFirstParameter(prescriptionRepository.GetPrescriptionsFor("2406978890046").ToList(), dto));
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
                prescriptions = prescriptions.Where(prescription => prescription.Medication.Med.ToLower().Contains(medication.ToLower())).ToList();
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
    }
}
