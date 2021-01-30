using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Domain.Entites
{
    public class Appointment
    {

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CancelationDate { get; set; }
        public bool CanceledByPatient { get; set; }
        public string PatientId { get; set; }
    }
}
