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
    }
}
