using Backend.Reports.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Reports.Repository.MySqlRepository
{
    public class MedicationUsageSqlRepository : MySqlrepository<MedicationUsage, int>,
        IMedicationUsageRepository
    {
    }
}
