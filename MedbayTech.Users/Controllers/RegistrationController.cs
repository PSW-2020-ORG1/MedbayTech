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
using MedbayTech.Users.Application.Mappers;
using MedbayTech.Users.Application.Validators;

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

            GenerateEmailInfo(patient);

            return Ok("Please check your mail to confirm registration");
        }

        private void GenerateEmailInfo(Patient patient)
        {
            var link = GenerateUrl(patient.Id, patient.Token);
            string email = patient.Email;
            MailRequestDTO mailRequest = new MailRequestDTO { ToEmail = email, Url = link };
            SendMail(mailRequest);
        }

        private string GenerateUrl(string _userId, string _token)
        {
            string url = Url.Action(nameof(Activate), "Registration", new { userId = _userId, token = _token });
            return GetDomain() + url;
        }

        [Route("activate")]
        public IActionResult Activate(string userId, string token)
        {
            Patient patient = _registrationService.ActivateAccount(userId, token);
            if (patient == null) return BadRequest();

            return Ok("Login Page");
        }

        private string GetDomain()
        {
            string domain = Environment.GetEnvironmentVariable("DOMAIN") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
            return $"http://{domain}:{port}";
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
