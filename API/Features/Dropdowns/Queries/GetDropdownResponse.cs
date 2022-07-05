using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Dropdowns.Queries
{
    public record GetDropdownResponse(IEnumerable<DropdownDto> DropdownValues)
    {
        
    }

    public class DropdownDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}