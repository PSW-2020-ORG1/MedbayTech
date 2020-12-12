using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Medications.Model;
using Backend.Medications.Service;
using Microsoft.AspNetCore.Mvc;
using Model.Users;

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


            Specialization specialization = new Specialization(1, "DrugSpec");
            MedicationCategory category = new MedicationCategory("Drug", specialization);
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
    }
}
