
using System;
using System.Collections.Generic;
using System.Net.Http;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Pharmacies;
using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
using MedbayTech.Pharmacies.gRPC;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MedbayTech.Pharmacies.Controllers
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


        [HttpGet("available/{search?}")]
        public IEnumerable<string> GetAvailable(string search)
        {
            List<string> retPharmacies = new List<string>();
            foreach (Pharmacy pharmacy in _pharmacyService.GetAll())
            {
                string stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";
                if (pharmacy.APIEndpoint.Contains("local") && stage.Contains("development"))
                {
                    if (CheckPharmacyGRPC(pharmacy, search) != null)
                        retPharmacies.Add(pharmacy.Id);
                }
                else
                {
                    if (CheckPharmacyHTTP(pharmacy, search) != null)
                        retPharmacies.Add(pharmacy.Id);
                }
            }
            return retPharmacies;
        }

        private Pharmacy CheckPharmacyGRPC(Pharmacy pharmacy, string search)
        {
            try
            {
                GrpcClient grpc = new GrpcClient();
                string hello = grpc.Echo(pharmacy).Result;
                if (hello.ToLower().Equals("hello!"))
                {
                    string response = grpc.CheckForMedication(search, pharmacy).Result;
                    if (response.Equals("We have the desired medication!"))
                    {
                        return pharmacy;
                    }
                }
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        private Pharmacy CheckPharmacyHTTP(Pharmacy pharmacy, string search)
        {
            var task = AskPharamcyHttp(pharmacy, search);
            task.Wait();
            if (task.Result == "We have the desired medication!")
                return pharmacy;
            else
                return null;
        }

        private async System.Threading.Tasks.Task<string> AskPharamcyHttp(Pharmacy pharmacy, string search)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(pharmacy.APIEndpoint + "/" + search);
                response.EnsureSuccessStatusCode();
                string rersponseBody = await response.Content.ReadAsStringAsync();
                return rersponseBody;
            }
            catch(Exception)
            {
                return null;
            }
        }



    }
}