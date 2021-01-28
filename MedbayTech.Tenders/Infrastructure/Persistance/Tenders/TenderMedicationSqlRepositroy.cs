using System;
using System.Collections.Generic;
using MedbayTech.Repository;
using MedbayTech.Tenders.Application.Common.Interfaces.Persistance.Tenders;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using MedbayTech.Tenders.Infrastructure.Database;

namespace MedbayTech.Tenders.Infrastructure.Persistance.Tenders
{
    public class TenderMedicationSqlRepositroy : SqlRepository<TenderMedication, int>, ITenderMedicationRepository
    {
        public TenderMedicationSqlRepositroy(TenderDbContext context) : base(context) { }

        public List<TenderMedication> GetMedicationsForTender(int TenderId)
        {
            List<TenderMedication> tenderMedications = GetAll();
            return tenderMedications.FindAll(x => x.TenderID == TenderId);
        }
    }
}
