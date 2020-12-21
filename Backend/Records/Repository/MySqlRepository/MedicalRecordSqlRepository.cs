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
        public MedicalRecordSqlRepository(MedbayTechDbContext context) : base(context) { }

        public List<MedicalRecord> FilterRecordsByState(PatientCondition state)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetMedicalRecordByPatientId(string id)
        {
            List<MedicalRecord> medicalRecords = GetAll().ToList();
            MedicalRecord medicalRecord = medicalRecords.FirstOrDefault(entity => entity.Patient.Id.Equals(id));

            if (medicalRecord != null)
            {
                return medicalRecord;
            }
            else
                throw new NotImplementedException();
        }

        public List<MedicalRecord> GetRecordsFor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        MedicalRecord IMedicalRecordRepository.GetRecordBy(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
