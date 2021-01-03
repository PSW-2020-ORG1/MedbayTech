
using MedbayTech.Users.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetBy(string id)
        {
            return Ok(_userService.GetBy(id));
        }

    }
}
