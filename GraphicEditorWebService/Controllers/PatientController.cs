﻿using Backend.Users.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphicEditorWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PatientController : Controller
    {
        private IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{textBoxSearch?}/{operation}")]
        public IActionResult Get(string textBoxSearch, int operation)
        {
            if(operation == 0)
            {
                return Ok(_patientService.GetAll());
            }
            else
            {
                return Ok();
            }
        }
    }
}
