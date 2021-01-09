using Backend.Reports.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpFileSharingController : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Directory.GetFiles("GeneratedUsageReports"));
        }

        [HttpGet("{file?}")]
        public IActionResult Get(string file)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(FileMetadata fileInfo)
        {
            WebClient myWebClient = new WebClient();
            byte[] responseArray = myWebClient.UploadFile(fileInfo.URL, fileInfo.Filename);
            return Ok(myWebClient.Encoding.GetString(responseArray));
        }
    }
}
