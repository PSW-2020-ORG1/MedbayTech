/***********************************************************************
 * Module:  MedicalRecordService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.MedicalRecordService
 ***********************************************************************/

using Backend.Records.Model;
using Backend.Medications.Model;
using Model.Users;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.MedicalRecordService
{
   public class MedicalRecordService
   {
        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            this.medicalRecordRepository = medicalRecordRepository;
        }

        public MedicalRecord CreateNewRecord(MedicalRecord medicalRecord) => 
            medicalRecordRepository.Create(medicalRecord);

        public MedicalRecord UpdateRecord(MedicalRecord medicalRecord) => 
            medicalRecordRepository.Update(medicalRecord);

        public bool DeleteRecord(MedicalRecord medicalRecord) => 
            medicalRecordRepository.Delete(medicalRecord); 

        public IEnumerable<MedicalRecord> GetRecordsFor(Doctor doctor) => 
            medicalRecordRepository.GetRecordsFor(doctor);

        public MedicalRecord GetMedicalRecord(int recordNumber) => 
            medicalRecordRepository.GetObject(recordNumber);


        public MedicalRecord GetRecordBy(Patient patient) => 
            medicalRecordRepository.GetRecordBy(patient);

        public MedicalRecord UpdateAllergies(Allergens allergy, MedicalRecord medicalRecord)
        {
            MedicalRecord medicalRecordToUpdate = medicalRecordRepository.GetObject(medicalRecord.Id);
            if (!medicalRecordToUpdate.IsAllergyAdded(allergy)) 
                medicalRecordToUpdate.Allergies.Add(allergy);
            return medicalRecordRepository.Update(medicalRecordToUpdate);
        }

        public MedicalRecord UpdateIllnessHistory(Diagnosis diagnosis, MedicalRecord medicalRecord)
        {
            MedicalRecord medicalRecordToUpdate = medicalRecordRepository.GetObject(medicalRecord.Id);
            medicalRecordToUpdate.IllnessHistory.Add(diagnosis);
            return medicalRecordRepository.Update(medicalRecordToUpdate);
        }

        public MedicalRecord UpdateFamilyIllnessHistory(FamilyIllnessHistory diagnosis, MedicalRecord medicalRecord)
        {
            MedicalRecord medicalRecordToUpdate = medicalRecordRepository.GetObject(medicalRecord.Id);
            if (!medicalRecordToUpdate.IsFamilyIllnessHistoryAdded(diagnosis))
                medicalRecordToUpdate.FamilyIllnessHistory.Add(diagnosis);
            return medicalRecordRepository.Update(medicalRecordToUpdate);
        }

        public MedicalRecord UpdateTherapy(Therapy therapy, MedicalRecord medicalRecord)
        {
            MedicalRecord medicalRecordToUpdate = medicalRecordRepository.GetObject(medicalRecord.Id);
            if (!medicalRecordToUpdate.IsTherapyAdded(therapy))
                medicalRecordToUpdate.Therapies.Add(therapy);
            return medicalRecordRepository.Update(medicalRecordToUpdate);
        }

        public MedicalRecord UpdateVaccines(Vaccines vaccine, MedicalRecord medicalRecord)
        {
            MedicalRecord medicalRecordToUpdate = medicalRecordRepository.GetObject(medicalRecord.Id);
            if (!medicalRecordToUpdate.IsVaccineAdded(vaccine))
                medicalRecordToUpdate.Vaccines.Add(vaccine);
            return medicalRecordRepository.Update(medicalRecordToUpdate);
        }

        public IMedicalRecordRepository medicalRecordRepository;
     
   }
}