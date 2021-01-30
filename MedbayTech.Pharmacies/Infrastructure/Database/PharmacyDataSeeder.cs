using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Pharmacies.Infrastructure.Database
{
    public class PharmacyDataSeeder
    {
        public PharmacyDataSeeder() { }

        public void SeedAllEntities(PharmacyDbContext context)
        {
            SeedPharmacies(context);
            SeedPharmacyNotification(context);
            // TODO(Jovan): Remove once MedbayTech.Medication is fully finished
            /*SeedMedicationCategory(context);
            SeedMedicationIngredient(context);
            SeedMedication(context);
            SeedMedicationUsage(context);*/
            SeedUrgentMedicationProcurement(context);
        }
        private void SeedPharmacyNotification(PharmacyDbContext context)
        {
            context.Add(new PharmacyNotification { Content = "Lexapro on sale! Get 15% off!", Approved = true, PharmacyId = "Jankovic" });
            context.Add(new PharmacyNotification { Content = "Aspirin on sale! Get 11% off!", Approved = true, PharmacyId = "Liman" });
            context.SaveChanges();
        }

        private void SeedPharmacies(PharmacyDbContext context)
        {
            context.Add(new Pharmacy { Id = "Jankovic", APIKey = "ID1APIKEYAAAA", APIEndpoint = "jankovic.rs", Email = "jankovicpharmacy@gmail.com", RecieveNotificationFrom = true });
            context.Add(new Pharmacy { Id = "Liman", APIKey = "ID2APIKEYAAAA", APIEndpoint = "liman.li", Email = "pharmacyliman@gmail.com", RecieveNotificationFrom = true });
            context.Add(new Pharmacy { Id = "SchanelRemote", APIKey = "ID3APIKEYAAAA", APIEndpoint = "http://schnabel.herokuapp.com/pswapi/drugs/name/", Email = "schnabel@gmail.com", RecieveNotificationFrom = true });
            context.Add(new Pharmacy { Id = "SchanelLocal", APIKey = "ID4APIKEYAAAA", APIEndpoint = "http://localhost:6565", Email = "schnabel@gmail.com", RecieveNotificationFrom = true });
            context.SaveChanges();
        }

        private void SeedUrgentMedicationProcurement(PharmacyDbContext context)
        {
            context.Add(new UrgentMedicationProcurement
            {
                MedicationName = "Brufen",
                MedicationDosage = "600mg",
                MedicationQuantity = 5
            });

            context.SaveChanges();
        }

        public bool IsAlreadyFull(PharmacyDbContext context) =>
            context.Pharmacies.Count() > 0;
    }
}