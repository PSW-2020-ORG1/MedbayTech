using Backend.Examinations.Model;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Examinations.Repository.MySqlRepository
{
    class PrescriptionSqlRepository : MySqlrepository<Prescription, int>,
        IPrescriptionRepository
    {
        public PrescriptionSqlRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return GetAll().Where(pres => pres.IsPrescription());
        }

        public IEnumerable<Prescription> GetSearchedPresciptions()
        {
            return GetAll().Where(pres => pres.HourlyIntake == 8 && pres.Medication.Med.Equals("Brufen"));
        }

        
    }
}
