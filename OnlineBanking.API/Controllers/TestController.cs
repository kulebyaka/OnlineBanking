using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineBanking.API.Settings;

namespace OnlineBanking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly IOptionsSnapshot<CustomSettings> _settings;


        public TestController(ILogger<TransactionsController> logger, IOptionsSnapshot<CustomSettings> settings)
        {
            this._settings = settings;
            this._logger = logger;
        }

        [HttpGet("ThrowAnException")]
        public IActionResult ThrowAnException()
        {
            throw new Exception("Example exception");
        }
        
        [HttpGet("Settings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Settings.CustomSettings GetSettings()
        {
            return _settings.Value;
        }
    }
}