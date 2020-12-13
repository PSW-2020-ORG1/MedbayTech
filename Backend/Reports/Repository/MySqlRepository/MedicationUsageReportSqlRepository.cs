using Backend.Records.Model;
using Backend.Reports.Model;
using Model;
using Model.Users;
using Repository;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Reports.Repository.MySqlRepository
{
    public class MedicationUsageReportSqlRepository : IMedicationUsageReportRepository
    {

        private MySqlContext _context;

        public MedicationUsageReportSqlRepository(MySqlContext context)
        {
            _context = context;
        }
        
        public MedicationUsageReport Create(MedicationUsageReport entity)
        {
            _context.MedicationUsageReports.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(MedicationUsageReport entity)
        {
            if(GetObject(entity.Id) == null)
            {
                return false;
            }
            _context.MedicationUsageReports.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool ExistsInSystem(string id) => GetObject(id) != null;

        public IEnumerable<MedicationUsageReport> GetAll() => _context.MedicationUsageReports.ToList();

        public MedicationUsageReport GetObject(string id) => 
            _context.MedicationUsageReports.ToList().Find(mur => mur.Id.Equals(id));

        public MedicationUsageReport Update(MedicationUsageReport entity)
        {
            _context.MedicationUsageReports.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
