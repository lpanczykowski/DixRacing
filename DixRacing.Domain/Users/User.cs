using DixRacing.Domain.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;

namespace DixRacing.Domain.Users
{
    public class User : BaseEntity
    {

        public string Nick { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SteamId { get; set; }
        public string DiscordId { get; set; }

    }
}