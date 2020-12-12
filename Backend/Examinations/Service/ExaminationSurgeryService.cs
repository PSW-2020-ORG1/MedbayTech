/***********************************************************************
 * Module:  ExaminationService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.ExaminationService
 ***********************************************************************/

using Backend.Examinations.Model;
using Backend.Records.Model.Enums;
using Model.Users;
using Backend.Examinations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Exceptions;
using SimsProjekat.SIMS.Exceptions;
using Backend.Records.Model;

namespace Backend.Examinations.Service
{
   public class ExaminationSurgeryService
   {
        public ExaminationSurgeryService(IExaminationSurgeryRepository examinationSurgeryRepository)
        {
            this.examinationSurgeryRepository = examinationSurgeryRepository;
        }

        public ExaminationSurgery CreateExaminationSurgery(ExaminationSurgery examinationSurgery)
        {
            if (!examinationSurgery.IsAlreadyStarted())
                return examinationSurgeryRepository.Create(examinationSurgery);
            return GetCurrentExamination(examinationSurgery.MedicalRecord.Id);
        }

        public ExaminationSurgery GetExaminationSurgery(int id) => 
            examinationSurgeryRepository.GetObject(id);

        public IEnumerable<ExaminationSurgery> GetAllBy(Doctor doctor) => 
            examinationSurgeryRepository.GetAllBy(doctor);

        public IEnumerable<ExaminationSurgery> GetAllBy(MedicalRecord record) => 
            examinationSurgeryRepository.GetAllBy(record);  
        public ExaminationSurgery GetLastExamination(MedicalRecord medicalRecord)
        {
            var allForOneRecord = GetAllBy(medicalRecord).ToList();
            if (allForOneRecord.Count > 0)
            {
                ExaminationSurgery lastExamination = allForOneRecord[0];
                foreach (ExaminationSurgery examinationSurgery in allForOneRecord)
                    if (examinationSurgery.IsExaminationBefore(lastExamination.StartTime))
                        lastExamination = examinationSurgery;
                return lastExamination;
            }
            throw new EntityNotFound();
        }
        public ExaminationSurgery GetCurrentExamination(int idRecord)
        {
            return examinationSurgeryRepository.GetAll().SingleOrDefault(entity =>
                entity.MedicalRecord.Id == idRecord && entity.IsAlreadyStarted());
        }
        public ExaminationSurgery UpdateTreatment(ExaminationSurgery examinationSurgery, Treatment treatment) =>
            examinationSurgeryRepository.UpdateTreatment(examinationSurgery, treatment);

        public ExaminationSurgery FinishExamination(ExaminationSurgery examinationSurgery) => 
            examinationSurgeryRepository.Update(examinationSurgery);
      
        public IExaminationSurgeryRepository examinationSurgeryRepository;
   
   }
}