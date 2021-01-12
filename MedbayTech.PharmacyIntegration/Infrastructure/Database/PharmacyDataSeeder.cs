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
            SeedMedicationCategory(context);
            SeedMedicationIngredient(context);
            SeedMedication(context);
            SeedMedicationUsage(context);
            SeedMedicationUsage(context);
            SeedUrgentMedicationProcurement(context);
            SeedTenders(context);
            SeedTenderMedications(context);
            SeedTenderOffers(context);
        }

        private void SeedMedicationUsage(PharmacyDbContext context)
        {
            context.Add(new MedicationUsage { Usage = 4, MedicationId = 1, Date = new DateTime(2020, 8, 1) });
            context.Add(new MedicationUsage { Usage = 10, MedicationId = 2, Date = new DateTime(2020, 9, 1) });
            context.Add(new MedicationUsage { Usage = 50, MedicationId = 1, Date = new DateTime(2020, 1, 1) });
            context.Add(new MedicationUsage { Usage = 1, MedicationId = 2, Date = new DateTime(2020, 5, 1) });
            context.SaveChanges();
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

        private void SeedMedicationCategory(PharmacyDbContext context)
        {
            context.Add(new MedicationCategory { CategoryName = "Drug" });
            context.Add(new MedicationCategory { CategoryName = "Kategorija1" });
            context.SaveChanges();
        }
        private void SeedMedicationIngredient(PharmacyDbContext context)
        {
            context.Add(new MedicationIngredient { Name = "Ibuprofen" });
            context.Add(new MedicationIngredient { Name = "Paracetamol" });
            context.SaveChanges();
        }
        private void SeedDosageOfIngredient(PharmacyDbContext context)
        {
            context.Add(new DosageOfIngredient { Amount = 100.0, MedicationIngredientId = 1 });
            context.Add(new DosageOfIngredient { Amount = 120.0, MedicationIngredientId = 2 });
            context.SaveChanges();
        }

        private void SeedMedication(PharmacyDbContext context)
        {
            context.Add(new Medication { Med = "Brufen", Dosage = "400mg", RoomId = 87, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Xanax", Dosage = "20mg", RoomId = 87, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Panadon", Dosage = "500mg", RoomId = 87, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Diazepam", Dosage = "30mg", RoomId = 87, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Andol", Dosage = "200mg", RoomId = 87, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Reglan", Dosage = "100mg", RoomId = 87, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Caffetin", Dosage = "400mg", RoomId = 87, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Plavix", Dosage = "50mg", RoomId = 87, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Ambien", Dosage = "25mg", RoomId = 87, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Ranisan", Dosage = "200mg", RoomId = 87, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 88, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Adderall", Dosage = "40mg", RoomId = 88, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 88, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 88, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Demerol", Dosage = "30mg", RoomId = 88, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "OxyCotin", Dosage = "40mg", RoomId = 88, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Percocet", Dosage = "60mg", RoomId = 88, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Ritalin", Dosage = "80mg", RoomId = 88, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Eritromicin", Dosage = "100mg", RoomId = 88, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Penicillin", Dosage = "200mg", RoomId = 88, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });

            context.Add(new Medication { Med = "Amoksicilin", Dosage = "150mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Cefaleksin", Dosage = "200mg", RoomId = 101, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Zoloft", Dosage = "500mg", RoomId = 101, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Lexilium", Dosage = "40mg", RoomId = 101, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Bensedin", Dosage = "50mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Benedril", Dosage = "50mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Letrox", Dosage = "100mg", RoomId = 101, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Claritin", Dosage = "25mg", RoomId = 101, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Flobian", Dosage = "500mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Lasix", Dosage = "75mg", RoomId = 101, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Brufen", Dosage = "200mg", RoomId = 100, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Xanax", Dosage = "40mg", RoomId = 100, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Panadon", Dosage = "200mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Diazepam", Dosage = "60mg", RoomId = 100, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Andol", Dosage = "400mg", RoomId = 100, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Adderall", Dosage = "80mg", RoomId = 100, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 100, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Demerol", Dosage = "30mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });

            context.Add(new Medication { Med = "Brufen", Dosage = "400mg", RoomId = 10, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Xanax", Dosage = "20mg", RoomId = 10, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Panadon", Dosage = "500mg", RoomId = 10, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Diazepam", Dosage = "30mg", RoomId = 10, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Andol", Dosage = "200mg", RoomId = 10, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Reglan", Dosage = "100mg", RoomId = 10, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Caffetin", Dosage = "400mg", RoomId = 10, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Plavix", Dosage = "50mg", RoomId = 10, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Ambien", Dosage = "25mg", RoomId = 10, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Ranisan", Dosage = "200mg", RoomId = 10, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 9, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Adderall", Dosage = "40mg", RoomId = 9, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 9, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 9, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Demerol", Dosage = "30mg", RoomId = 9, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "OxyCotin", Dosage = "40mg", RoomId = 9, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Percocet", Dosage = "60mg", RoomId = 9, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Ritalin", Dosage = "80mg", RoomId = 9, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Eritromicin", Dosage = "100mg", RoomId = 9, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Penicillin", Dosage = "200mg", RoomId = 9, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Amoksicilin", Dosage = "150mg", RoomId = 6, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Cefaleksin", Dosage = "200mg", RoomId = 6, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Zoloft", Dosage = "500mg", RoomId = 6, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Lexilium", Dosage = "40mg", RoomId = 6, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Bensedin", Dosage = "50mg", RoomId = 6, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Letrox", Dosage = "100mg", RoomId = 6, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Claritin", Dosage = "25mg", RoomId = 6, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Flobian", Dosage = "500mg", RoomId = 6, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Lasix", Dosage = "75mg", RoomId = 6, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Brufen", Dosage = "200mg", RoomId = 6, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Xanax", Dosage = "40mg", RoomId = 5, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Panadon", Dosage = "200mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Diazepam", Dosage = "60mg", RoomId = 5, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Andol", Dosage = "400mg", RoomId = 5, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Adderall", Dosage = "80mg", RoomId = 5, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 5, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Demerol", Dosage = "30mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Amoksicilin", Dosage = "250mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });

            context.Add(new Medication { Med = "Cefaleksin", Dosage = "100mg", RoomId = 51, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Zoloft", Dosage = "200mg", RoomId = 51, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Lexilium", Dosage = "80mg", RoomId = 51, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Bensedin", Dosage = "10mg", RoomId = 51, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Brufen", Dosage = "100mg", RoomId = 51, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Xanax", Dosage = "60mg", RoomId = 51, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Panadon", Dosage = "250mg", RoomId = 51, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Diazepam", Dosage = "800mg", RoomId = 51, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Andol", Dosage = "150mg", RoomId = 51, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Reglan", Dosage = "125mg", RoomId = 51, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Caffetin", Dosage = "200mg", RoomId = 61, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Plavix", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Ambien", Dosage = "50mg", RoomId = 61, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Ranisan", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Demerol", Dosage = "60mg", RoomId = 61, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "OxyCotin", Dosage = "25mg", RoomId = 61, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1  });
            context.Add(new Medication { Med = "Percocet", Dosage = "30mg", RoomId = 61, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Ritalin", Dosage = "40mg", RoomId = 61, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Eritromicin", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Medication { Med = "Penicillin", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });

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
                Id = 1,
                StartDate = new DateTime(2020, 12, 30),
                EndDate = new DateTime(2021, 5, 1),
                TenderDescription = "Tender for Xanax, Diazepam, Panadon and Flobian",
                TenderStatus = TenderStatus.Active,
            });
            context.Add(new Tender
            {
                Id = 2,
                StartDate = new DateTime(2020, 12, 15),
                EndDate = new DateTime(2021, 6, 1),
                TenderDescription = "Tender for Bensedin and Lexilium",
                TenderStatus = TenderStatus.Active,
            });
            context.Add(new Tender
            {
                Id = 3,
                StartDate = new DateTime(2020, 12, 1),
                EndDate = new DateTime(2021, 1, 1),
                TenderDescription = "Tender for Adderall",
                TenderStatus = TenderStatus.Pendind,
            });
            context.Add(new Tender
            {
                Id = 4,
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
                TenderID = 1,
                TenderMedicationQuantity = 100
            });
            context.Add(new TenderMedication
            {
                MedicationId = 2,
                TenderID = 1,
                TenderMedicationQuantity = 500
            });
            context.Add(new TenderMedication
            {
                MedicationId = 3,
                TenderID = 1,
                TenderMedicationQuantity = 300
            });
            context.Add(new TenderMedication
            {
                MedicationId = 7,
                TenderID = 1,
                TenderMedicationQuantity = 50
            });
            context.Add(new TenderMedication
            {
                MedicationId = 10,
                TenderID = 2,
                TenderMedicationQuantity = 100
            });
            context.Add(new TenderMedication
            {
                MedicationId = 11,
                TenderID = 2,
                TenderMedicationQuantity = 150
            });
            context.Add(new TenderMedication
            {
                MedicationId = 48,
                TenderID = 3,
                TenderMedicationQuantity = 169
            });
            context.Add(new TenderMedication
            {
                MedicationId = 36,
                TenderID = 4,
                TenderMedicationQuantity = 210
            });

            context.SaveChanges();
        }

        private void SeedTenderOffers(PharmacyDbContext context)
        {
            context.Add(new TenderOffer
            {
                Id = 1,
                TenderId = 1,
                Pharmacy = "Jankovic",
                PharmacyEMail = "jankovic@gmail.com",
                TenderOfferPrice = 5858f
            });
            context.Add(new TenderOffer
            {
                Id = 2,
                TenderId = 1,
                Pharmacy = "Benu",
                PharmacyEMail = "benu@gmail.com",
                TenderOfferPrice = 5600f
            });
            context.Add(new TenderOffer
            {
                Id = 3,
                TenderId = 2,
                Pharmacy = "Jankovic",
                PharmacyEMail = "jankovic@gmail.com",
                TenderOfferPrice = 950f
            });
            context.Add(new TenderOffer
            {
                Id = 4,
                TenderId = 2,
                Pharmacy = "Liman",
                PharmacyEMail = "Liman@gmail.com",
                TenderOfferPrice = 945f
            });
            context.Add(new TenderOffer
            {
                Id = 5,
                TenderId = 3,
                Pharmacy = "Benu",
                PharmacyEMail = "benu@gmail.com",
                TenderOfferPrice = 500f
            });
            context.Add(new TenderOffer
            {
                Id = 6,
                TenderId = 3,
                Pharmacy = "Liman",
                PharmacyEMail = "Liman@gmail.com",
                TenderOfferPrice = 600f
            });
            context.Add(new TenderOffer
            {
                Id = 7,
                TenderId = 3,
                Pharmacy = "Benu",
                PharmacyEMail = "benu@gmail.com",
                TenderOfferPrice = 630f
            });
            context.Add(new TenderOffer
            {
                Id = 8,
                TenderId = 3,
                Pharmacy = "Liman",
                PharmacyEMail = "Liman@gmail.com",
                TenderOfferPrice = 650f
            });
            context.Add(new TenderOffer
            {
                Id = 9,
                TenderId = 4,
                Pharmacy = "Benu",
                PharmacyEMail = "benu@gmail.com",
                TenderOfferPrice = 300f
            });
            context.Add(new TenderOffer
            {
                Id = 10,
                TenderId = 4,
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