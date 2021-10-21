using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Core.Errors
{
    public class ApiExtensions
    {      
        public ApiExceptions(int statusCode, string message = null, string details=null)
        {
            this.statusCode = statusCode;
            this.message = message;
            this.details = details;
        }

        public int  statusCode { get; set; }
        public string message { get; set; }
        public string details { get; set; }
        
    }
}