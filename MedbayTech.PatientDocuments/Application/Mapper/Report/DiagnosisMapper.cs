using MedbayTech.PatientDocuments.Application.DTO.Report;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Application.Mapper.Report
{
    public class DiagnosisMapper
    {
        public static DiagnosisDTO DiagnosisToDiagnosisDTO(Diagnosis diagnosis)
        {
            string name = diagnosis.Name;
            List<string> symptomsNames = new List<string>();
            foreach (Symptoms symptoms in diagnosis.Symptoms) 
            {
                string symptomsName = symptoms.Name;
                symptomsNames.Add(symptomsName);
            }
            return new DiagnosisDTO(name, symptomsNames);
        }
    }
}
