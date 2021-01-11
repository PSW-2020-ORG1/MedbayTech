using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Contrllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcurementController : Controller
    {
        private readonly IUrgentMedicationProcurementService _service;

        public ProcurementController(IUrgentMedicationProcurementService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<UrgentMedicationProcurement> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public IActionResult SaveProcurement(UrgentMedicationProcurement procurement)
        {
            bool isSuccessfullyAdded = _service.Add(procurement) != null;

            if (isSuccessfullyAdded)
                return Ok();
            else
                return BadRequest();
        }

    }
}
