using Backend.Medications.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Medications.Service
{
    public interface IMedicationService
    {
        Medication Add(Medication medication);
        bool DeleteMedication(Medication medication);
        Medication GetMedication(int id);
        IEnumerable<Medication> GetAll();
    }
}
