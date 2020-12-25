using Backend.Pharmacies.Model;
using Backend.Pharmacies.Service.Interfaces;
using PharmacyIntegration.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Pharmacies.Service
{
    public class UrgentMedicationProcurementService : IUrgentMedicationProcurementService
    {
        private IUrgentMedicationProcurementRepository _repository;

        public UrgentMedicationProcurementService(IUrgentMedicationProcurementRepository repository)
        {
            _repository = repository;
        }

        public UrgentMedicationProcurement Add(UrgentMedicationProcurement procurement) => _repository.Create(procurement);

        public bool Remove(UrgentMedicationProcurement procurement) => _repository.Delete(procurement);

        public UrgentMedicationProcurement Update(UrgentMedicationProcurement procurement) => _repository.Update(procurement);

        public UrgentMedicationProcurement Get(int id) => _repository.GetObject(id);
        public List<UrgentMedicationProcurement> GetAll() => _repository.GetAll();
    }
}
