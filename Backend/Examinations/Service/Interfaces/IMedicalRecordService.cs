using Backend.Records.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Examinations.Service.Interfaces
{
    public interface IMedicalRecordService
    {
        MedicalRecord GetMedicalRecordByPatientId(string patientId);
    }
}
