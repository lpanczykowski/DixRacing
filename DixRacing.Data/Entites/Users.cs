using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Nick { get; set; }
        public byte[] PasswordHash {get;set;}
        public byte[] PasswordSalt { get; set; }
        public string Email {get;set;}
        public string Name {get;set;}
        public string Surname { get; set; }
        public string SteamId { get; set; }

    }
}