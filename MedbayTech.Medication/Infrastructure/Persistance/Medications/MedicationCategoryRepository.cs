using MedbayTech.Medications.Application.Common.Interfaces.Peristance.Medications;
using MedbayTech.Medications.Domain.Entities.Medications;
using MedbayTech.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Medications.Infrastructure.Persistance
{
    public class MedicationCategoryRepository : SqlRepository<MedicationCategory, int>,
        IMedicationCategoryRepository
    {
    }
}
