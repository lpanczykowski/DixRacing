using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.Domain.Users.Commands
{
    public record RegisterUserDto(string Name,string Surname,string Nick,string Email,string SteamId,string Password);
    
}
