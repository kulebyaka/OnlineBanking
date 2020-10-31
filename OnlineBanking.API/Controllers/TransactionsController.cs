using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBanking.BL.Models;
using OnlineBanking.BL.Services;

namespace OnlineBanking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly IBankEntitiesService _bankEntitiesService;
        public TransactionsController(ILogger<TransactionsController> logger, IBankEntitiesService bankEntitiesService)
        {
            this._bankEntitiesService = bankEntitiesService;
            this._logger = logger;
        }    
       
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BankTransactionDto> Get([Required]int id, CancellationToken cancellationToken = default)
        {
            return await _bankEntitiesService.GetTransactionAsync(id, cancellationToken);
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<BankTransactionDto>> GetList(CancellationToken cancellationToken = default)
        {
            var items = await _bankEntitiesService.GetTransactionListAsync(cancellationToken);
            return items.ToList(); //.MapWith<ItemDTO, ItemView>(mapper);
        }
        
        [HttpGet("rowdata/{columnName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<PointWeightDto>> GetByColumn([Required]string columnName, CancellationToken cancellationToken = default)
        {
            var items = await _bankEntitiesService.GetDataByColumnName(columnName, cancellationToken);
            return items; //.MapWith<ItemDTO, ItemView>(mapper);
        }
        [HttpGet("AverageBill/{categoryId}/{tagId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<DistrictWeightDto>> GetAverageBill(int? categoryId, int? tagId, CancellationToken token = default)
        {
            var items = await _bankEntitiesService.GetAverageBill(categoryId, tagId, token);
            return items; //.MapWith<ItemDTO, ItemView>(mapper);
        }
    }
}