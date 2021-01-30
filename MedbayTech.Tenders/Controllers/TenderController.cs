using MedbayTech.Tenders.Application.Common.Interfaces.Gateways;
using MedbayTech.Tenders.Application.Common.Interfaces.Service.Mailing;
using MedbayTech.Tenders.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Tenders.Application.DTO;
using MedbayTech.Tenders.Domain.Entities.Medications;
using MedbayTech.Tenders.Domain.Entities.Pharmacies;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Tenders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : Controller
    {

        private readonly ITenderService _tenderService;
        private readonly IMailService _mailService;
        private readonly IPharmacyGateway _pharmacyGateway;

        public TenderController(ITenderService tenderService, IMailService mailService, IPharmacyGateway pharmacyGateway)
        {
            _tenderService = tenderService;
            _mailService = mailService;
            _pharmacyGateway = pharmacyGateway;
        }

        [HttpGet]
        public IEnumerable<Tender> GetAll()
        {
            return _tenderService.GetAll();
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int id)
        {
            return Ok(_tenderService.Get(id));
        }

        [HttpPost]
        public IActionResult CreateTender(TenderDTO tender)
        {

            Tender newTender = _tenderService.CreateTender(tender);
            int medicationCount = 0;
            foreach (TenderMedicationDTO medicationDTO in tender.tenderMedications)
            {
                TenderMedication tenderMedication = _tenderService.CreateMedicationForTender(newTender.Id, medicationDTO);
                if (tenderMedication != null)
                    medicationCount++;
            }
            bool isTenderSuccessfullyAdded = newTender != null;
            bool isMedicationSuccessfullyAdded = medicationCount == tender.tenderMedications.Count();

            if (isTenderSuccessfullyAdded && isMedicationSuccessfullyAdded)
            {
                SendMail();
                return Ok();
            }
            else
                return BadRequest();
        }
        
        [HttpGet("med/{id?}")]
        public IActionResult GetMedications(int id)
        {
            return Ok(_tenderService.GetMedications(id));
        }

        [HttpPost("winner")]
        public IActionResult DeclareWinner(Tender tender)
        {
            bool isTenderSuccessfullyAdded = _tenderService.Update(tender) != null;

            if (isTenderSuccessfullyAdded)
                return Ok();
            else
                return BadRequest();
        }

        private void SendMail()
        {
            foreach (Pharmacy pharmacy in _pharmacyGateway.GetAll())
            {
                MailRequestDTO mailRequest = new MailRequestDTO { ToEmail = pharmacy.Email, Subject = "Message from Medbay hospital", Body = "New tender opened in MedbayTech hospital!" };
                //_mailService.SendMailAsync(mailRequest).Wait();
            }
        }
    }
}
