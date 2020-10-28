/***********************************************************************
 * Module:  MedicalRecordService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.MedicalRecordService
 ***********************************************************************/

using Model.MedicalRecord;
using Model.Medications;
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

        public MedicalRecord CreateNewRecord(MedicalRecord medicalRecord) => medicalRecordRepository.Create(medicalRecord);

        public MedicalRecord UpdateRecord(MedicalRecord medicalRecord) => medicalRecordRepository.Update(medicalRecord);
        public bool DeleteRecord(MedicalRecord medicalRecord) => medicalRecordRepository.Delete(medicalRecord); 
        public IEnumerable<MedicalRecord> GetRecordsForDoctor(Doctor doctor) => medicalRecordRepository.GetRecordsForDoctor(doctor);

        public MedicalRecord GetMedicalRecord(int recordNumber) => medicalRecordRepository.GetObject(recordNumber);
        public ListOfResults GetLastLabResult(MedicalRecord medicalRecord)
        {
            var record = medicalRecordRepository.GetObject(medicalRecord.IdRecord);
            ListOfResults lastResult = null;
            if (medicalRecord.ListOfResults.Count > 0)
                lastResult = medicalRecord.ListOfResults[0];
            foreach (ListOfResults results in record.ListOfResults)
            {
                if (results.DateOfTesting.CompareTo(lastResult.DateOfTesting) > 0)
                    lastResult = results;
            }
            return lastResult;
        }

        public IEnumerable<MedicalRecord> FilterRecordsByState(PatientCondition state, Doctor doctor)
        {
             throw new NotImplementedException();
        }

        public MedicalRecord GetRecordByPatient(Patient patient) => medicalRecordRepository.GetRecordByPatient(patient);

        public MedicalRecord UpdateAllergies(Allergens allergy, MedicalRecord medicalRecord)
        {
            MedicalRecord medicalRecordToUpdate = medicalRecordRepository.GetObject(medicalRecord.IdRecord);
            if (!medicalRecordToUpdate.Allergies.Any(entity => entity.Allergen.Equals(allergy.Allergen)))
                medicalRecordToUpdate.Allergies.Add(allergy);
            return medicalRecordRepository.Update(medicalRecordToUpdate);
        }
      
        public MedicalRecord UpdateIllnessHistory(Diagnosis diagnosis, MedicalRecord medicalRecord)
        {
            MedicalRecord medicalRecordToUpdate = medicalRecordRepository.GetObject(medicalRecord.IdRecord);
            medicalRecordToUpdate.IllnessHistory.Add(diagnosis);
            return medicalRecordRepository.Update(medicalRecordToUpdate);
        }
      
        public MedicalRecord UpdateFamilyIllnessHistory(FamilyIllnessHistory diagnosis, MedicalRecord medicalRecord)
        {
            MedicalRecord medicalRecordToUpdate = medicalRecordRepository.GetObject(medicalRecord.IdRecord);
            if (!medicalRecordToUpdate.FamilyIllnessHistory.Any(entity => entity.Diagnosis.Any(diag => diag.Code == diag.Code) && 
                entity.RelativeMember == diagnosis.RelativeMember))
                medicalRecordToUpdate.FamilyIllnessHistory.Add(diagnosis);
            return medicalRecordRepository.Update(medicalRecordToUpdate);
        }
      
        public MedicalRecord UpdateTherapy(Therapy therapy, MedicalRecord medicalRecord)
        {
            MedicalRecord medicalRecordToUpdate = medicalRecordRepository.GetObject(medicalRecord.IdRecord);
            if (!medicalRecordToUpdate.Therapies.Any(entity => entity.Medication.MedId == therapy.Medication.MedId))
                medicalRecordToUpdate.Therapies.Add(therapy);
            return medicalRecordRepository.Update(medicalRecordToUpdate);
        }
      
        public MedicalRecord UpdateVaccines(Vaccines vaccine, MedicalRecord medicalRecord)
        {
            MedicalRecord medicalRecordToUpdate = medicalRecordRepository.GetObject(medicalRecord.IdRecord);
            if (!medicalRecordToUpdate.Vaccines.Any(entity => entity.Name.Equals(vaccine.Name)))
                medicalRecordToUpdate.Vaccines.Add(vaccine);
            return medicalRecordRepository.Update(medicalRecordToUpdate);
        }
      
        public MedicalRecord UpdateLabResults(ListOfResults labResult, MedicalRecord medicalRecord)
        {
            MedicalRecord medicalRecordToUpdate = medicalRecordRepository.GetObject(medicalRecord.IdRecord);
            if (!medicalRecordToUpdate.ListOfResults.Any(entity => entity.Id == labResult.Id))
                medicalRecordToUpdate.ListOfResults.Add(labResult);
            return medicalRecordRepository.Update(medicalRecordToUpdate);
        }
      
        public IMedicalRecordRepository medicalRecordRepository;
     
   }
}