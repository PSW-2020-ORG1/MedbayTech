﻿using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Mailing;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Pharmacies;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Pharmacies.Application.DTO;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : Controller
    {

        private readonly ITenderService _tenderService;
        private readonly IMailService _mailService;
        private readonly IPharmacyService _pharmacyService;

        public TenderController(ITenderService tenderService, IMailService mailService, IPharmacyService pharmacyService)
        {
            _tenderService = tenderService;
            _mailService = mailService;
            _pharmacyService = pharmacyService;
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
            Medication medication;
            List<TenderMedicationDTO> tenderMedicationDTOs = new List<TenderMedicationDTO>();
            List<TenderMedication> tenderMedications = _tenderService.GetMedications(id);
            foreach (TenderMedication tenderMedication in tenderMedications)
            {
                using HttpClient client = new HttpClient();

                var task = client.GetAsync("http://localhost:50202/api/Medication/" + tenderMedication.MedicationId)
                    .ContinueWith((taskWithResponse) =>
                    {
                        var message = taskWithResponse.Result;
                        var json = message.Content.ReadAsStringAsync();
                        json.Wait();
                        medication = JsonConvert.DeserializeObject<Medication>(json.Result);
                        tenderMedicationDTOs.Add(new TenderMedicationDTO(medication.Id, medication.Name, medication.Dosage, tenderMedication.TenderMedicationQuantity));
                    });
                task.Wait();

            }
            return Ok(tenderMedicationDTOs);

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
            foreach (Pharmacy pharmacy in _pharmacyService.GetAll())
            {
                MailRequestDTO mailRequest = new MailRequestDTO { ToEmail = pharmacy.Email, Subject = "Message from Medbay hospital", Body = "New tender opened in MedbayTech hospital!" };
                _mailService.SendMailAsync(mailRequest).Wait();
            }
        }
    }
}
