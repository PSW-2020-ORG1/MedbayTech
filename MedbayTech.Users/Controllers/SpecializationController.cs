
using System.Collections.Generic;
using System.Linq;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Application.Mapper;
using MedbayTech.Users.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        [Authorize(Roles = "Patient")]
        public IActionResult GetAll()
        {
            List<Specialization> specializations = _specializationService.GetAll().ToList();
            List<SpecializationDTO> specializationDTOs = SpecializationMapper.ListSpecializationToListSpecializationDTO(specializations);
            return Ok(specializationDTOs);
        }
    }
}
