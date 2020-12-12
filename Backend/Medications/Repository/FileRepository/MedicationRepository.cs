 /***********************************************************************
 * Module:  MedicationRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.MedicationRepository
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using SimsProjekat.SIMS.Exceptions;
using Backend.General.Model;
using Backend.Medications.Model;

namespace Backend.Medications.Repository.FileRepository
{
   public class MedicationRepository : JSONRepository<Medication, int>,
        IMedicationRepository
   {
        public Stream<Medication> stream;

        private const string NOT_FOUND = "Medication with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Medication with ID number {0} already exists!";

        public MedicationRepository(Stream<Medication> stream) : base(stream, "Medication")
        {
            this.stream = stream;
        }

        public new Medication Create(Medication entity)
        {
            entity.Id = GetNextID();
            return base.Create(entity);
        }

        public IEnumerable<Medication> GetAllApproved() => 
            stream.GetAll().Where(medication => medication.Status == MedStatus.Approved).ToList();
        
        public IEnumerable<Medication> GetAllOnValidation() => 
            stream.GetAll().Where(medication => medication.Status == MedStatus.Validation).ToList();
    
        public IEnumerable<Medication> GetAllRejected() => 
            stream.GetAll().Where(medication => medication.Status == MedStatus.Rejected).ToList();
        
        public int GetNextID() => 
            stream.GetAll().ToList().Count + 1;

    }
}