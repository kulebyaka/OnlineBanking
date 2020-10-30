using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineBanking.BL.Models;

namespace OnlineBanking.BL.Services
{
    public interface ICategoryService
    {
        Task<BankCategoryDto> GetCategoryAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<BankCategoryDto>> GetCategoryListAsync(CancellationToken cancellationToken = default);
    }
    
}