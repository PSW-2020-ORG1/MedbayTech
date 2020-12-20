using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using Backend.Examinations.Service.Interfaces;
using Backend.Utils.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebApplication.DTO;

namespace Backend.Examinations.WebApiService
{
    public class PrescriptionSearchService : IPrescriptionSearchService
    {
        private IPrescriptionRepository repository;

        public PrescriptionSearchService(IPrescriptionRepository repository)
        {
            this.repository = repository;
        }

        public List<Prescription> GetSearchedPrescription(string medicationName, int hourlyIntake, DateTime startDate, DateTime endDate)
        {
            List<Prescription> prescriptions = repository.GetAll().ToList();
            List<Prescription> iterationList = new List<Prescription>(prescriptions);

            foreach(Prescription prescription in iterationList)
            {
                if (!prescription.Medication.Med.ToLower().Equals(medicationName.ToLower()) && !medicationName.Equals("")) {
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
            return SearchByParameters(repository.GetPrescriptionsFor("2406978890046").ToList(), dto, SearchByFirstParameter(repository.GetPrescriptionsFor("2406978890046").ToList(), dto));
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

        public List<PrescriptionForSendingDTO> GetAll()
        {
            List<Prescription> prescriptions = repository.GetAll().ToList();
            List<PrescriptionForSendingDTO> prescriptionsDTO = new List<PrescriptionForSendingDTO>();
            foreach(Prescription prescription in prescriptions)
            {
                prescriptionsDTO.Add(new PrescriptionForSendingDTO(prescription));
            }
            return prescriptionsDTO;
        }

        public string GeneratePrescription(PrescriptionForSendingDTO prescription)
        {
            char pathBase = Path.DirectorySeparatorChar;
            string fileName = prescription.FileName() + ".txt";
            string filePath = "." + pathBase + "GeneratedPrescription" + pathBase + fileName;
            string stringToWrite = prescription.ToString();
            Console.WriteLine(stringToWrite);
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                string[] split = stringToWrite.Split("\n");
                foreach (string line in split)
                {
                    streamWriter.WriteLine(line);
                }
            }
            return filePath;
        }
    }
}
