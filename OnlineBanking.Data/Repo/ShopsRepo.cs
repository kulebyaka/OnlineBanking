using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Data.Models;

namespace OnlineBanking.Data.Repo
{
    public class ShopsRepo : IShopsRepo
    {
        public async Task<IEnumerable<Shop>> Get(CancellationToken cancellationToken)
        {
            using (var db = new BankAppContext())
            {
                return await db.Set<Shop>().ToListAsync();
            }
        }

        public async Task<Shop> GetById(int id, CancellationToken cancellationToken)
        {
            using (var db = new BankAppContext())
            {
                return await db.Set<Shop>()
                    .FindAsync(new object[] { id }, cancellationToken);
            }
            
        }
    }
}