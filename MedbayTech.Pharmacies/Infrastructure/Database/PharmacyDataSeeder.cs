using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;
using MedbayTech.Pharmacies.Domain.Enums;
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
            SeedTenders(context);
            SeedTenderMedications(context);
            SeedTenderOffers(context);
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

        private void SeedTenders(PharmacyDbContext context)
        {
            context.Add(new Tender
            {
                //Id = 1,
                StartDate = new DateTime(2020, 12, 30),
                EndDate = new DateTime(2021, 5, 1),
                TenderDescription = "Tender for Xanax, Diazepam, Panadon and Flobian",
                TenderStatus = TenderStatus.Active,
            });
            context.Add(new Tender
            {
                //Id = 2,
                StartDate = new DateTime(2020, 12, 15),
                EndDate = new DateTime(2021, 6, 1),
                TenderDescription = "Tender for Bensedin and Lexilium",
                TenderStatus = TenderStatus.Active,
            });
            context.Add(new Tender
            {
                //Id = 3,
                StartDate = new DateTime(2020, 12, 1),
                EndDate = new DateTime(2021, 1, 1),
                TenderDescription = "Tender for Adderall",
                TenderStatus = TenderStatus.Pending,
            });
            context.Add(new Tender
            {
                //Id = 4,
                StartDate = new DateTime(2020, 11, 15),
                EndDate = new DateTime(2021, 1, 2),
                TenderDescription = "Tender for Andol",
                TenderStatus = TenderStatus.Finished,
                WinnerTenderOfferId = 10
            });

            context.SaveChanges();
        }

        private void SeedTenderMedications(PharmacyDbContext context)
        {
            context.Add(new TenderMedication
            {
                MedicationId = 1,
                TenderID = 4,
                TenderMedicationQuantity = 100
            });
            context.Add(new TenderMedication
            {
                MedicationId = 2,
                TenderID = 4,
                TenderMedicationQuantity = 500
            });
            context.Add(new TenderMedication
            {
                MedicationId = 3,
                TenderID = 4,
                TenderMedicationQuantity = 300
            });
            context.Add(new TenderMedication
            {
                MedicationId = 7,
                TenderID = 4,
                TenderMedicationQuantity = 50
            });
            context.Add(new TenderMedication
            {
                MedicationId = 10,
                TenderID = 3,
                TenderMedicationQuantity = 100
            });
            context.Add(new TenderMedication
            {
                MedicationId = 11,
                TenderID = 3,
                TenderMedicationQuantity = 150
            });
            context.Add(new TenderMedication
            {
                MedicationId = 48,
                TenderID = 2,
                TenderMedicationQuantity = 169
            });
            context.Add(new TenderMedication
            {
                MedicationId = 36,
                TenderID = 1,
                TenderMedicationQuantity = 210
            });

            context.SaveChanges();
        }

        private void SeedTenderOffers(PharmacyDbContext context)
        {
            context.Add(new TenderOffer
            {
                //Id = 1,
                TenderId = 4,
                Pharmacy = "Jankovic",
                PharmacyEMail = "jankovic@gmail.com",
                TenderOfferPrice = 5858f
            });
            context.Add(new TenderOffer
            {
                //Id = 2,
                TenderId = 4,
                Pharmacy = "Benu",
                PharmacyEMail = "benu@gmail.com",
                TenderOfferPrice = 5600f
            });
            context.Add(new TenderOffer
            {
                //Id = 3,
                TenderId = 3,
                Pharmacy = "Jankovic",
                PharmacyEMail = "jankovic@gmail.com",
                TenderOfferPrice = 950f
            });
            context.Add(new TenderOffer
            {
                //Id = 4,
                TenderId = 3,
                Pharmacy = "Liman",
                PharmacyEMail = "Liman@gmail.com",
                TenderOfferPrice = 945f
            });
            context.Add(new TenderOffer
            {
                //Id = 5,
                TenderId = 2,
                Pharmacy = "Benu",
                PharmacyEMail = "benu@gmail.com",
                TenderOfferPrice = 500f
            });
            context.Add(new TenderOffer
            {
                //Id = 6,
                TenderId = 2,
                Pharmacy = "Liman",
                PharmacyEMail = "Liman@gmail.com",
                TenderOfferPrice = 600f
            });
            context.Add(new TenderOffer
            {
                //Id = 7,
                TenderId = 2,
                Pharmacy = "Benu",
                PharmacyEMail = "benu@gmail.com",
                TenderOfferPrice = 630f
            });
            context.Add(new TenderOffer
            {
                //Id = 8,
                TenderId = 2,
                Pharmacy = "Liman",
                PharmacyEMail = "Liman@gmail.com",
                TenderOfferPrice = 650f
            });
            context.Add(new TenderOffer
            {
                //Id = 9,
                TenderId = 1,
                Pharmacy = "Benu",
                PharmacyEMail = "benu@gmail.com",
                TenderOfferPrice = 300f
            });
            context.Add(new TenderOffer
            {
                //Id = 10,
                TenderId = 1,
                Pharmacy = "Liman",
                PharmacyEMail = "Liman@gmail.com",
                TenderOfferPrice = 240f
            });

            context.SaveChanges();
        }
        public bool IsAlreadyFull(PharmacyDbContext context)
        {
            return context.Tenders.Count() > 0;
        }
    }
}