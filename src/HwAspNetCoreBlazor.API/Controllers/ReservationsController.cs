using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly ILogger<ReservationsController> _logger;
        private readonly IReservationRepository _repository;

        public ReservationsController(ILogger<ReservationsController> logger, IReservationRepository repository)
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
