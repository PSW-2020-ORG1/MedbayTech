/***********************************************************************
 * Module:  MedicalRecordService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.MedicalRecordService
 ***********************************************************************/

using Model.MedicalRecord;
using Model.Medications;
using Model.Users;
using Service.MedicalRecordService;
using System;
using System.Collections.Generic;

namespace Controller.MedicalRecordController
{
   public class MedicalRecordController
   {
        public MedicalRecordController(MedicalRecordService medicalRecordService)
        {
            this.medicalRecordService = medicalRecordService;
        }

        public MedicalRecord CreateNewRecord(MedicalRecord medicalRecord) => medicalRecordService.CreateNewRecord(medicalRecord);
        public MedicalRecord UpdateRecord(MedicalRecord medicalRecord) => medicalRecordService.UpdateRecord(medicalRecord);
        public bool DeleteRecord(MedicalRecord medicalRecord) => medicalRecordService.DeleteRecord(medicalRecord);
        public IEnumerable<MedicalRecord> GetRecordsForDoctor(Doctor doctor) => medicalRecordService.GetRecordsForDoctor(doctor);
        public MedicalRecord GetMedicalRecord(int recordNumber) => medicalRecordService.GetMedicalRecord(recordNumber);
        public IEnumerable<MedicalRecord> FilterRecordsByState(PatientCondition state, Doctor doctor) => medicalRecordService.FilterRecordsByState(state, doctor);
        public MedicalRecord GetRecordByPatient(Patient patient) => medicalRecordService.GetRecordByPatient(patient);
        public MedicalRecord UpdateAllergies(Allergens allergy, MedicalRecord medicalRecord) => medicalRecordService.UpdateAllergies(allergy, medicalRecord);
        public MedicalRecord UpdateIllnessHistory(Diagnosis diagnosis, MedicalRecord medicalRecord) => medicalRecordService.UpdateIllnessHistory(diagnosis, medicalRecord);
        public MedicalRecord UpdateFamilyIllnessHistory(FamilyIllnessHistory diagnosis, MedicalRecord medicalRecord) => medicalRecordService.UpdateFamilyIllnessHistory(diagnosis, medicalRecord);
        public MedicalRecord UpdateTherapy(Therapy therapy, MedicalRecord medicalRecord) => medicalRecordService.UpdateTherapy(therapy, medicalRecord);
        public MedicalRecord UpdateVaccines(Vaccines vaccine, MedicalRecord medicalRecord) => medicalRecordService.UpdateVaccines(vaccine, medicalRecord);
        public MedicalRecord UpdateLabResults(ListOfResults labResult, MedicalRecord medicalRecord) => medicalRecordService.UpdateLabResults(labResult, medicalRecord);
        public ListOfResults GetLastLabResult(MedicalRecord medicalRecord) => medicalRecordService.GetLastLabResult(medicalRecord);

        public MedicalRecordService medicalRecordService;
   
   }
}