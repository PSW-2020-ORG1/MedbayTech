using Backend.Examinations.Service.Interfaces;
using Backend.Records.Model;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Examinations.Service
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public MedicalRecord GetMedicalRecordByPatientId(string patientId)
        {
            return _medicalRecordRepository.GetMedicalRecordByPatientId(patientId);
        }
    }
}
