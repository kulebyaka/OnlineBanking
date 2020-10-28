using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBanking.BL
{
    public interface ITransactionService
    {
        Task<BankTransactionDto> GetTransactionAsync(int id, CancellationToken cancellationToken = default);
        Task<IList<BankTransactionDto>> GetTransactionListAsync(CancellationToken cancellationToken = default);
    }
}