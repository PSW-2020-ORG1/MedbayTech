using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;


namespace Backend.Records.Service.Interfaces
{
    public interface IMedicalRecordService
    {
        MedicalRecord GetMedicalRecordByPatient(string patientId);
        MedicalRecord CreateMedicalRecord(MedicalRecord medicalRecord);
    }
}
