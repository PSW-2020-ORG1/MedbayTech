// File:    EmergencyRequestRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:29:24 AM
// Purpose: Definition of Class EmergencyRequestRepository

using Backend.Examinations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using Backend.Examinations.Model.Enums;
using SimsProjekat.SIMS.Exceptions;
using Backend.Records.Model;
using Backend.Medications.Model;
using Repository;
using Backend.General.Model;
using Repository.MedicalRecordRepository;

namespace Backend.Examinations.Repository
{
   public class EmergencyRequestRepository : JSONRepository<EmergencyRequest, int>,
        IEmergencyRequestRepository, ObjectComplete<EmergencyRequest>
    {

        public IMedicalRecordRepository medicalRecordRepository;
        
        const string NOT_FOUND = "Examination with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Examination with ID number {0} already exists!";

        public EmergencyRequestRepository(IMedicalRecordRepository medicalRecordRepository, Stream<EmergencyRequest> stream)
            : base(stream, "Emergency request")
        {
            this.medicalRecordRepository = medicalRecordRepository;
        }

        public new EmergencyRequest Create(EmergencyRequest entity)
        {
            entity.SetId(GetNextId());
            SetMissingValues(entity);
            return base.Create(entity);
        }

        public int GetNextId() => stream.GetAll().ToList().Count + 1;

        public new IEnumerable<EmergencyRequest> GetAll()
        {
            List<EmergencyRequest> allRequests = stream.GetAll().ToList();
            foreach (EmergencyRequest request in allRequests)
                CompleteObject(request);

            return allRequests;
        }
        public new EmergencyRequest GetObject(int id)
        {
            EmergencyRequest request = base.GetObject(id);
            CompleteObject(request);
            return request;
        }

        public new EmergencyRequest Update(EmergencyRequest entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public IEnumerable<EmergencyRequest> GetAllUnScheduled()
        {
             var allUnscheduled = stream.GetAll().Where(request => request.Status == Status.Rejected).ToList();
            foreach (EmergencyRequest request in allUnscheduled)
                CompleteObject(request);
            return allUnscheduled;
        }
        public void SetMissingValues(EmergencyRequest entity)
        {
            entity.MedicalRecord = new MedicalRecord(entity.MedicalRecord.Id);
        }

        public void CompleteObject(EmergencyRequest entity)
        {
            entity.MedicalRecord = medicalRecordRepository.GetObject(entity.MedicalRecord.Id);
        }
    }
}