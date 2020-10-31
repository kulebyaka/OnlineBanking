using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBanking.Data.Repo
{
    public class TransactionsRepo : ITransactionsRepo
    {
        readonly List<TransactionDb> TransactionDbs = new List<TransactionDb>()
        {
            new TransactionDb(1),
            new TransactionDb(2)
        };

        public IQueryable<TransactionDb> Get()
        {
            return TransactionDbs.AsQueryable();
        }

        public TransactionDb GetById(int id)
        {
            throw new NotImplementedException();
        }


        public void Create(TransactionDb p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));

            TransactionDbs.Add(p);
        }

        public void Delete(int id)
        {
            var p = TransactionDbs.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                throw new KeyNotFoundException($"An object of a type '{nameof(TransactionDb)}' with the key '{id}' not found");
            }

            TransactionDbs.RemoveAll(x => x.Id == p.Id);
        }

        public void Update(TransactionDb p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));

            var stored = TransactionDbs.FirstOrDefault(x => x.Id == p.Id);
            if (stored == null)
            {
                throw new KeyNotFoundException($"An object of a type '{nameof(TransactionDb)}' with the key '{p.Id}' not found");
            }

            TransactionDbs.RemoveAll(x => x.Id == stored.Id);
            TransactionDbs.Add(p);
        }

        public Task<IQueryable<TransactionDb>> GetByColumnName(string columnName, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
    
    public class TransactionDb : IEntity
    {
        public TransactionDb(int i)
        {
            Id = i;
        }

        public int Id { get; }
    }
}
