using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Users.Service.Interfaces;
using Backend.Utils.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WebApplication.Adapters;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        ISpecializationService _specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        public IActionResult GetAll()
        {
            List<Specialization> specializations = _specializationService.GetAll().ToList();
            List<SpecializationDTO> specializationDTOs = SpecializationAdapter.ListSpecializationToListSpecializationDTO(specializations);
            return Ok(specializationDTOs);
        }
    }
}
