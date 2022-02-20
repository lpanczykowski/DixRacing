using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class RoundsController : BaseApiController
    {
        public RoundsController(IMediator mediator) : base(mediator)
        {
        }

    }
}