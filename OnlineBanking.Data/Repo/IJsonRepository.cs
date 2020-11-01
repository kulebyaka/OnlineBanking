using System.Collections.Generic;

namespace OnlineBanking.Data.Repo
{
    public interface IJsonRepository<T> where T : class
    {
        IEnumerable<T> Get(string path);
    }
}