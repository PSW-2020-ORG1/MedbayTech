using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Application.DTO.Report
{
    public class DiagnosisDTO
    {
        public String Name { get; set; }
        public List<String> Symptoms {get;set;}

        public DiagnosisDTO() { }
        public DiagnosisDTO(String name, List<String> symptoms) 
        {
            this.Name = name;
            this.Symptoms = symptoms;
        }
    }
}
