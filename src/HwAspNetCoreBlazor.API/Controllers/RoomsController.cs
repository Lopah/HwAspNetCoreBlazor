using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
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

        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogTrace($"Received request for {id} on {nameof(this.GetType)}");

            var result = await _repository.GetByIdAsync(id);
            return result != null ? Ok(result) : (IActionResult)NotFound();
        }

        [Route("Date/{date}")]
        public async Task<IActionResult> GetByTime(DateTime date)
        {
            _logger.LogTrace($"Received connection request on {this.GetType()}");

            var results = await _repository.GetAllAsync();
            return results.Any() ? Ok(results) : (IActionResult)NotFound();
        }
    }
}
