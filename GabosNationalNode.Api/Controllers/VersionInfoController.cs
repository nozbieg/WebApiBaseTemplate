using GabosNationalNode.Application.Features.VersionInfo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabosNationalNode.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionInfoController : Controller
    {
        readonly IMediator mediator;

        public VersionInfoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetInfo()
        {
            var query = new GetVersionInfoQuery();

            var result = await mediator.Send(query);

            return Ok(result);
        }
    }
}
