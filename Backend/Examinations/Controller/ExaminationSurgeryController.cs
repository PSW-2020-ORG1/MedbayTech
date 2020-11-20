// File:    ExaminationSurgeryController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 3:29:30 AM
// Purpose: Definition of Class ExaminationSurgeryController

using Backend.Examinations.Model;
using Backend.Records.Model;
using Model.Users;
using Backend.Examinations.Service;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller
{
   public class ExaminationSurgeryController
   {
        public ExaminationSurgeryController(ExaminationSurgeryService examinationSurgeryService)
        {
            this.examinationSurgeryService = examinationSurgeryService;
        }

        public ExaminationSurgery CreateExaminationSurgery(ExaminationSurgery examinationSurgery) => 
            examinationSurgeryService.CreateExaminationSurgery(examinationSurgery);

        public ExaminationSurgery GetExaminationSurgery(int id) => 
            examinationSurgeryService.GetExaminationSurgery(id);

        public IEnumerable<ExaminationSurgery> GetAllBy(Doctor doctor) => 
            examinationSurgeryService.GetAllBy(doctor);

        public IEnumerable<ExaminationSurgery> GetAllBy(MedicalRecord record) => 
            examinationSurgeryService.GetAllBy(record);

        public ExaminationSurgery GetLastExamination(MedicalRecord medicalRecord) =>
            examinationSurgeryService.GetLastExamination(medicalRecord);

        public ExaminationSurgery UpdateTreatment(ExaminationSurgery examinationSurgery, Treatment treatment) => 
            examinationSurgeryService.UpdateTreatment(examinationSurgery, treatment);

        public ExaminationSurgery FinishExamination(ExaminationSurgery examinationSurgery) => 
            examinationSurgeryService.FinishExamination(examinationSurgery);

        public ExaminationSurgery GetCurrentExamination(int idRecord) => 
            examinationSurgeryService.GetCurrentExamination(idRecord);

        public ExaminationSurgeryService examinationSurgeryService;
     
   }
}