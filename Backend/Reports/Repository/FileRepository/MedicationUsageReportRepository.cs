using Backend.General.Model;
using Backend.Reports.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Repository;

namespace Backend.Reports.Repository.FileRepository
{
    public class MedicationUsageReportRepository : JSONRepository<MedicationUsageReport, int>,
        IMedicationUsageReportRepository
    {
        public Stream<MedicationUsageReport> stream;

        private const string NOT_FOUND = "MedicationUsageReport with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "MedicationUsageReport with ID number {0} already exists!";

        public MedicationUsageReportRepository(IMedicationUsageReportRepository medicationUsageReportRepository) : base(stream, "MedicationUsageReport")
        {
            this.stream = stream;
        }

        public new MedicationUsageReport Create(MedicationUsageReport entity)
        {
            entity.Id = GetNextId();
            return base.Create(entity);
        }

        public IEnumerable<MedicationUsageReport> GetAll() =>
            stream.GetAll().ToList();

        public int GetNextID() =>
            stream.GetAll().ToList().Count + 1;

    }
    
}
