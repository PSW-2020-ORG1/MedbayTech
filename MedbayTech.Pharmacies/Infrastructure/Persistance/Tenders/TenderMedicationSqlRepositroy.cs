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
    public class TenderMedicationSqlRepositroy : SqlRepository<TenderMedication, int>, ITenderMedicationRepository
    {
        public TenderMedicationSqlRepositroy(PharmacyDbContext context) : base(context) { }

        public List<TenderMedication> GetMedicationsForTender(int TenderId)
        {
            List<TenderMedication> tenderMedications = GetAll();
            return tenderMedications.FindAll(x => x.TenderID == TenderId);
        }
    }
}
