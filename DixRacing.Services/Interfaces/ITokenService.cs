using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Users user);
    }
}
