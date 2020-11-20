using System;
using System.Collections.Generic;
using System.Text;
using Backend.Records.Model;
using Repository;
using Repository.MedicalRecordRepository;

namespace Backend.Records.Repository.MySqlRepository
{
    class DiagnosisSqlRepository : MySqlrepository<Diagnosis, int>,
        IDiagnosisRepository
    {
        public Diagnosis GetBy(string name)
        {
            throw new NotImplementedException();
        }

        public Diagnosis UpdateSymptoms(Diagnosis diagnosis, Symptoms symptom)
        {
            throw new NotImplementedException();
        }
    }
}
