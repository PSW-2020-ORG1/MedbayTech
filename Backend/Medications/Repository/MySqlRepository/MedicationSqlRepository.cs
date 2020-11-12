using System;
using System.Collections.Generic;
using System.Text;
using Backend.Medications.Model;
using Backend.Medications.Repository.FileRepository;
using Repository;

namespace Backend.Medications.Repository.MySqlRepository
{
    class MedicationSqlRepository : MySqlrepository<Medication, int>,
        IMedicationRepository
    {
        public IEnumerable<Medication> GetAllApproved()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medication> GetAllOnValidation()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medication> GetAllRejected()
        {
            throw new NotImplementedException();
        }

        public int GetNextID()
        {
            throw new NotImplementedException();
        }
    }
}
