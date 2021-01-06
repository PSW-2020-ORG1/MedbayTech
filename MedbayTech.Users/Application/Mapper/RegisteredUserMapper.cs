using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Domain.Entites;

namespace MedbayTech.Users.Application.Mapper
{
    public class RegisteredUserMapper
    {
        public static AuthenticatedUserDTO RegisteredUserToAuthenticatedUserDTO(RegisteredUser user)
        {
            return new AuthenticatedUserDTO
            {
                Username = user.Username,
                Role = user.Role,
                Id = user.Id
            };
        }
    }
}
