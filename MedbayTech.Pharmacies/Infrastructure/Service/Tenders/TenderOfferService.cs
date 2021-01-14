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
            return _tenderOfferRepository.GetAll();
        }

        public bool Remove(TenderOffer tenderOffer)
        {
            return _tenderOfferRepository.Delete(tenderOffer);
        }

        public TenderOffer Update(TenderOffer tenderOffer)
        {
            return _tenderOfferRepository.Update(tenderOffer);
        }
    }
}
