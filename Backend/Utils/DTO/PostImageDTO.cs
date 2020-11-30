using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PostImageDTO
    {
        public string Id { get; set; }
        public IFormFile File { get; set; }
    }
}
