using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Mailing;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Pharmacies;
using MedbayTech.Pharmacies.Application.DTO;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
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

        private void SendMail()
        {
            foreach (Pharmacy pharmacy in _pharmacyService.GetAll())
            {
                MailRequestDTO mailRequest = new MailRequestDTO { ToEmail = pharmacy.Email, Subject = "Message from Medbay hospital", Body = "New urgent procurement in MedbayTech hospital!" };
                _mailService.SendMailAsync(mailRequest).Wait();
            }
        }

    }
}
