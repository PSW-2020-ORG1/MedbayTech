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
        private TreatmentType treatmentType;
        private DateTime dateOfExamination;
        private DateTime startDate;
        private DateTime endDate;
        private bool flag;
        private int intake;
        private List<LabTestType> labTestTypes;
        private string additionalNotes;
        private List<Medication> medication;
        private Department department;

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

        public TreatmentType TreatmentType { get => treatmentType; set => treatmentType = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public List<LabTestType> LabTestTypes { get => labTestTypes; set => labTestTypes = value; }
        public List<Medication> Medications { get => medication; set => medication = value; }
        public DateTime DateOfExamination { get => dateOfExamination; set => dateOfExamination = value; }
        public bool Flag { get => flag; set => flag = value; }
        public int Intake { get => intake; set => intake = value; }
        public string AdditionalNotes { get => additionalNotes; set => additionalNotes = value; }
        public Department Department { get => department; set => department = value; }
    }
}