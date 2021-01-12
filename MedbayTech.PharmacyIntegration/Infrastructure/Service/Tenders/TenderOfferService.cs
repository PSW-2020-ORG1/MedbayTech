using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Tenders;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Infrastructure.Service.Tenders
{
    public class TenderOfferService : ITenderOfferService
    {
        private readonly ITenderOfferRepository _tenderOfferRepository;

        public TenderOfferService(ITenderOfferRepository tenderOfferRepository)
        {
            _tenderOfferRepository = tenderOfferRepository;
        }

        public TenderOffer Add(TenderOffer tenderOffer)
        {
           return _tenderOfferRepository.Create(tenderOffer);
        }

        public List<TenderOffer> GelAllForTender(int tenderId)
        {
            return _tenderOfferRepository.GelAllForTenderId(tenderId);
        }

        public TenderOffer Get(int id) => _tenderOfferRepository.GetBy(id);


        public List<TenderOffer> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TenderOffer tenderOffer)
        {
            throw new NotImplementedException();
        }

        public TenderOffer Update(TenderOffer tenderOffer)
        {
            throw new NotImplementedException();
        }
    }
}
