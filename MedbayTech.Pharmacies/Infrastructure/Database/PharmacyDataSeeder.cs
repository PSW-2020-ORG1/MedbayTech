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
            context.Add(new Pharmacy { Id = "Jankovic", APIKey = "ID1APIKEYAAAA", APIEndpoint = "jankovic.rs", RecieveNotificationFrom = true });
            context.Add(new Pharmacy { Id = "Liman", APIKey = "ID2APIKEYAAAA", APIEndpoint = "liman.li", RecieveNotificationFrom = true });
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