using MedbayTech.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedbayTech.Pharmacies.Domain.Entities.Tenders
{
    public class TenderOffer : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Tender")]
        public int TenderId { get; set; }

        public string Pharmacy { get; set; }
        public string PharmacyEMail { get; set; }

        public virtual List<TenderMedicationOffer> TenderMedicationOffers { get; set; }

        public TenderOffer()
        {
        }

        public TenderOffer(int id, int tnederId, string pharmacy, string pharmacyEMail, List<TenderMedicationOffer> tenderMedicationOffers)
        {
            Id = id;
            TenderId = tnederId;
            Pharmacy = pharmacy;
            PharmacyEMail = pharmacyEMail;
            TenderMedicationOffers = tenderMedicationOffers;
        }

        public TenderOffer(int id, int tnederId, string pharmacy, string pharmacyEMail)
        {
            Id = id;
            TenderId = tnederId;
            Pharmacy = pharmacy;
            PharmacyEMail = pharmacyEMail;
            TenderMedicationOffers = new List<TenderMedicationOffer>();
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
