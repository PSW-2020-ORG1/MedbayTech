using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Application.Mapper;
using MedbayTech.Users.Application.Mappers;
using MedbayTech.Users.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Users.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticationDTO authenticationDTO)
        {

            AuthenticatedUserDTO auteAuthenticatedUserDto = _authenticationService.Authenticate(authenticationDTO.Username, authenticationDTO.Password);
            if (auteAuthenticatedUserDto == null)
                return BadRequest("Username or password is incorrect");

            

            return Ok(auteAuthenticatedUserDto);
        }
        [Authorize(Roles = Role.Admin)]
        [HttpGet("proba")]
        public IActionResult Get()
        {
            return Ok(User.Identity.Name);
        }
    }
}
