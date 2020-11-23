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


namespace MedbayTechUnitTests.Examinations
{
    public class PrescriptionTests
    {
        [Fact]
        public void Get_all_prescriptions_integration()
        {
            PrescriptionWebController controller = new PrescriptionWebController();
            

            List<Prescription> registeredPatient = controller.GetAllPrescriptions().ToList();

            registeredPatient.ShouldNotBeEmpty();
        }

        
    }
}
