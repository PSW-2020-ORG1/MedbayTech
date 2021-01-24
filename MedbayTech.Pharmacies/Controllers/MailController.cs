using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Mailing;
using MedbayTech.Pharmacies.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Pharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : Controller
    {
        private readonly IMailService _mailService;
        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async void SendMail(MailRequestDTO request)
        {
            try
            {
                await _mailService.SendMailAsync(request);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
