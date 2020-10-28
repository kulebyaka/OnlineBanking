using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBanking.BL
{
    public class TransactionService : ITransactionService
    {
        public Task<BankTransactionDto> GetTransactionAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IList<BankTransactionDto>> GetTransactionListAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}