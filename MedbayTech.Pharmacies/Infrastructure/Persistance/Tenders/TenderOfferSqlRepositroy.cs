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
    public class TenderOfferSqlRepositroy : SqlRepository<TenderOffer, int>, ITenderOfferRepository   
    {
        public TenderOfferSqlRepositroy(PharmacyDbContext context) : base(context) { }

        public List<TenderOffer> GelAllForTenderId(int tenderId)
        {
            List<TenderOffer> tenderOffers = GetAll();
            return tenderOffers.FindAll(x => x.TenderId == tenderId);
        }
    }
}
