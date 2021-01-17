using MedbayTech.Medications.Application.Common.Interfaces.Peristance.Medications;
using MedbayTech.Medications.Domain.Entities.Medications;
using MedbayTech.Medications.Domain.Enums;
using MedbayTech.Medications.Infrastructure.Service.Medications;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MedbayTech.UnitTesting.Medications
{
    public class MedicationTests
    {
        [Theory]
        [MemberData(nameof(MedicationQueries))]
        public void Medicine_search(string query, bool isEmpty)
        {
            MedicationService medicationService = new MedicationService(CreateRepositoryStub());
            List<MedbayTech.Medications.Domain.Entities.Medications.Medication> medicines = medicationService.GetAllMedicationsByNameOrId(query);

            bool empty = !medicines.Any();
            empty.ShouldBe(isEmpty);
        }

        public static IEnumerable<object[]> MedicationQueries()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { "Diazepam", false });
            retVal.Add(new object[] { "44", false });
            retVal.Add(new object[] { "Lalala", true });
            return retVal;
        }

        public IMedicationRepository CreateRepositoryStub()
        {
            //var stubRepository = new Mock<IMedicationRepository>();
            // TODO(Jovan): Use gateway here?
            var stubRepository = new Mock<IMedicationRepository>();
            var medications = GetMedications().ToList();
            stubRepository.Setup(m => m.GetAll()).Returns(medications);
            return stubRepository.Object;
        }

        private static IEnumerable<MedbayTech.Medications.Domain.Entities.Medications.Medication> GetMedications()
        {
            var m1 = new MedbayTech.Medications.Domain.Entities.Medications.Medication { Id = 44, Med = "Diazepam", Dosage = "30mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>()/*, MedicationCategoryId = 1*/};
            var m2 = new MedbayTech.Medications.Domain.Entities.Medications.Medication { Id = 45, Med = "Andol", Dosage = "200mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>()/*, MedicationCategoryId = 1*/};
            var m3 = new MedbayTech.Medications.Domain.Entities.Medications.Medication { Id = 46, Med = "Reglan", Dosage = "100mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>() };

            var medications = new List<MedbayTech.Medications.Domain.Entities.Medications.Medication>();
            medications.Add(m1);
            medications.Add(m2);
            medications.Add(m3);
            return medications;
        }
    }
}