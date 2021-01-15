﻿using MedbayTech.Medications.Domain.Entities.Medications;
using MedbayTech.Medications.Domain.Entities.Reports;
using MedbayTech.Medications.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Medications.Infrastructure.Database
{
    public class MedicationDataSeeder
    {
        public MedicationDataSeeder() { }

        public void SeedAllEntities(MedicationDbContext context)
        {
            SeedMedicationCategory(context);
            SeedMedicationIngredient(context);
            SeedMedication(context);
            SeedMedicationUsage(context);
            SeedDosageOfIngredient(context);
        }

        private void SeedMedicationUsage(MedicationDbContext context)
        {
            context.Add(new MedicationUsage { Usage = 4, MedicationId = 1, Date = new DateTime(2020, 8, 1) });
            context.Add(new MedicationUsage { Usage = 10, MedicationId = 2, Date = new DateTime(2020, 9, 1) });
            context.Add(new MedicationUsage { Usage = 50, MedicationId = 1, Date = new DateTime(2020, 1, 1) });
            context.Add(new MedicationUsage { Usage = 1, MedicationId = 2, Date = new DateTime(2020, 5, 1) });
            context.SaveChanges();
        }

        private void SeedMedicationCategory(MedicationDbContext context)
        {
            context.Add(new MedicationCategory { CategoryName = "Drug" });
            context.Add(new MedicationCategory { CategoryName = "Kategorija1" });
            context.SaveChanges();
        }

        private void SeedMedicationIngredient(MedicationDbContext context)
        {
            context.Add(new MedicationIngredient { Name = "Ibuprofen" });
            context.Add(new MedicationIngredient { Name = "Paracetamol" });
            context.SaveChanges();
        }

        private void SeedDosageOfIngredient(MedicationDbContext context)
        {
            context.Add(new DosageOfIngredient { Amount = 100.0, MedicationIngredientId = 1 });
            context.Add(new DosageOfIngredient { Amount = 120.0, MedicationIngredientId = 2 });
            context.SaveChanges();
        }

        private void SeedMedication(MedicationDbContext context)
        {
            context.Add(new Domain.Entities.Medications.Medication { Med = "Brufen", Dosage = "400mg", RoomId = 87, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Xanax", Dosage = "20mg", RoomId = 87, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Panadon", Dosage = "500mg", RoomId = 87, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Diazepam", Dosage = "30mg", RoomId = 87, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Andol", Dosage = "200mg", RoomId = 87, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Reglan", Dosage = "100mg", RoomId = 87, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Caffetin", Dosage = "400mg", RoomId = 87, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Plavix", Dosage = "50mg", RoomId = 87, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Ambien", Dosage = "25mg", RoomId = 87, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Ranisan", Dosage = "200mg", RoomId = 87, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 88, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Adderall", Dosage = "40mg", RoomId = 88, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 88, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 88, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Demerol", Dosage = "30mg", RoomId = 88, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "OxyCotin", Dosage = "40mg", RoomId = 88, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Percocet", Dosage = "60mg", RoomId = 88, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Ritalin", Dosage = "80mg", RoomId = 88, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Eritromicin", Dosage = "100mg", RoomId = 88, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Penicillin", Dosage = "200mg", RoomId = 88, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });

            context.Add(new Domain.Entities.Medications.Medication { Med = "Amoksicilin", Dosage = "150mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Cefaleksin", Dosage = "200mg", RoomId = 101, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Zoloft", Dosage = "500mg", RoomId = 101, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Lexilium", Dosage = "40mg", RoomId = 101, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Bensedin", Dosage = "50mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Benedril", Dosage = "50mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Letrox", Dosage = "100mg", RoomId = 101, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Claritin", Dosage = "25mg", RoomId = 101, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Flobian", Dosage = "500mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Lasix", Dosage = "75mg", RoomId = 101, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Brufen", Dosage = "200mg", RoomId = 100, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Xanax", Dosage = "40mg", RoomId = 100, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Panadon", Dosage = "200mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Diazepam", Dosage = "60mg", RoomId = 100, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Andol", Dosage = "400mg", RoomId = 100, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Adderall", Dosage = "80mg", RoomId = 100, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 100, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Demerol", Dosage = "30mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });

            context.Add(new Domain.Entities.Medications.Medication { Med = "Brufen", Dosage = "400mg", RoomId = 10, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Xanax", Dosage = "20mg", RoomId = 10, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Panadon", Dosage = "500mg", RoomId = 10, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Diazepam", Dosage = "30mg", RoomId = 10, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Andol", Dosage = "200mg", RoomId = 10, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Reglan", Dosage = "100mg", RoomId = 10, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Caffetin", Dosage = "400mg", RoomId = 10, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Plavix", Dosage = "50mg", RoomId = 10, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Ambien", Dosage = "25mg", RoomId = 10, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Ranisan", Dosage = "200mg", RoomId = 10, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 9, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Adderall", Dosage = "40mg", RoomId = 9, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 9, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 9, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Demerol", Dosage = "30mg", RoomId = 9, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "OxyCotin", Dosage = "40mg", RoomId = 9, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Percocet", Dosage = "60mg", RoomId = 9, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Ritalin", Dosage = "80mg", RoomId = 9, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Eritromicin", Dosage = "100mg", RoomId = 9, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Penicillin", Dosage = "200mg", RoomId = 9, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Amoksicilin", Dosage = "150mg", RoomId = 6, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Cefaleksin", Dosage = "200mg", RoomId = 6, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Zoloft", Dosage = "500mg", RoomId = 6, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Lexilium", Dosage = "40mg", RoomId = 6, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Bensedin", Dosage = "50mg", RoomId = 6, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Letrox", Dosage = "100mg", RoomId = 6, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Claritin", Dosage = "25mg", RoomId = 6, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Flobian", Dosage = "500mg", RoomId = 6, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Lasix", Dosage = "75mg", RoomId = 6, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Brufen", Dosage = "200mg", RoomId = 6, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Xanax", Dosage = "40mg", RoomId = 5, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Panadon", Dosage = "200mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Diazepam", Dosage = "60mg", RoomId = 5, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Andol", Dosage = "400mg", RoomId = 5, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Adderall", Dosage = "80mg", RoomId = 5, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 5, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Demerol", Dosage = "30mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Amoksicilin", Dosage = "250mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });

            context.Add(new Domain.Entities.Medications.Medication { Med = "Cefaleksin", Dosage = "100mg", RoomId = 51, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Zoloft", Dosage = "200mg", RoomId = 51, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Lexilium", Dosage = "80mg", RoomId = 51, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Bensedin", Dosage = "10mg", RoomId = 51, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Brufen", Dosage = "100mg", RoomId = 51, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Xanax", Dosage = "60mg", RoomId = 51, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Panadon", Dosage = "250mg", RoomId = 51, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Diazepam", Dosage = "800mg", RoomId = 51, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Andol", Dosage = "150mg", RoomId = 51, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Reglan", Dosage = "125mg", RoomId = 51, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Caffetin", Dosage = "200mg", RoomId = 61, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Plavix", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Ambien", Dosage = "50mg", RoomId = 61, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Ranisan", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Demerol", Dosage = "60mg", RoomId = 61, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "OxyCotin", Dosage = "25mg", RoomId = 61, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Percocet", Dosage = "30mg", RoomId = 61, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Ritalin", Dosage = "40mg", RoomId = 61, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Eritromicin", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });
            context.Add(new Domain.Entities.Medications.Medication { Med = "Penicillin", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1 });

            context.SaveChanges();
        }

        public bool IsAlreadyFull(MedicationDbContext context)
        {
            return context.Medications.Count() > 0;
        }
    }
}
