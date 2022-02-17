using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.Domain.Users.Commands.Register
{
    public record RegisterUserResponse(string Email,string Token);
}
