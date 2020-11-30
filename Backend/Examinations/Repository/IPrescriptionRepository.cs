using Backend.Examinations.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Examinations.Repository
{
    public interface IPrescriptionRepository : IRepository<Prescription, int>
    {
        IEnumerable<Prescription> GetPrescriptionsFor(string idPatient);
        
        
    }
}
