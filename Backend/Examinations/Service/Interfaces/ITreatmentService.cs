using Backend.Examinations.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Examinations.Service.Interfaces
{
    public interface ITreatmentService
    {
        public Treatment CreateTreatment(Treatment treatment);
        public Treatment UpdateTreatment(Treatment treatment);
        public bool DeleteTreatment(Treatment treatment);
        public IEnumerable<HospitalTreatment> GetUnapprovedHospitalTreatments();
        public IEnumerable<Prescription> GetAllPrescriptions() ;
        public IEnumerable<Prescription> GetAllPrescriptionsInPeriodOfTime(DateTime startDate, DateTime endDate);
        public HospitalTreatment ApproveHospitalTreatment(HospitalTreatment hospitalTreatment);
        public HospitalTreatment RejectHospitalTreatment(HospitalTreatment hospitalTreatment);
    }
}
