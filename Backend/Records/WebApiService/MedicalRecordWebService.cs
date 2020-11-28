using Backend.Records.Model;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Records.WebApiService
{
    public class MedicalRecordWebService
    {
        private IMedicalRecordRepository medicalRecordRepository;
        
        public MedicalRecordWebService(IMedicalRecordRepository medicalRecordRepository)
        {
            this.medicalRecordRepository = medicalRecordRepository;
        }

        public MedicalRecord GetMedicalRecordByPatientId(string id)
        {
            return medicalRecordRepository.GetMedicalRecordByPatientId(id);
        }

        public MedicalRecord CreateMedicalRecord(MedicalRecord medicalRecord)
        {
            return medicalRecordRepository.Create(medicalRecord);
        }


    }
}
