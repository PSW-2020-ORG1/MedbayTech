using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Application.DTO
{
    public class TenderDTO
    {
        public DateTime EndDate { get; set; }
        public List<TenderMedicationDTO> tenderMedications { get; set; }

        public TenderDTO(DateTime endDate, List<TenderMedicationDTO> tenderMedications)
        {
            EndDate = endDate;
            this.tenderMedications = tenderMedications;
        }
    }
}
