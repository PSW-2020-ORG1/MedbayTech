using MedbayTech.Common.Domain.Entities;
using MedbayTech.Pharmacies.Application.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedbayTech.Pharmacies.Domain.Entities.Tenders
{
    public class TenderMedication : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Tender")]
        public int TenderID { get; set; }

        [ForeignKey("Medication")]
        public int MedicationId { get; set; }

        public int TenderMedicationQuantity { get; set; }

        public TenderMedication(int id, int medicationId, int tenderID, int tenderMedicationQuantity)
        {
            Id = id;
            MedicationId = medicationId;
            TenderID = tenderID;
            TenderMedicationQuantity = tenderMedicationQuantity;
        }

        public TenderMedication(TenderMedicationDTO tenderMedicationDTO, int tenderId)
        {
            MedicationId = tenderMedicationDTO.MedicationId;
            TenderID = tenderId;
            TenderMedicationQuantity = tenderMedicationDTO.MedicationQuantity;
        }

        public TenderMedication()
        {
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
