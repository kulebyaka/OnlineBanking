using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBanking.Data.Repo
{
    public interface ITransactionsRepo : IRepository<TransactionDb>
    {
        Task<IQueryable<TransactionDb>> GetByColumnName(string columnName, CancellationToken token = default);
    }
}
