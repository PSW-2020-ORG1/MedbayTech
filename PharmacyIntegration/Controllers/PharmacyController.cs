using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyIntegration.Model;
using PharmacyIntegration.Repository;
using PharmacyIntegration.Service;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private MySqlContext Context;
        private PharmacyRepository pharmacyDAO;
        public PharmacyController(MySqlContext Context)
        {
            this.Context = Context;
            this.pharmacyDAO = new PharmacyRepository(Context);
        }

        [HttpGet("{id?}")]
        public IActionResult Get(string id)
        {
            
            return Ok(pharmacyDAO.Get(id));

        }

        [HttpGet]
        public IEnumerable<Pharmacy> Get()
        {
            return pharmacyDAO.GetAll();
        }

        [HttpPost]
        public IActionResult Post(Pharmacy pharmacy)
        {
            bool isSuccessfullyAdded = pharmacyDAO.Add(pharmacy);

            if (isSuccessfullyAdded)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if(pharmacyDAO.Remove(id))
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}