using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Examinations.Model;
using Model;
using Repository;

namespace Backend.Examinations.Repository.MySqlRepository
{
    class TreatmentSqlRepository : MySqlrepository<Treatment, int>,
        ITreatmentRepository

    {
        public TreatmentSqlRepository(MySqlContext context) : base(context)
        {
        }

        public IEnumerable<HospitalTreatment> GetAllHospitalTreatments()
        {
            return (IEnumerable<HospitalTreatment>) GetAll().ToList().Where(treatment => treatment.IsHospitalTreatment());
        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return (IEnumerable<Prescription>)GetAll().Where(treatment => treatment.IsPrescription());
        }

        public IEnumerable<Prescription> GetAllPrescriptionsInPeriod(DateTime startDate, DateTime endDate)
        {
            return (IEnumerable<Prescription>)GetAll().ToList().Where(treatment => treatment.IsPrescription() 
                && ((Prescription)treatment).IsStillActive(startDate, endDate));
        }
    }
}
