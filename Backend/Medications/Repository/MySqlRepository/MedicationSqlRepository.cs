using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using Backend.Medications.Model;
using Backend.Medications.Repository.FileRepository;
using Model;
using Repository;

namespace Backend.Medications.Repository.MySqlRepository
{
    public class MedicationSqlRepository : MySqlrepository<Medication, int>, IMedicationRepository
    {
        public MedicationSqlRepository(MedbayTechDbContext context) : base(context) { }

        public List<Medication> GetAllApproved()
        {
            return GetAll().ToList();
        }

        public List<Medication> GetAllOnValidation()
        {
            return GetAll().ToList();
        }

        public List<Medication> GetAllRejected()
        {
            return GetAll().ToList();
        }

        public int GetNextID()
        {
            return GetAll().ToList().Count + 1;

        }
    }
}
