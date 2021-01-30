
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports;
using MedbayTech.Pharmacies.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MedbayTech.Pharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpFileSharingController : Controller
    {

        private IMedicationUsageReportService _medicationUsageReportService;

        public HttpFileSharingController(IMedicationUsageReportService medicationUsageReportService)
        {
            _medicationUsageReportService = medicationUsageReportService;
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_medicationUsageReportService.GetAll());

        [HttpGet("{file?}")]
        public IActionResult Get(string file)
        {
            // TODO(Jovan): Confirm remove
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
