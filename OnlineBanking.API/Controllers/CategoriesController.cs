using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineBanking.API.Settings;
using OnlineBanking.BL;
using OnlineBanking.BL.Models;
using OnlineBanking.BL.Services;

namespace OnlineBanking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IBankEntitiesService _bankEntitiesService;

        public CategoriesController(ILogger<CategoriesController> logger, IBankEntitiesService bankEntitiesService)
        {
            this._bankEntitiesService = bankEntitiesService;
            this._logger = logger;
        }    
       
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BankCategoryDto> Get([Required]int id, CancellationToken cancellationToken = default)
        {
            return await _bankEntitiesService.GetCategoryAsync(id, cancellationToken);
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<BankCategoryDto>> GetList(CancellationToken cancellationToken = default)
        {
            var items = await _bankEntitiesService.GetCategoryListAsync(cancellationToken);
            return items.ToList();
        }
    }
}