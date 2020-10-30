using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineBanking.BL.Models;

namespace OnlineBanking.BL.Services
{
    public interface ITransactionService
    {
        Task<BankTransactionDto> GetTransactionAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<BankTransactionDto>> GetTransactionListAsync(CancellationToken cancellationToken = default);
    }
}