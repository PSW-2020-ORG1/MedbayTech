using Backend.Records.Model;
using Backend.Reports.Model;
using Model.Users;
using Repository;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Reports.Repository.MySqlRepository
{
    class MedicationUsageReportSqlRepository : MySqlrepository<MedicationUsageReport, int>,
        IMedicationUsageReportRepository
    {
        
        public IEnumerable<MedicationUsageReport> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetId()
        {
            throw new NotImplementedException();
        }

        public int GetNextID()
        {
            throw new NotImplementedException();
        }

        public void SetId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
