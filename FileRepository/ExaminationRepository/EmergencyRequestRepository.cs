// File:    EmergencyRequestRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:29:24 AM
// Purpose: Definition of Class EmergencyRequestRepository

using Model.ExaminationSurgery;
using Repository.ReportRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using SimsProjekat.SIMS.Exceptions;
using Model.MedicalRecord;
using SimsProjekat.Repository;
using Repository.MedicalRecordRepository;

namespace Repository.ExaminationRepository
{
   public class EmergencyRequestRepository : JSONRepository<EmergencyRequest, int>,
        IEmergencyRequestRepository, ObjectComplete<EmergencyRequest>
    {

        public MedicalRecordRepository.IMedicalRecordRepository medicalRecordRepository;
        
        const string NOT_FOUND = "Examination with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Examination with ID number {0} already exists!";

        public EmergencyRequestRepository(IMedicalRecordRepository medicalRecordRepository, Stream<EmergencyRequest> stream)
            : base(stream, "Emergency request")
        {
            this.medicalRecordRepository = medicalRecordRepository;
        }

        public new EmergencyRequest Create(EmergencyRequest entity)
        {
            entity.SetId(GetNextID());
            SetMissingValues(entity);
            return base.Create(entity);
        }

        public int GetNextID() => stream.GetAll().ToList().Count + 1;

        public new IEnumerable<EmergencyRequest> GetAll()
        {
            var allRequests = stream.GetAll().ToList();
            foreach (EmergencyRequest request in allRequests)
            {
                CompleteObject(request);
            }

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
             var allUnscheduled = stream.GetAll().Where(request => request.Scheduled == false).ToList();
            foreach (EmergencyRequest request in allUnscheduled)
            {
                CompleteObject(request);
            }
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