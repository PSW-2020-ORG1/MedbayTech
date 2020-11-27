using Backend.Examinations.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Examinations.Repository
{
    public interface IPrescriptionRepository
    {
        IEnumerable<Prescription> GetAllPrescriptions();

        IEnumerable<Prescription> GetSearchedPresciptions();

        
      
    }
}
