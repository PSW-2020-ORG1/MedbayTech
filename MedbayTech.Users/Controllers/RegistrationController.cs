using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Application;
using MedbayTech.Users.Application;
using MedbayTech.Users.Domain.Entites;
using MedbayTech.Users.Domain.ValueObjects;
using MedbayTech.Users.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MedbayTech.Users.Application.Mapper;

namespace MedbayTech.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        private readonly IMailService _mailService;
        
        public RegistrationController(IRegistrationService registrationService, IMailService mailService)
        {
            _registrationService = registrationService;
            _mailService = mailService;
        }


        [HttpPost("patientRegistration")]
        public IActionResult Register(PatientRegistrationDTO dto)
        {
            try
            {
                ValidateRegistrationInput.Validate(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            if (_registrationService.PatientExists(dto.Id, dto.Username))
                return BadRequest("Patient already exists");


            Patient patient = PatientRegistrationMapper.PatientRegistrationDTOtoPatient(dto);

            patient.Token = RegistrationTokenService.GenerateGuidToken();

            Patient registeredPatient = _registrationService.Register(patient);

            if (registeredPatient == null)
                return BadRequest("Patient already exists");

            //GenerateEmailInfo(patient);

            return Ok("Please check your mail to confirm registration");
        }

    }
}
