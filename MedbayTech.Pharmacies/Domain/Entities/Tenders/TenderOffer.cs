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
        
        public float TenderOfferPrice { get; set; }

        public TenderOffer()
        {
        }

        public TenderOffer(int tenderId, string pharmacy, string pharmacyEMail, float tenderOfferPrice)
        {
            TenderId = tenderId;
            Pharmacy = pharmacy;
            PharmacyEMail = pharmacyEMail;
            TenderOfferPrice = tenderOfferPrice;
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
