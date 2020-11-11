/***********************************************************************
 * Module:  ExaminationService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.ExaminationService
 ***********************************************************************/

using Backend.Examinations.Model;
using Model.MedicalRecord;
using Model.Users;
using Repository.ExaminationRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Exceptions.EntityNotFound;

namespace Service.ExaminationService
{
   public class ExaminationSurgeryService
   {
        public ExaminationSurgeryService(IExaminationSurgeryRepository examinationSurgeryRepository)
        {
            this.examinationSurgeryRepository = examinationSurgeryRepository;
        }

        public ExaminationSurgery CreateExaminationSurgery(ExaminationSurgery examinationSurgery)
        {
            if (!CheckIfStarted(examinationSurgery))
                return examinationSurgeryRepository.Create(examinationSurgery);
            else
                return GetCurrentExamination(examinationSurgery.MedicalRecord.Id);
        }

        public bool CheckIfStarted(ExaminationSurgery examinationSurgery)
        {
            return examinationSurgeryRepository.GetAll().ToList().Any(entity => entity.IfAlreadyStarted()
                && entity.MedicalRecord.Id == examinationSurgery.MedicalRecord.Id);
            
        }

        public ExaminationSurgery GetExaminationSurgery(int id) => examinationSurgeryRepository.GetObject(id);

        public IEnumerable<ExaminationSurgery> GetAllBy(Doctor doctor) => examinationSurgeryRepository.GetAllByDoctor(doctor);

        public IEnumerable<ExaminationSurgery> GetAllBy(MedicalRecord record) => examinationSurgeryRepository.GetAllByRecord(record);  
        public ExaminationSurgery GetLastExamination(MedicalRecord medicalRecord)
        {
            var allForOneRecord = GetAllBy(medicalRecord).ToList();
            if (allForOneRecord.Count > 0)
                return FindLast(allForOneRecord);
            throw new ExaminationNotFound();
        }
        public ExaminationSurgery GetCurrentExamination(int idRecord)
        {
            return examinationSurgeryRepository.GetAll().SingleOrDefault(entity =>
                entity.MedicalRecord.Id == idRecord &&
                entity.StartTime.Date.CompareTo(DateTime.Today.Date) == 0);
        }

        private ExaminationSurgery FindLast(List<ExaminationSurgery> allForOneRecord)
        {
            ExaminationSurgery lastExamination = allForOneRecord[0];
            foreach (ExaminationSurgery examinationSurgery in allForOneRecord)
            {
                if (examinationSurgery.IsExaminationBefore(lastExamination.StartTime))
                {
                    lastExamination = examinationSurgery;
                }
            }
            return lastExamination;
        }

        public ExaminationSurgery UpdateTreatment(ExaminationSurgery examinationSurgery, Treatment treatment)
        {
            ExaminationSurgery examinationToUpdate = examinationSurgeryRepository.GetObject(examinationSurgery.Id);
            examinationToUpdate.Treatments.Add(treatment);
            return examinationSurgeryRepository.Update(examinationToUpdate);
        }

        public ExaminationSurgery FinishExamination(ExaminationSurgery examinationSurgery) => examinationSurgeryRepository.Update(examinationSurgery);
      
        public IExaminationSurgeryRepository examinationSurgeryRepository;
   
   }
}