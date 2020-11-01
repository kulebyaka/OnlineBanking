using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineBanking.BL.Models;

namespace OnlineBanking.BL.Services
{
    public interface IBankEntitiesService : ITransactionService, ICategoryService
    {
        Task<IEnumerable<PointWeightDto>> GetDataByColumnName(string columnName, CancellationToken token = default);
        Task<DistrictsDescriptionDto> GetAverageBill(int? categoryId, int? tagId, CancellationToken token = default);
        Task<IEnumerable<DistrictsDescriptionDto>> GetAverageAge(int? categoryId, IEnumerable<int> tags, CancellationToken token = default);
        Task<DistrictsDescriptionDto> GetCreditWorthiness(int? categoryId, string tags, CancellationToken token);
    }
}