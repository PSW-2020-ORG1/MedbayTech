using Backend.Records.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Records.Service.Interfaces
{
    public interface IMedicalRecordService
    {
        MedicalRecord GetMedicalRecordByPatientId(string id);
        MedicalRecord CreateMedicalRecord(MedicalRecord medicalRecord);
    }
}
