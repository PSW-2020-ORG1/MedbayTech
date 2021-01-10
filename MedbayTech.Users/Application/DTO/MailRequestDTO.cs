using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MedbayTech.Users.Application.DTO
{
    public class MailRequestDTO
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
