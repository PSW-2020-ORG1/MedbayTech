using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyIntegration.Model;
using PharmacyIntegration.Service;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly MySqlContext dbContext;

        public PharmacyController(MySqlContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id?}")]
        public IActionResult GetPharmacyAPIKeyById(string id)
        {
            string api_key = PharmacyService.GetPharmacyAPIById(id);
            if (api_key.Equals(""))
                return NotFound();
            else
                return Ok(api_key);
        }

        [HttpPost]
        public IActionResult AddNewPharmacyAPIKey(Pharmacy pharmacy)
        {
            bool isSuccessfullyAdded = PharmacyService.AddPharmacyAPIKey(pharmacy);
            if (isSuccessfullyAdded)
                return Ok();
            else
                return BadRequest();
        }
        /*
        [HttpGet]
        public IActionResult GetAllPharmaciesAPIkeys()
        {
            List<Pharmacy> pharmacies = PharmacyService.GetAllPharmaciesAPIKeys();
            if (pharmacies.Count < 1)
                return NotFound();
            else
                return Ok(pharmacies);
        }*/
    }
}