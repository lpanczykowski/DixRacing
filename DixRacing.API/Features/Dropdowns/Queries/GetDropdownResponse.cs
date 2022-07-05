using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Dropdowns.Queries
{
    public record GetDropdownResponse(IEnumerable<DropdownDto> DropdownValues)
    {
        
    }

    public record DropdownDto(int Id, string Value)
    {

    }
}