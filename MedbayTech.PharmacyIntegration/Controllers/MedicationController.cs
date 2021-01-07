
using System.Collections.Generic;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using Microsoft.AspNetCore.Mvc;
using PharmacyIntegration.gRPC;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : Controller
    {
        private List<Medication> _inMemoryRepo;

        public MedicationController()
        {
            _inMemoryRepo = new List<Medication>();

            MedicationCategory category = new MedicationCategory("Drug");
            Medication aspirin = new Medication("Aspirin 325mg", "Bayer", category);
            aspirin.Id = 1;
            Medication cyclopentanoperhydrophenanthrene = new Medication("Cyclopentanoperhydrophenanthrene 5mg", "StrongDrugs Inc.", category);
            cyclopentanoperhydrophenanthrene.Id = 2;
            _inMemoryRepo.Add(aspirin);
            _inMemoryRepo.Add(cyclopentanoperhydrophenanthrene);
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int id)
        {
            Medication medication = _inMemoryRepo.Find(m => m.Id.Equals(id));
            if (medication == null)
            {
                return BadRequest();
            }
            return Ok(medication);
        }

        [HttpGet]
        public IActionResult Get() => Ok(_inMemoryRepo);


        [HttpGet("check/{search?}")]
        public IActionResult Get(string search)
        {
            GrpcClient grpc = new GrpcClient();

            string response = grpc.CheckForMedication(search).Result;
            return Ok(response);
        }
    }
}
