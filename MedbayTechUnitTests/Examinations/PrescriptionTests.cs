using Backend.Examinations.Model;
using Backend.Examinations.WebApiController;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

using Backend.Users.Repository;
using Model.Users;
using Backend.Examinations.Repository;
using Moq;
using Backend.Examinations.Model.Enums;
using Backend.Medications.Model;
using Backend.Examinations.WebApiService;
using WebApplication.DTO;

namespace MedbayTechUnitTests.Examinations
{
    public class PrescriptionTests
    {
        [Fact]
        public void Search_advanced_prescriptions_integration()
        {
            throw new NotImplementedException(); 
        }

        [Fact]
        public void Search_advanced_prescription_unit()
        {
            var stubRepository = CreateStubRepository();
            PrescriptionAdvancedDTO dto = new PrescriptionAdvancedDTO();
            PrescriptionWebService service = new PrescriptionWebService(stubRepository);

            List<Prescription> prescriptions = service.AdvancedSearchPrescriptions(dto);

            prescriptions.ShouldNotBeNull();

            
        }

        public static IPrescriptionRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPrescriptionRepository>();
            var medication = new Medication
            {
                Id = 1,
                Med = "Brufen"

            };

            var prescription = new Prescription
            {
                Id = 1,
                Reserved = true,
                HourlyIntake = "3",
                MedicationId = 1,
                AdditionalNotes = "svasta nesto",
                Date = new DateTime(),
                ExaminationSurgeryId = 3,
                Type = TreatmentType.Prescription,
                Medication = medication
                
            };

            var prescription2 = new Prescription
            {
                Id = 2,
                Reserved = false,
                HourlyIntake = "7",
                MedicationId = 1,
                AdditionalNotes = "svasta nesto",
                Date = new DateTime(),
                ExaminationSurgeryId = 3,
                Type = TreatmentType.Prescription,
                Medication = medication
            };

            

            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions.Add(prescription);
            prescriptions.Add(prescription2);

            stubRepository.Setup(p => p.GetAll()).Returns(prescriptions);
            
            

            return stubRepository.Object;
        }

        
    }
}
