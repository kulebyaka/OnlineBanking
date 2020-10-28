using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBanking.BL;
using Swashbuckle.Swagger.Annotations;

namespace OnlineBanking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            this._transactionService = transactionService;
            this._logger = logger;
        }    
       
        [HttpGet]
        [SwaggerResponse(200)]
        [SwaggerResponse(404, "Transaction was not found")]
        [SwaggerResponse(500)]
        [Route("{id}")]
        public async Task<BankTransactionDto> Get([Required]int id, CancellationToken cancellationToken = default)
        {
            return await _transactionService.GetTransactionAsync(id, cancellationToken);
        }

        [HttpGet]
        [SwaggerResponse(200)]
        [SwaggerResponse(500)]
        [Route("")]
        public async Task<IEnumerable<BankTransactionDto>> GetList(CancellationToken cancellationToken = default)
        {
            var items = await _transactionService.GetTransactionListAsync(cancellationToken);
            return items; //.MapWith<ItemDTO, ItemView>(mapper);
        }
        
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}