using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Examinations.Model;
using Model;
using Repository;

namespace Backend.Examinations.Repository.MySqlRepository
{
    public class TreatmentSqlRepository : MySqlrepository<Treatment, int>,
        ITreatmentRepository

    {
        public TreatmentSqlRepository(MedbayTechDbContext context) : base(context)
        {
        }

        public List<HospitalTreatment> GetAllHospitalTreatments()
        {
            return (List<HospitalTreatment>) GetAll().ToList().Where(treatment => treatment.IsHospitalTreatment());
        }

        public List<Prescription> GetAllPrescriptions()
        {
            return (List<Prescription>)GetAll().Where(treatment => treatment.IsPrescription());
        }

        public List<Prescription> GetAllPrescriptionsInPeriod(DateTime startDate, DateTime endDate)
        {
            return (List<Prescription>)GetAll().ToList().Where(treatment => treatment.IsPrescription() 
                && ((Prescription)treatment).IsStillActive(startDate, endDate));
        }
    }
}
