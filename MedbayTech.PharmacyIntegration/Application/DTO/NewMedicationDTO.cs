using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Pharmacies.Application.DTO
{
    public class NewMedicationDTO
    {
        public string MedicationName { get; set; }
        public string MedicationDosage { get; set; }

        public NewMedicationDTO(string medicationName, string medicationDosage)
        {
            MedicationName = medicationName;
            MedicationDosage = medicationDosage;
        }
        public NewMedicationDTO()
        {
        }
    }
}
