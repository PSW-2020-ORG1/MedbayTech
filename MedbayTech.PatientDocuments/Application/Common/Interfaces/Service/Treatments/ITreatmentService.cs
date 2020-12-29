using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using System;
using System.Collections.Generic;


namespace Backend.Examinations.Service.Interfaces
{
    public interface ITreatmentService
    {
        Treatment CreateTreatment(Treatment treatment);
        Treatment UpdateTreatment(Treatment treatment);
        bool DeleteTreatment(Treatment treatment);
        List<HospitalTreatment> GetUnapprovedHospitalTreatments();
        List<Prescription> GetAllPrescriptions() ;
        List<Prescription> GetAllPrescriptionsInPeriodOfTime(DateTime startDate, DateTime endDate);
        HospitalTreatment ApproveHospitalTreatment(HospitalTreatment hospitalTreatment);
        HospitalTreatment RejectHospitalTreatment(HospitalTreatment hospitalTreatment);
    }
}
