using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using PharmacyIntegration.Model;
using PharmacyIntegration.Repository;
using PharmacyIntegration.Service;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private IPharmacyService _pharmacyService;
        public PharmacyController(IPharmacyService service)
        {
            this._pharmacyService = service;
        }

        [HttpGet("{id?}")]
        public IActionResult Get(string id)
        {
            
            return Ok(_pharmacyService.Get(id));

        }

        [HttpGet]
        public IEnumerable<Pharmacy> Get()
        {
            return _pharmacyService.GetAll();
        }

        [HttpPost]
        public IActionResult Post(Pharmacy pharmacy)
        {
            bool isSuccessfullyAdded = _pharmacyService.Add(pharmacy) != null;

            if (isSuccessfullyAdded)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult ChangeSendNotificationPermision(Pharmacy pharmacy)
        {
            bool isSuccessfullyAdded = _pharmacyService.Update(pharmacy) != null;

            if (isSuccessfullyAdded)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if(_pharmacyService.Remove(_pharmacyService.Get(id)))
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}