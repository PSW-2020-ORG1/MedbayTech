using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Pharmacies;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
using MedbayTech.Pharmacies.gRPC;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Mailing;
using MedbayTech.Pharmacies.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Contrllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcurementController : Controller
    {
        private readonly IUrgentMedicationProcurementService _service;
        private readonly IMailService _mailService;
        private readonly IPharmacyService _pharmacyService;

        public ProcurementController(IUrgentMedicationProcurementService service, IMailService mailService, IPharmacyService pharmacyService)
        {
            _service = service;
            _mailService = mailService;
            _pharmacyService = pharmacyService;
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
            {
                SendMail();
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpGet("send/{pro?}/{phar}")]
        public IActionResult SendProcurment(int pro, string phar)
        {
            string stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";
            if (phar.ToLower().Contains("local") && stage.Contains("development"))
            {
                return SendProcurementGRPC(pro, phar);
            }
            else
            {
                return SendProcurementHTTP(pro, phar);
            }
        }

        private IActionResult SendProcurementHTTP(int pro, string phar)
        {
            Pharmacy pharmacy = _pharmacyService.Get(phar);
            string endpoint = pharmacy.APIEndpoint;
            endpoint = endpoint.Substring(0, endpoint.Length - 5) + "urgent";
            string response = "";
            UrgentMedicationProcurement urgent = _service.Get(pro);
            using HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(urgent), Encoding.UTF8, "application/json");
           
            var task = client.PostAsync(endpoint, content)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    response = json.Result;
                });
            task.Wait();

            return Ok(response);
        }

        private IActionResult SendProcurementGRPC(int pro, string phar)
        {
            Pharmacy p = _pharmacyService.Get(phar);
            UrgentMedicationProcurement pr = _service.Get(pro);
            GrpcClient grpc = new GrpcClient();
            return Ok(grpc.Urgent(p, pr.MedicationName).Result);
        }
        private void SendMail()
        {
            foreach (Pharmacy pharmacy in _pharmacyService.GetAll())
            {
                MailRequestDTO mailRequest = new MailRequestDTO { ToEmail = pharmacy.Email, Subject = "Message from Medbay hospital", Body = "New urgent procurement in MedbayTech hospital!" };
                //_mailService.SendMailAsync(mailRequest).Wait();
            }
        }

    }
}
