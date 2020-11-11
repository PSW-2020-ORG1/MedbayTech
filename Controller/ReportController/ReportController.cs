// File:    ReportController.cs
// Author:  Vlajkov
// Created: Saturday, May 30, 2020 11:32:49 PM
// Purpose: Definition of Class ReportController

using Examinations;
using Model.Medications;
using Model.Reports;
using Model.Rooms;
using Service.ReportService;
using System;

namespace Controller.ReportController
{
   public class ReportController
   {
        public ReportController(ReportService reportService)
        {
            this.reportService = reportService;
        } 

        public MedicationConsumptionReport GenerateMedicalConsumptionReport(DateTime startDate, DateTime endDate, Medication med) => reportService.GenerateMedicalConsumptionReport(startDate, endDate, med);
        public RoomReport GenerateRoomReport(Room room) => reportService.GenerateRoomReport(room);
        public MedicationInStorageReport GenerateMedicaionReport(Medication medication) => reportService.GenerateMedicaionReport(medication);
        public WeeklyAppointmentReport GenerateWeeklyAppointmentsReport(DateTime startDate) => reportService.GenerateWeeklyAppointmentsReport(startDate);
        public DoctorsAppointmentReport GenerateExaminationReport(ExaminationSurgery examination) => reportService.GenerateExaminationReport(examination);

        public ReportService reportService;
     
   }
}