using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using OnlineBanking.BL.Models;
using OnlineBanking.Data.Repo;
using Newtonsoft.Json;

namespace OnlineBanking.BL.Services
{
    public class RealBankEntitiesService : IBankEntitiesService
    {
        public RealBankEntitiesService(ITransactionsRepo transactionsRepo, IShopsRepo shopsRepo, IDistrictStatisticsRepo districtStatisticsRepo, IMapper mapper)
        {
            _transactionsRepo = transactionsRepo;
            _shopsRepo = shopsRepo;
            _districtStatisticsRepo = districtStatisticsRepo;
            _mapper = mapper;
        }

        private IDistrictStatisticsRepo _districtStatisticsRepo;
        private readonly ITransactionsRepo _transactionsRepo;
        private readonly IShopsRepo _shopsRepo;
        private readonly IMapper _mapper;
        
        public async Task<BankTransactionDto> GetTransactionAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BankTransactionDto>> GetTransactionListAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<BankCategoryDto> GetCategoryAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            
        }

        public async Task<IEnumerable<BankCategoryDto>> GetCategoryListAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PointWeightDto>> GetDataByColumnName(string columnName, CancellationToken token = default)
        {
            var x = await _transactionsRepo.Get(token);
            return x.Select(_mapper.Map<PointWeightDto>);
        }
        
        private async Task<double> GetAverageAgeFromDb(int? categoryId, IEnumerable<int> tags, CancellationToken token = default)
        {
            var x = _districtStatisticsRepo.GetDistrictStatistics();

           return await  _transactionsRepo.GetAverageAgeByFilter(categoryId, "178, 242");
        }
        
        public async Task<IEnumerable<DistrictsDescriptionDto>> GetAverageAge(int? categoryId, IEnumerable<int> tags, CancellationToken token = default)
        {
            var x = await this.GetAverageAgeFromDb(categoryId, tags);
            return new[] {new DistrictsDescriptionDto()};
        }

        public async Task<DistrictsDescriptionDto> GetCreditWorthiness(int? categoryId, string tags, CancellationToken token)
        {
            using (StreamReader r = new StreamReader("../OnlineBanking.Data/json/districts_geojson_tmp.json")) //todo: set proper dir and read file not in this function 
            {
                string json = r.ReadToEnd();
                DistrictsDescriptionDto districtsDescription = JsonConvert.DeserializeObject<DistrictsDescriptionDto>(json);
                
                Random rnd = new Random();

                districtsDescription.features = districtsDescription.features
                    .Where(a => WorthinessGroceryPredict.Keys.Contains(a.properties.ID)).ToList();
                districtsDescription.features.ForEach(dists => dists.properties.DecimalValue = WorthinessGroceryPredict[dists.properties.ID]);

                var output = new DistrictsDescriptionDto {
                    type = "Type",
                    name = "BankApp",
                    features = districtsDescription.features
                };
                return output;
            }
            
        }

        public async Task<DistrictsDescriptionDto> GetAverageBill(int? categoryId, int? tagId, CancellationToken token = default)
        {

            using (StreamReader r = new StreamReader("../OnlineBanking.Data/json/districts_geojson_tmp.json")) //todo: set proper dir and read file not in this function 
            {
                string json = r.ReadToEnd();
                DistrictsDescriptionDto districtsDescription = JsonConvert.DeserializeObject<DistrictsDescriptionDto>(json);
                
                Random rnd = new Random();
                long value  = rnd.Next(0, 1001);
                districtsDescription.features.ForEach(dists => dists.properties.Value = value);

                districtsDescription.features.First(dists => dists.properties.ID == 0).properties.Value = 700;
                districtsDescription.features.First(dists => dists.properties.ID == 1).properties.Value = 700;

                var output = new DistrictsDescriptionDto {
                    type = "Type",
                    name = "BankApp",
                    features = districtsDescription.features
                };
                return output;
            }

        }

        public static Dictionary<int, decimal> WorthinessGroceryPredict = new Dictionary<int, decimal>()
        {
            {19, 0.36204344983803216m},
            {20, 0.5588963243983442m},
            {35, 0.5720476872250477m},
            {40, 0.5782952610004327m},
            {43, 0.7926347221169155m},
            {45, 0.6030029734848146m},
            {47, 0.5962657993494708m},
            {48, 0.5984489596162168m},
            {49, 0.67881146299339m},
            {50, 0.0075138755005376865m},
            {52, 0.33012918574068983m},
            {53, 0.012574462372558064m},
            {54, 0.004624024439981859m},
            {55, 0.5037958732014542m},
            {56, 0.9522494917118041m},
            {39, 0.43098703998380544m},
            {41, 0.4284704156118157m},
            {18, 0.33540067268730184m}
        };
    }
}