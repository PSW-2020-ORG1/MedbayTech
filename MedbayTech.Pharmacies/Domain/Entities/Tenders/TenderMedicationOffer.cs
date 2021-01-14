using MedbayTech.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedbayTech.Pharmacies.Domain.Entities.Tenders
{
    public class TenderMedicationOffer : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("TenderOffer")]
        public int TenderOfferId { get; set; }

        [ForeignKey("Medication")]
        public int MedicationId { get; set; }

        public int TenderMedicationOfferQuantity { get; set; }
        public float TenderMedicationOfferPriceByPiece { get; set; }
        public float TenderMedicationOfferPriceTotal { get; set; }

        public TenderMedicationOffer()
        {
            UpdateTotalPrice();
        }

        public TenderMedicationOffer(int id, int tenderOfferId, int medicationId, int tenderMedicationOfferQuantity, float tenderMedicationOfferPriceByPiece)
        {
            Id = id;
            TenderOfferId = tenderOfferId;
            MedicationId = medicationId;
            TenderMedicationOfferQuantity = tenderMedicationOfferQuantity;
            TenderMedicationOfferPriceByPiece = tenderMedicationOfferPriceByPiece;
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            if (TenderMedicationOfferPriceByPiece != 0 && TenderMedicationOfferQuantity != 0)
            {
                TenderMedicationOfferPriceTotal = TenderMedicationOfferPriceByPiece * TenderMedicationOfferQuantity;
            }
            else
            {
                TenderMedicationOfferPriceTotal = 0;
            }
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
