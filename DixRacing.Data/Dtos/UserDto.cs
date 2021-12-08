using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Dtos
{
    public class UserDto
    {
        public string Nick { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordKey { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        

    }
}