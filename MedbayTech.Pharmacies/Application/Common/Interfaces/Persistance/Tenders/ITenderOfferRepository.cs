
using MedbayTech.Common.Repository;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;
using System.Collections.Generic;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Tenders
{
    public interface ITenderOfferRepository : IRepository<TenderOffer, int>
    {
        List<TenderOffer> GelAllForTenderId(int tenderId);
    }
}
