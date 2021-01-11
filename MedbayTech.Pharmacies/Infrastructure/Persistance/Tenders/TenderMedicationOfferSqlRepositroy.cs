using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Tenders;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;
using MedbayTech.Pharmacies.Infrastructure.Database;
using MedbayTech.Repository;

namespace MedbayTech.Pharmacies.Infrastructure.Persistance.Tenders
{
    public class TenderMedicationOfferSqlRepositroy : SqlRepository<TenderMedicationOffer, int>, ITenderMedicationOfferRepository
    {
        public TenderMedicationOfferSqlRepositroy(PharmacyDbContext context) : base(context) { }

        public float GetTotalPriceForId(int tenderOfferId)
        {
            float total = 0;
            List<TenderMedicationOffer> tenderMedicationOffers = GetAll();
            foreach (TenderMedicationOffer tenderMedicationOffer in tenderMedicationOffers.FindAll(x => x.TenderOfferId == tenderOfferId))
            {
                total += tenderMedicationOffer.TenderMedicationOfferQuantity * tenderMedicationOffer.TenderMedicationOfferPriceByPiece;
            }
            return total;
        }
    }
}
