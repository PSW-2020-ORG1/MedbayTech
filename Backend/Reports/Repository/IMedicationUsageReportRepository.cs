using Backend.General.Model;
using Backend.Reports.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Reports.Repository
{
    public interface IMedicationUsageReportRepository : IRepository<MedicationUsageReport, int>
    {
        IEnumerable<MedicationUsageReport> GetAll();

        bool ExistsInSystem(int id);
        int GetNextID();
    }
}
