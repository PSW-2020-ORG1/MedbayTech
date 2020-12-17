﻿using Backend.Examinations.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Examinations.Service.Interfaces
{
    public interface ITreatmentService
    {
        Treatment CreateTreatment(Treatment treatment);
        Treatment UpdateTreatment(Treatment treatment);
        bool DeleteTreatment(Treatment treatment);
        IEnumerable<HospitalTreatment> GetUnapprovedHospitalTreatments();
        IEnumerable<Prescription> GetAllPrescriptions() ;
        IEnumerable<Prescription> GetAllPrescriptionsInPeriodOfTime(DateTime startDate, DateTime endDate);
        HospitalTreatment ApproveHospitalTreatment(HospitalTreatment hospitalTreatment);
        HospitalTreatment RejectHospitalTreatment(HospitalTreatment hospitalTreatment);
    }
}
