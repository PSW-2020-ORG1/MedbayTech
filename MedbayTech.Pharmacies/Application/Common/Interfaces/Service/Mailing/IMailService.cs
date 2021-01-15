using MedbayTech.Pharmacies.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Mailing
{
    public interface IMailService
    {
        public Task SendMailAsync(MailRequestDTO mailRequest);
    }
}
