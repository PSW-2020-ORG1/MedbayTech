using System;
using System.Collections.Generic;
using System.Text;
using Backend.Records.Model;
using Model;
using Model.Users;
using Repository;
using Repository.MedicalRecordRepository;
using System.Linq;

namespace Backend.Records.Repository.MySqlRepository
{
    public class MedicalRecordSqlRepository : MySqlrepository<MedicalRecord, int>,
        IMedicalRecordRepository
    {
        public MedicalRecordSqlRepository(MySqlContext context) : base(context) { }

        public IEnumerable<MedicalRecord> FilterRecordsByState(PatientCondition state)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetRecordBy(Patient patient)
        {
            MedicalRecord medicalRecord = GetAll().SingleOrDefault(entity => entity.Patient.Id.CompareTo(patient.Id) == 0);

            if (medicalRecord != null)
            {
                return medicalRecord;
            }
            else
                throw new NotImplementedException();
        }

        public IEnumerable<MedicalRecord> GetRecordsFor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
