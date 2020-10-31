using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineBanking.BL.Models;

namespace OnlineBanking.BL.Services
{
    public interface IBankEntitiesService : ITransactionService, ICategoryService
    {
        Task<IEnumerable<PointWeightDto>> GetDataByColumnName(string columnName, CancellationToken token = default);
        Task<IEnumerable<DistrictWeightDto>> GetAverageBill(int categoryId, int? tagId, CancellationToken token = default);
    }
}