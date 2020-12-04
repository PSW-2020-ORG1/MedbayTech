using Backend.Records.Model;
using Backend.Records.Service.Interfaces;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Records.WebApiService
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private IMedicalRecordRepository medicalRecordRepository;
        
        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
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
