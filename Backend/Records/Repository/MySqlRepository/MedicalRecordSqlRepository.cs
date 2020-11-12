using System;
using System.Collections.Generic;
using System.Text;
using Backend.Records.Model;
using Model.Users;
using Repository;
using Repository.MedicalRecordRepository;

namespace Backend.Records.Repository.MySqlRepository
{
    class MedicalRecordSqlRepository : MySqlrepository<MedicalRecord, int>,
        IMedicalRecordRepository
    {
        public IEnumerable<MedicalRecord> FilterRecordsByState(PatientCondition state)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetRecordBy(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicalRecord> GetRecordsFor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
