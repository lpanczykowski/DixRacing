using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.Request
{
    public class AddEventRequest
    {
        
        public string Name { get; set; }
        public int GameId { get; set; }
                
    }
}