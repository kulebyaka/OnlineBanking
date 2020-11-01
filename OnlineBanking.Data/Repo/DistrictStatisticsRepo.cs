using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OnlineBanking.Data.Models;

namespace OnlineBanking.Data.Repo
{
    public class DistrictStatisticsRepo : IDistrictStatisticsRepo
    {
        public IEnumerable<DistrictStatistic> Get(string path)
        {
            using (StreamReader r = new StreamReader(path)) //todo: set proper dir and read file not in this function 
            {
                string json = r.ReadToEnd();
                var districtStatistics = JsonConvert.DeserializeObject<List<DistrictStatistic>>(json);
                return districtStatistics;
            }
        }

        public IEnumerable<DistrictStatistic> GetDistrictStatistics()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            return this.Get("../OnlineBanking.Data/json/districts_statistics.json");
        }
    }
}