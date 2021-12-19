using DixRacing.Core.Models.Request;
using DixRacing.Data;
using DixRacing.Data.Entites;
using DixRacing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services
{
    public class AddRound : IAddRound
    {
        private readonly DataContext _datacontext;
        public AddRound(DataContext datacontext)
        {
            _datacontext=datacontext;
        }

        public async Task<bool> AddRoundAsync (AddRoundRequest addRoundRequest)
        {
            var Rounds = new Rounds
            {
                TrackId = addRoundRequest.TrackID,
                ServerPassword = addRoundRequest.ServerPassword,
                ServerName = addRoundRequest.ServerName
            };
            _datacontext.Add(Rounds);
            return await _datacontext.SaveChangesAsync()>0;
            
        }
    }
}