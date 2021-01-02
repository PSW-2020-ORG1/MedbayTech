using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;


namespace MedbayTech.PatientDocuments.Application.Common.Interfaces.Service
{
    public interface IMedicalRecordService
    {
        MedicalRecord GetMedicalRecordByPatient(string patientId);
        MedicalRecord CreateMedicalRecord(MedicalRecord medicalRecord);
    }
}
