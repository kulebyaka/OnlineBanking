using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineBanking.API.Settings;
using OnlineBanking.BL;

namespace OnlineBanking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IOptionsSnapshot<CustomSettings> _settings;


        public TransactionsController(ILogger<TransactionsController> logger, ITransactionService transactionService, IOptionsSnapshot<CustomSettings> settings)
        {
            this._transactionService = transactionService;
            this._settings = settings;
            this._logger = logger;
        }    
       
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BankTransactionDto> Get([Required]int id, CancellationToken cancellationToken = default)
        {
            return await _transactionService.GetTransactionAsync(id, cancellationToken);
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<BankTransactionDto>> GetList(CancellationToken cancellationToken = default)
        {
            var items = await _transactionService.GetTransactionListAsync(cancellationToken);
            return items; //.MapWith<ItemDTO, ItemView>(mapper);
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