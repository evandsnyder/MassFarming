using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassFarming.Controllers
{
    [Route("api/farm")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public FarmController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            try
            {
                var farms = await _repository.Farm.GetAllFarmsAsync();
                return Ok(farms);
            }
            catch (Exception ex)
            {
                _logger.LogError($"SOMETHING WENT WRONG: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
