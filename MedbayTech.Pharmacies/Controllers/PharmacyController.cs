
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

        //[HttpGet("check/{search?}")]
        //public IActionResult GetGrpc(string search)
        //{
        //    GrpcClient grpc = new GrpcClient();
        //    string hello = grpc.Echo(pharmacy).Result;

        //    // TODO(Jovan): Add environment dependant support
        //    if (hello.ToLower().Equals("hello!"))
        //    {
        //        string response = grpc.CheckForMedication(search, pharmacy).Result;
        //        return Ok(response);
        //    }
        //    return NotFound();
        //    //string response = grpc.CheckForMedication(search).Result;
        //    //return Ok(response);
        //    //return Ok();
        //}

        [HttpGet("available/{search?}")]
        public IEnumerable<string> GetAvailable(string search)
        {
            List<Pharmacy> pharmacies = _pharmacyService.GetAll();
            List<string> retPharmacies = new List<string>();
            GrpcClient grpc = new GrpcClient();
            foreach (Pharmacy pharmacy in pharmacies)
            {
                try
                {
                    string hello = grpc.Echo(pharmacy).Result;

                    if (hello.ToLower().Equals("hello!"))
                    {
                        string response = grpc.CheckForMedication(search, pharmacy).Result;
                        if(response.Equals("We have the desired medication!"))
                        {
                            retPharmacies.Add(pharmacy.Id);
                        }
                    }
                }
                catch(Exception)
                {
                    try
                    {
                        using HttpClient client = new HttpClient();

                        var task = client.GetAsync(pharmacy.APIEndpoint + "/" + search)
                            .ContinueWith((taskWithResponse) =>
                            {
                                var message = taskWithResponse.Result;
                                var json = message.Content.ReadAsStringAsync();
                                json.Wait();
                                string response = json.Result;
                                if (response.Equals("We have the desired medication!"))
                                {
                                    retPharmacies.Add(pharmacy.Id);
                                }
                            });
                        task.Wait();
                    }
                    catch(Exception)
                    {
                    }
                }
            }
            return retPharmacies;
        }



    }
}