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
        public MedicationSqlRepository(MySqlContext context) : base(context) { }

        public IEnumerable<Medication> GetAllApproved()
        {
            return GetAll().ToList();
        }

        public IEnumerable<Medication> GetAllOnValidation()
        {
            return GetAll().ToList();
        }

        public IEnumerable<Medication> GetAllRejected()
        {
            return GetAll().ToList();
        }

        public int GetNextID()
        {
            return GetAll().ToList().Count + 1;

        }
    }
}
