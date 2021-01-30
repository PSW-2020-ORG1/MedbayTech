
using MedbayTech.Tenders.Application.Common.Interfaces.Service.Mailing;
using MedbayTech.Tenders.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Tenders.Application.DTO;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Tenders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderOfferController : Controller
    {
        private readonly ITenderOfferService _tenderOfferService;
        private readonly IMailService _mailService;

        public TenderOfferController(ITenderOfferService tenderOfferService, IMailService mailService)
        {
            _tenderOfferService = tenderOfferService;
            _mailService = mailService;
        }

        [HttpGet("tender/{id?}")]
        public IActionResult Get(int id)
        {
            return Ok(_tenderOfferService.GelAllForTender(id));
        }

        [HttpPost("makeOffer")]
        public IActionResult MakeOffer(TenderOffer tenderOffer)
        {
            bool isTenderOfferSuccessfullyAdded = _tenderOfferService.Add(tenderOffer) != null;

            if (isTenderOfferSuccessfullyAdded)
            {
                //SendMail(tenderOffer.PharmacyEMail);
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpGet("notfy/{email?}")]
        public IActionResult SendMail(string email)
        {
            MailRequestDTO mailRequest = new MailRequestDTO { ToEmail = email, Subject = "Message from Medbay hospital", Body = "Made an offer from MedbayTech hospital!" };
            _mailService.SendMailAsync(mailRequest).Wait();
            return Ok();
        }

    }
}
