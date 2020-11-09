// File:    TreatmentForm.cs
// Author:  Vlajkov
// Created: Monday, June 01, 2020 9:32:18 PM
// Purpose: Definition of Class TreatmentForm

using Model.MedicalRecord;
using Model.Medications;
using System;
using System.Collections.Generic;
using Model.Rooms;

namespace Model.ExaminationSurgery
{
   public class TreatmentForm
    {
        public int Id { get; set; }
        public TreatmentType TreatmentType { get; set; }
        public DateTime DateOfExamination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Flag { get; set; }
        public int Intake { get; set; }
        public virtual List<LabTestType> LabTestTypes { get; set; }
        public string AdditionalNotes { get; set; }
        public virtual List<Medication> Medications { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public TreatmentForm() 
        {
            Medications = new List<Medication>();
            LabTestTypes = new List<LabTestType>();
        }
        public TreatmentForm(DateTime dateOfExamination, TreatmentType type, DateTime start, DateTime end, 
            bool flag, List<LabTestType> labTypes, 
            List<Medication> medications, int intake, string additionalNotes, Department department)
        {
            DateOfExamination = dateOfExamination;
            TreatmentType = type;
            StartDate = start;
            EndDate = end;
            LabTestTypes = labTypes;
            Medications = medications;
            Flag = flag;
            Intake = intake;
            AdditionalNotes = additionalNotes;
            Department = department;
        }

        
    }
}