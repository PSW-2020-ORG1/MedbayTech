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
        private MySqlDbContext Context;
        private PharmacyDAO pharmacyDAO;
        public PharmacyController(MySqlDbContext Context)
        {
            this.Context = Context;
            this.pharmacyDAO = new PharmacyDAO(Context);
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
        public IActionResult AddNewPharmacyAPIKey(Pharmacy pharmacy)
        {
            bool isSuccessfullyAdded = pharmacyDAO.Add(pharmacy);

            if (isSuccessfullyAdded)
                return Ok();
            else
                return BadRequest();
        }
    }
}