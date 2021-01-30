using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Tenders.Application.DTO
{
    public class MailRequestDTO
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public MailRequestDTO() { }
        public MailRequestDTO(string toEmail, string subject, string body)
        {
            ToEmail = toEmail;
            Subject = subject;
            Body = body;
        }

    }
}
