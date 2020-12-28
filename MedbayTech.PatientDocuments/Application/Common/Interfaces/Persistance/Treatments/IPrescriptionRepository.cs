using Backend.Examinations.Model;
using Repository;
using System.Collections.Generic;
using MedbayTech.Common.Repository;

namespace Backend.Examinations.Repository
{
    public interface IPrescriptionRepository : IRepository<Prescription, int>
    {
        List<Prescription> GetPrescriptionsFor(string idPatient);
        List<Prescription> GetPrescriptions();

    }
}
