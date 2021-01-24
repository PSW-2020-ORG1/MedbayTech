using System;
using System.Collections.Generic;

namespace MedbayTech.Tenders.Application.DTO
{
    public class TenderDTO
    {
        public DateTime EndDate { get; set; }
        public List<TenderMedicationDTO> tenderMedications { get; set; }
        public string TenderDescription { get; set; }

        public TenderDTO(DateTime endDate, List<TenderMedicationDTO> tenderMedications, string tenderDescription)
        {
            EndDate = endDate;
            this.tenderMedications = tenderMedications;
            TenderDescription = tenderDescription;
        }

        public TenderDTO()
        {
        }
    }
}
