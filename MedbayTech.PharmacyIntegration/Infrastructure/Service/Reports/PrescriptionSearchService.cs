
using MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports;
using MedbayTech.Pharmacies.Application.DTO;
using System.Collections.Generic;
using System.IO;

namespace MedbayTech.Pharmacies.Infrastructure.Service.Reports
{
    public class PrescriptionSearchService : IPrescriptionSearchService
    {
        private readonly IPrescriptionGateway _prescriptionGateway;

        public PrescriptionSearchService(IPrescriptionGateway prescriptionGateway)
        {
            _prescriptionGateway = prescriptionGateway;
        }
        public List<PrescriptionForSendingDTO> GetAll() =>
            _prescriptionGateway.GetAll();
        public string GeneratePrescription(PrescriptionForSendingDTO prescription) 
        {

            char pathBase = Path.DirectorySeparatorChar;
            string fileName = prescription.FileName() + ".txt";
            string filePath = "." + pathBase + "GeneratedPrescription" + pathBase + fileName;
            string stringToWrite = prescription.ToString();
       
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
