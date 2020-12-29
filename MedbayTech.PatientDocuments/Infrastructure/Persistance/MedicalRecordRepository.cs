using MedbayTech.PatientDocuments.Application.Exception;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords.Enums;
using MedbayTech.PatientDocuments.Infrastructure.Database;
using MedbayTech.Repository;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Infrastructure.Persistance
{
    public class MedicalRecordRepository : SqlRepository<MedicalRecord, int>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(PatientDocumentsDbContext context) : base(context) { }
        public MedicalRecord GetRecordBy(string patientId)
        {
            List<MedicalRecord> medicalRecords = GetAll().ToList();
            MedicalRecord medicalRecord = medicalRecords.FirstOrDefault(entity => entity.PatientId.Equals(patientId));

            if (medicalRecord != null)
                return medicalRecord;
            throw new EntityNotFound();
        }

        public List<MedicalRecord> GetRecordsFor(string doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
