using System.Collections.Generic;
using OnlineBanking.Data.Models;

namespace OnlineBanking.Data.Repo
{
    public interface IDistrictStatisticsRepo : IJsonRepository<DistrictStatistic>
    {
        public IEnumerable<DistrictStatistic> GetDistrictStatistics();
    }
}