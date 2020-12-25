using Backend.Pharmacies.Model;
using Backend.Pharmacies.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcurementController : Controller
    {
        IUrgentMedicationProcurementService _service;

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
