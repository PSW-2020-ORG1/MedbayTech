using Backend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public string FirstOperand { get; set; }
        public string AndOr { get; set; }
        public string SecondOperand { get; set; }
        public string Type { get; set; }
        
        public PrescriptionDTO(int id, string first, string second, string operators, string type)
        {
            this.Id = id;
            this.FirstOperand = first;
            this.SecondOperand = second;
            this.AndOr = operators;
            this.Type = type;
           
        }
    }
}
