
using MedbayTech.Common.Repository;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Tenders
{
    public interface ITenderMedicationOfferRepository : IRepository<TenderMedicationOffer, int>
    {
        float GetTotalPriceForId(int tenderOfferId);
    }
}
