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
    public class RegisterService : IRegisterService
    {
        private readonly DataContext _context;

        public RegisterService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfUserExistsByMail(AccountRegisterRequest accountRegisterRequest)
        {
            return await _context.Users.AnyAsync(x => x.Email == accountRegisterRequest.Email);

        }
    }
}