using Backend.Reports.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Reports.Repository
{
    public interface IMedicationUsageRepository : IRepository<MedicationUsage, int>
    {
    }
}
