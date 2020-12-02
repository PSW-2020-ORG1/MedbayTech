using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.MailService
{
    public interface IMailService
    {
        public Task SendMailAsync(MailRequest mailRequest);

    }
}
