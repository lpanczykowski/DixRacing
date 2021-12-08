using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DixRacing.Core.Models.Request;
using DixRacing.Core.Models.Response;
using DixRacing.Data;
using DixRacing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DixRacing.Services
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _context;

        public AccountService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfUserExistsByEmail(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);

        }
    }
}