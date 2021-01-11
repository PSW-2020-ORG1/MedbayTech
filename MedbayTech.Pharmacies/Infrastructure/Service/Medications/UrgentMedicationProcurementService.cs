using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Medications;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Pharmacies.Infrastructure.Service.Medications
{
    public class UrgentMedicationProcurementService : IUrgentMedicationProcurementService
    {
        private readonly IUrgentMedicationProcurementRepository _repository;

        public UrgentMedicationProcurementService(IUrgentMedicationProcurementRepository repository)
        {
            _repository = repository;
        }

        public UrgentMedicationProcurement Add(UrgentMedicationProcurement procurement) => _repository.Create(procurement);

        public bool Remove(UrgentMedicationProcurement procurement) => _repository.Delete(procurement);

        public UrgentMedicationProcurement Update(UrgentMedicationProcurement procurement) => _repository.Update(procurement);

        public UrgentMedicationProcurement Get(int id) => _repository.GetBy(id);
        public List<UrgentMedicationProcurement> GetAll() => _repository.GetAll();
    }
}
