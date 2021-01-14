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
<<<<<<< HEAD

        public TenderOfferService(ITenderOfferRepository tenderOfferRepository)
        {
            _tenderOfferRepository = tenderOfferRepository;
=======
        private readonly ITenderMedicationOfferRepository _tenderMedicationOfferRepository;

        public TenderOfferService(ITenderOfferRepository tenderOfferRepository, ITenderMedicationOfferRepository tenderMedicationOfferRepository)
        {
            _tenderOfferRepository = tenderOfferRepository;
            _tenderMedicationOfferRepository = tenderMedicationOfferRepository;
>>>>>>> develop
        }

        public TenderOffer Add(TenderOffer tenderOffer)
        {
<<<<<<< HEAD
           return _tenderOfferRepository.Create(tenderOffer);
=======
            throw new NotImplementedException();
>>>>>>> develop
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

<<<<<<< HEAD
=======
        public float GetTotalPrice(int tenderOfferId)
        {
            return _tenderMedicationOfferRepository.GetTotalPriceForId(tenderOfferId);
        }

>>>>>>> develop
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
