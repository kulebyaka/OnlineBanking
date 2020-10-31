using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBanking.Data.Repo
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> Get(CancellationToken cancellationToken);
        Task<T> GetById(int id, CancellationToken cancellationToken);
    }
}
