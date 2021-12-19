using DixRacing.Core.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface IResultManager
    {
        Task<int> ManageResults(Results results);
    }
}