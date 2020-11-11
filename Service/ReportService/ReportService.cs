// File:    ReportService.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 7:03:27 AM
// Purpose: Definition of Class ReportService

using Examinations;
using Model.Medications;
using Model.Reports;
using Model.Rooms;
using Repository.ExaminationRepository;
using Repository.MedicationRepository;
using Repository.ReportRepository;
using Repository.RoomRepository;
using System;
using System.Linq;

namespace Service.ReportService
{
   public class ReportService
   {
        public ReportService(IReportRepository reportRepository, ITreatmentRepository treatmentRepository, 
            IMedicationRepository medicationRepository, IExaminationSurgeryRepository examinationSurgeryRepository, 
            IRoomRepository roomRepository)
        {
            this.reportRepository = reportRepository;
            this.treatmentRepository = treatmentRepository;
            this.medicationRepository = medicationRepository;
            this.examinationSurgeryRepository = examinationSurgeryRepository;
            this.roomRepository = roomRepository;
        }
        public MedicationConsumptionReport GenerateMedicalConsumptionReport(DateTime startDate, DateTime endDate, Medication medication)
        {
            var allPrescriptions = treatmentRepository.GetAllPrescriptions().ToList().Where(entity => entity.Medications.Any(entity1 => entity1.Id == medication.Id)).ToList();
            var inPeriodOfTime = allPrescriptions.Where(entity => entity.Date.CompareTo(startDate) >= 0 && entity.Date.CompareTo(endDate) <= 0).ToList();
            MedicationConsumptionReport report = new MedicationConsumptionReport(DateTime.Today, startDate, endDate, inPeriodOfTime);
            return report;
        }
      
        public RoomReport GenerateRoomReport(Room room)
        {
             throw new NotImplementedException();
        }
      
        public MedicationInStorageReport GenerateMedicaionReport(Medication medication)
        {
             throw new NotImplementedException();
        } 
      
        public WeeklyAppointmentReport GenerateWeeklyAppointmentsReport(DateTime startDate)
        {
             throw new NotImplementedException();
        }
      
        public DoctorsAppointmentReport GenerateExaminationReport(ExaminationSurgery examination)
        {
            DoctorsAppointmentReport report = new DoctorsAppointmentReport(examination, DateTime.Today);
            return report;
        }
      
        public IReportRepository reportRepository;
        public ITreatmentRepository treatmentRepository;
        public IMedicationRepository medicationRepository;
        public IExaminationSurgeryRepository examinationSurgeryRepository;
        public IRoomRepository roomRepository;
   
   }
}