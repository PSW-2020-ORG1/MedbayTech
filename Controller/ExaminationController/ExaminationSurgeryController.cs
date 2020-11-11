// File:    ExaminationSurgeryController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 3:29:30 AM
// Purpose: Definition of Class ExaminationSurgeryController

using Examinations;
using Model.MedicalRecord;
using Model.Users;
using Service.ExaminationService;
using System;
using System.Collections.Generic;

namespace Controller.ExaminationController
{
   public class ExaminationSurgeryController
   {
        public ExaminationSurgeryController(ExaminationSurgeryService examinationSurgeryService)
        {
            this.examinationSurgeryService = examinationSurgeryService;
        }

        public ExaminationSurgery CreateExaminationSurgery(ExaminationSurgery examinationSurgery) => examinationSurgeryService.CreateExaminationSurgery(examinationSurgery);
        public ExaminationSurgery GetExaminationSurgery(int id) => examinationSurgeryService.GetExaminationSurgery(id);
        public IEnumerable<ExaminationSurgery> GetAllByDoctor(Doctor doctor) => examinationSurgeryService.GetAllByDoctor(doctor);
        public IEnumerable<ExaminationSurgery> GetAllByRecord(MedicalRecord record) => examinationSurgeryService.GetAllByRecord(record);
        public ExaminationSurgery GetLastExamination(MedicalRecord medicalRecord) => examinationSurgeryService.GetLastExamination(medicalRecord);
        public ExaminationSurgery UpdateTreatment(ExaminationSurgery examinationSurgery, Treatment treatment) => examinationSurgeryService.UpdateTreatment(examinationSurgery, treatment);
        public ExaminationSurgery FinishExamination(ExaminationSurgery examinationSurgery) => examinationSurgeryService.FinishExamination(examinationSurgery);
        public ExaminationSurgery GetCurrentExamination(int idRecord) => examinationSurgeryService.GetCurrentExamination(idRecord);

        public ExaminationSurgeryService examinationSurgeryService;
     
   }
}