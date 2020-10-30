/***********************************************************************
 * Module:  ExaminationService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.ExaminationService
 ***********************************************************************/

using Model.ExaminationSurgery;
using Model.MedicalRecord;
using Model.Users;
using Repository.ExaminationRepository;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (!CheckIfAlreadyStartedExamining(examinationSurgery))
                return examinationSurgeryRepository.Create(examinationSurgery);
            else
                return GetCurrentExamination(examinationSurgery.MedicalRecord.IdRecord);
        }

        public bool CheckIfAlreadyStartedExamining(ExaminationSurgery examinationSurgery)
        {
            return examinationSurgeryRepository.GetAll().ToList().Any(entity => entity.StartTime.Date.CompareTo(DateTime.Today.Date) == 0
                && entity.MedicalRecord.IdRecord == examinationSurgery.MedicalRecord.IdRecord);
        }

        public ExaminationSurgery GetExaminationSurgery(int id) => examinationSurgeryRepository.GetObject(id);

        public IEnumerable<ExaminationSurgery> GetAllByDoctor(Doctor doctor) => examinationSurgeryRepository.GetAllByDoctor(doctor);

        public IEnumerable<ExaminationSurgery> GetAllByRecord(MedicalRecord record) => examinationSurgeryRepository.GetAllByRecord(record);  
        public ExaminationSurgery GetLastExamination(MedicalRecord medicalRecord)
        {
            var allForOneRecord = GetAllByRecord(medicalRecord).ToList();
            if (allForOneRecord.Count > 0)
            {
                return FindLast(allForOneRecord);
            }
            else
            {
                return null;
            }
        }
        public ExaminationSurgery GetCurrentExamination(int idRecord)
        {
            return examinationSurgeryRepository.GetAll().SingleOrDefault(entity =>
                entity.MedicalRecord.IdRecord == idRecord &&
                entity.StartTime.Date.CompareTo(DateTime.Today.Date) == 0);
        }

        private static ExaminationSurgery FindLast(List<ExaminationSurgery> allForOneRecord)
        {
            ExaminationSurgery lastExamination = allForOneRecord[0];
            foreach (ExaminationSurgery examinationSurgery in allForOneRecord)
            {
                if (lastExamination.StartTime.Date.CompareTo(examinationSurgery.StartTime.Date) < 0)
                {
                    lastExamination = examinationSurgery;
                }
            }
            return lastExamination;
        }

        public ExaminationSurgery UpdateTreatment(ExaminationSurgery examinationSurgery, Treatment treatment)
        {
            ExaminationSurgery examinationToUdate = examinationSurgeryRepository.GetObject(examinationSurgery.IdNumber);
            examinationToUdate.Treatments.Add(treatment);
            return examinationSurgeryRepository.Update(examinationToUdate);
        }

        public ExaminationSurgery FinishExamination(ExaminationSurgery examinationSurgery) => examinationSurgeryRepository.Update(examinationSurgery);
      
        public IExaminationSurgeryRepository examinationSurgeryRepository;
   
   }
}