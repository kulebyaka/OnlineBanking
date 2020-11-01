using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineBanking.Data.Models;

namespace OnlineBanking.Data.Repo
{
    public interface ITransactionsRepo : IRepository<BankTransaction>
    {
        Task<IEnumerable<BankTransaction>> GetByFilter(int? categoryId, string tags);
        Task<double> GetAverageAgeByFilter(int? categoryId, string tags);
    }
}
