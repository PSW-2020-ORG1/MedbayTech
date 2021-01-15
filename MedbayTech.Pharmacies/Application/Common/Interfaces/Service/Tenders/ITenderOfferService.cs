using MedbayTech.Pharmacies.Domain.Entities.Tenders;
using System.Collections.Generic;


namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Tenders
{
    public interface ITenderOfferService
    {
        TenderOffer Add(TenderOffer tenderOffer);
        bool Remove(TenderOffer tenderOffer);
        TenderOffer Update(TenderOffer tenderOffer);
        TenderOffer Get(int id);
        List<TenderOffer> GetAll();
        List<TenderOffer> GelAllForTender(int tenderId);
    }
}
