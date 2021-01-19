
using MedbayTech.Common.Repository;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using System.Collections.Generic;

namespace MedbayTech.Tenders.Application.Common.Interfaces.Persistance.Tenders
{
    public interface ITenderOfferRepository : IRepository<TenderOffer, int>
    {
        List<TenderOffer> GelAllForTenderId(int tenderId);
    }
}
