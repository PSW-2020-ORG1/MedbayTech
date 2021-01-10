
using MedbayTech.Medications.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Medications.Domain.Entities.Medications;
using MedbayTech.Medications.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MedbayTech.Medications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : Controller
    {
        private List<Domain.Entities.Medications.Medication> _inMemoryRepo;
        private readonly IMedicationService _medicationService;
        public MedicationController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
            _inMemoryRepo = new List<Domain.Entities.Medications.Medication>();

            MedicationCategory category = new MedicationCategory("Drug");
            Domain.Entities.Medications.Medication aspirin = new Domain.Entities.Medications.Medication("Aspirin 325mg", "Bayer", category);
            aspirin.Id = 1;
            Domain.Entities.Medications.Medication cyclopentanoperhydrophenanthrene = new Domain.Entities.Medications.Medication("Cyclopentanoperhydrophenanthrene 5mg", "StrongDrugs Inc.", category);
            cyclopentanoperhydrophenanthrene.Id = 2;
            _inMemoryRepo.Add(aspirin);
            _inMemoryRepo.Add(cyclopentanoperhydrophenanthrene);
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int id)
        {
            Domain.Entities.Medications.Medication medication = _inMemoryRepo.Find(m => m.Id.Equals(id));
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

            //string response = grpc.CheckForMedication(search).Result;
            //return Ok(response);
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_medicationService.GetAll());
        }

        [HttpGet("{textBoxSearch?}/{medicationSearch?}")]
        public IActionResult Get(string textBoxSearch, MedicationSearch medicationSearch)
        {
            if (medicationSearch == MedicationSearch.ByNameOrId)
            {
                return Ok(_medicationService.GetAllMedicationsByNameOrId(textBoxSearch.ToLower().Trim()));
            }
            else if (medicationSearch == MedicationSearch.ByRoomId)
            {
                return Ok(_medicationService.GetAllMedicationByRoomId(textBoxSearch));
            }
            else return Ok();
        }

        [HttpPost]
        public IActionResult Post(Domain.Entities.Medications.Medication medication)
        {
            return Ok(_medicationService.UpdateMedication(medication));
        }
    }
}
