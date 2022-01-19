using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trinity.OpenFinance.Api.Domain.Queries.Requests;

namespace Trinity.OpenFinance.Api.Controllers
{
    [ApiController]
    [Route("branches")]
    public class BranchController : ControllerBase
    {
        private readonly ILogger<BranchController> _logger;

        private readonly IMediator _mediator;

        public BranchController(ILogger<BranchController> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery]FindBranchesRequest command
        )
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
