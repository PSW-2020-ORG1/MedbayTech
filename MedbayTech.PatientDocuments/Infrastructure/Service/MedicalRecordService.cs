﻿using MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Service;
using MedbayTech.PatientDocuments.Application.Exception;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using Repository.MedicalRecordRepository;
using System;


namespace MedbayTech.PatientDocuments.Infrastructure.Service
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IUserGateway _userGateway;
        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository, IUserGateway userGateway)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _userGateway = userGateway;
        }
        public MedicalRecord CreateMedicalRecord(MedicalRecord medicalRecord)
        {
            return _medicalRecordRepository.Create(medicalRecord);
        }

        public MedicalRecord GetMedicalRecordByPatient(string patientId)
        {
            var record = _medicalRecordRepository.GetRecordBy(patientId);
            if (record != null)
                return record.SetPatient(_userGateway.GetPatientBy(patientId));
            return null;
        }
    }
}
