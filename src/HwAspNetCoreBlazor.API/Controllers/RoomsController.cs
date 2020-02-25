using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly ILogger<RoomsController> _logger;
        private readonly IRoomRepository _repository;

        public RoomsController(ILogger<RoomsController> logger, IRoomRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IActionResult> GetAll()
        {
            _logger.LogTrace($"Received connection request on {this.GetType()}");

            var results = await _repository.GetAllAsync();
            if (results.Any())
                return Ok(results);
            else
                return NotFound();
        }
    }
}
