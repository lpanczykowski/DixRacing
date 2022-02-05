using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.Request
{
    public class AccountRegisterRequest
    {
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Surname {get;set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string SteamId{get;set;}
    }
}