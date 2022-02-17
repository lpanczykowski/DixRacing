using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.Domain.Users.Commands.Login
{
    public record LoginUserDto(string Email,string Password);
    
}
