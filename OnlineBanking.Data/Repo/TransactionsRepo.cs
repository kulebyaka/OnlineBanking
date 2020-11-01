using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Data.Models;

namespace OnlineBanking.Data.Repo
{
    public class TransactionsRepo : ITransactionsRepo
    {
        public async Task<IEnumerable<BankTransaction>> Get(CancellationToken cancellationToken)
        {
            using (var db = new BankAppContext())
            {
                return await db.Set<BankTransaction>().ToListAsync();
            }
        }

        public async Task<BankTransaction> GetById(int id, CancellationToken cancellationToken)
        {
            using (var db = new BankAppContext())
            {
                return await db.Set<BankTransaction>()
                    .FindAsync(new object[] { id }, cancellationToken);
            }
            
        }

        public async Task<IEnumerable<BankTransaction>> GetByFilter(int? categoryId, string tags)
        {
            using (var db = new BankAppContext())
            {
                return await db.Set<BankTransaction>()
                    .Where(a=>a.ShopTags.Contains(tags)).ToListAsync(); 
            }
        }

        public async Task<double> GetAverageAgeByFilter(int? categoryId, string tags)
        {
            using (var db = new BankAppContext())
            {
                var x = await db.Set<BankTransaction>()
                    .Where(a=>a.ShopTags.Contains(tags)).AverageAsync(x => x.Amount);
                return x;
            }
        }
    }
}
