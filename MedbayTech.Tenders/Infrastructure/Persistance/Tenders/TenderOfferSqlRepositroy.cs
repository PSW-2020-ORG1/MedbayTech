using System;
using System.Collections.Generic;
using MedbayTech.Repository;
using MedbayTech.Tenders.Application.Common.Interfaces.Persistance.Tenders;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using MedbayTech.Tenders.Infrastructure.Database;

namespace MedbayTech.Tenders.Infrastructure.Persistance.Tenders
{
    public class TenderOfferSqlRepositroy : SqlRepository<TenderOffer, int>, ITenderOfferRepository   
    {
        public TenderOfferSqlRepositroy(TenderDbContext context) : base(context) { }

        public List<TenderOffer> GelAllForTenderId(int tenderId)
        {
            List<TenderOffer> tenderOffers = GetAll();
            return tenderOffers.FindAll(x => x.TenderId == tenderId);
        }
    }
}
