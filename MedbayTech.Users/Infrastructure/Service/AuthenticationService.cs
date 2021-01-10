using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Application.Mapper;
using MedbayTech.Users.Domain.Entites;
using MedbayTech.Users.Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.IdentityModel.Tokens;

namespace MedbayTech.Users.Infrastructure.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public AuthenticatedUserDTO Authenticate(string username, string password)
        {
            RegisteredUser user = _userRepository.GetBy(username, password);

            if (user == null)
                return null;

            if (user.Role.Equals("Patient"))
            {
                Patient p = (Patient)user;
                if (p.Blocked || !p.Confirmed)
                {
                    return null;
                }
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("QKcOa8xPopVOliV6tpvuWmoKn4MOydSeIzUt4W4r1UlU2De7dTUYMlrgv3rU"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Id),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("Role", user.Role)
            };

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials,
                claims: claims);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return RegisteredUserMapper.RegisteredUserToAuthenticatedUserDTO(user, tokenString);

        }
    }
}
