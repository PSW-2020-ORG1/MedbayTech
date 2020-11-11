// File:    TreatmentFactory.cs
// Author:  Vlajkov
// Created: Monday, June 01, 2020 9:31:29 PM
// Purpose: Definition of Class TreatmentFactory

using System;

namespace Backend.Examinations.Model
{
   public class TreatmentFactory
   {
        public static Treatment CreateTreatment(TreatmentForm filledForm)
        {
            if (filledForm.TreatmentType == TreatmentType.labTestType)
            {
                return new LabTesting(filledForm.DateOfExamination, filledForm.LabTestTypes);
            } else if (filledForm.TreatmentType == TreatmentType.prescription)
            {
                return new Prescription(filledForm.DateOfExamination, filledForm.Flag, 
                    filledForm.Intake, filledForm.AdditionalNotes, filledForm.Medications);
            } else if (filledForm.TreatmentType == TreatmentType.hospitalTreatment)
            {
                return new HospitalTreatment(filledForm.AdditionalNotes, filledForm.StartDate, 
                    filledForm.EndDate, filledForm.Department);
            } else
            {
                return null;
            }
        }
   
   }
}