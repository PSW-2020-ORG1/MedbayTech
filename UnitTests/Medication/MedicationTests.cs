using Model.Rooms;
using Moq;
using System.Collections.Generic;
using Service.RoomService;
using Shouldly;
using Xunit;
using System.Linq;
using Repository.RoomRepository;
using Backend.Medications.Service;
using Backend.Medications.Model;
using Backend.Medications.Repository.FileRepository;

namespace MedbayTechUnitTests
{
    public class MedicationTests
    {

        [Theory]
        [MemberData(nameof(MedicationQueries))]
        public void Medicine_search ( string query, bool isEmpty )
        {
            MedicationService medicationService = new MedicationService(CreateRepositoryStub());
            List<Medication> medicines = medicationService.GetAllMedicationsByNameOrId(query);

            bool empty = !medicines.Any();
            empty.ShouldBe(isEmpty);
        }

        public static IEnumerable<object[]> MedicationQueries ( )
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { "Diazepam", false });
            retVal.Add(new object[] { "44", false });
            retVal.Add(new object[] { "Lalala", true });
            return retVal;
        }

        public IMedicationRepository CreateRepositoryStub ( )
        {
            var stubRepository = new Mock<IMedicationRepository>();
            var medications = GetMedications();
            stubRepository.Setup(m => m.GetAll()).Returns(medications);
            return stubRepository.Object;
        }

        private static IEnumerable<Medication> GetMedications ( )
        {
            var m1 = new Medication { Id = 44, Med = "Diazepam", Dosage = "30mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() };
            var m2 = new Medication { Id = 45, Med = "Andol", Dosage = "200mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() };
            var m3 = new Medication { Id = 46, Med = "Reglan", Dosage = "100mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() };

            var medications = new List<Medication>();
            medications.Add(m1);
            medications.Add(m2);
            medications.Add(m3);
            return medications;
        }
    }
}