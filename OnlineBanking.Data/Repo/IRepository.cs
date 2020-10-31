using System.Linq;

namespace OnlineBanking.Data.Repo
{
    public interface IRepository<T> where T : class, IEntity
    {
        void Create(T e);
        void Delete(int id);
        IQueryable<T> Get();
        T GetById(int id);
        void Update(T e);
    }
}
