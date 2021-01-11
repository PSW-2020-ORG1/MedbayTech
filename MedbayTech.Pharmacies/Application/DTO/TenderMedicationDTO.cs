using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Application.DTO
{
    public class TenderMedicationDTO
    {
        public int MedicationId { get; set; }
        public string MedicationName { get; set; }
        public string MedicationDosage { get; set; }
        public int MedicationQuantity { get; set; }

        public TenderMedicationDTO(int medicationId, string medicationName, string medicationDosage, int medicationQuantity)
        {
            MedicationId = medicationId;
            MedicationName = medicationName;
            MedicationDosage = medicationDosage;
            MedicationQuantity = medicationQuantity;
        }
    }
}
